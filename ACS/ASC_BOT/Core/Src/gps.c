#include "gps.h"
#include "minmea.h"

extern uint8_t gpsBuf[80];

float latitudeF;
float longtitudeF;

struct minmea_sentence_gga gpsDataTmp;

// PMTK_SET_NMEA_BAUDRATE 
uint8_t PMTK_SET_NMEA_BAUDRATE[] = {"$PMTK251,115200*1F\r\n"};

// PMTK_API_SET_NMEA_OUTPUT
uint8_t  PMTK_API_SET_NMEA_OUTPUT[] = {"$PMTK314,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0*29\r\n"};

uint8_t  counterGPS = 0;

void initFrame(gpsDataTypeDef *frame);

void setGpsOut(void)
{	
	HAL_UART_Transmit_IT(&huart6,PMTK_API_SET_NMEA_OUTPUT,sizeof(PMTK_API_SET_NMEA_OUTPUT));
}

void getDataGPS(gpsDataTypeDef *frame, char *buffer)
{	
	if (minmea_check(buffer,false))
	{
		frame->dataValid = VALID_DATA;		
	}
	else
	{
		frame->dataValid = INVALID_DATA;
		setGpsOut();
		counterGPS = 0;
		initFrame(frame);
	}
	
	if(frame->dataValid == VALID_DATA)
	{
		counterGPS++;
		if (minmea_parse_gga(&gpsDataTmp, buffer))
		{
			frame->time.hours 	= 		gpsDataTmp.time.hours;
			frame->time.minutes = 		gpsDataTmp.time.minutes;
			frame->time.seconds = 		gpsDataTmp.time.seconds;
			
			frame->latitude.scale = 	gpsDataTmp.latitude.scale;
			frame->latitude.value = 	gpsDataTmp.latitude.value;
																
			frame->longitude.scale = 	gpsDataTmp.longitude.scale;
			frame->longitude.value = 	gpsDataTmp.longitude.value;
			
			frame->quality = 					gpsDataTmp.fix_quality;
			
			frame->satteliteTracked = gpsDataTmp.satellites_tracked;
																
			frame->altitude.scale = 	gpsDataTmp.altitude.scale;
			frame->altitude.value = 	gpsDataTmp.altitude.value;
		}
		if(frame->satteliteTracked == 0 || frame->altitude.value == 0 || frame->latitude.value == 0 || frame->longitude.value == 0)
		{
			frame->dataValid = INVALID_DATA;
			initFrame(frame);			
		}
	}
	else
		{
			for(uint8_t i=0;i<sizeof(gpsBuf);i++)
			{
				gpsBuf[i]=0;
			}
			GpsNReset();
		}
}

void initFrame(gpsDataTypeDef *frame)
{
	frame->time.hours = 			0;
	frame->time.minutes = 		0;
	frame->time.seconds = 		0;
	
	frame->latitude.scale = 	0;
	frame->latitude.value = 	0;
	
	frame->longitude.scale = 	0;
	frame->longitude.value = 	0;
	
	frame->quality = 					0;
	frame->satteliteTracked = 0;
	
	frame->altitude.scale = 	0;
	frame->altitude.value = 	0;
}

float getCordinate(gpsDataTypeDef *frame, uint8_t coord)  //convert minute to degree //coord == 1 latitude, coord == 2 longtitude
{
	int32_t degree=0;
	int32_t minute=0;
	if(coord == 0x01)
	{
		int32_t degree = frame->latitude.value / (frame->latitude.scale * 100);
		int32_t minute = frame->latitude.value % (frame->latitude.scale * 100);
		latitudeF = (float) degree + (float)minute/(60 * frame->latitude.scale); //(float) degrees + (float) minutes / (60 * f->scale);
		return latitudeF;
	}
	if(coord == 0x02)
	{
		degree = frame->longitude.value / (frame->longitude.scale * 100);
		minute = frame->longitude.value % (frame->longitude.scale * 100);
		longtitudeF = (float) degree + (float)minute/(60 * frame->longitude.scale);
		return longtitudeF;
	}
}


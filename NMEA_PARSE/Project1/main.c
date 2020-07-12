#include <stdio.h>

#include "minmea.h"


char sentense[] = "$GPGGA,113209.00,4920.83258,N,02536.46272,E,1,06,2.70,282.9,M,33.0,M,,*5A";
//char sentense[] = "$GPGGA,113209.00,,S,,W,1,06,2.70,282.9,M,33.0,M,,*69";
char sentense1[] = "$GPGLL,4920.83258,N,02536.46272,E,113209.00,A,A*6D";
char sentense2[] = "$GPRMC,113210.00,A,4920.83256,N,02536.46253,E,0.312,,120720,,,A*77";

int main()
{
	struct minmea_sentence_gga frame;
	struct minmea_sentence_gll frameGll;
	struct minmea_sentence_rmc frameRmc;

	if (minmea_check(sentense,false))
	{
		if (minmea_parse_gga(&frame, sentense))
			printf("Ok!!!\r\n");
		else
			printf("Bad data!!!\r\n");
	}
	else
	{
		printf("Bad data!!!\r\n");
		return;
	}

	
	minmea_parse_gll(&frameGll,sentense1);
	minmea_parse_rmc(&frameRmc,sentense2);

	printf("Time: %d:%d:%d\r\n", 
		frame.time.hours,
		frame.time.minutes,
		frame.time.seconds);

	printf("Lat: %d | scale %d\r\n", frame.latitude.value , frame.latitude.scale);
	printf("Lon: %d | scale %d\r\n", frame.longitude.value, frame.longitude.scale);
	printf("Alt: %d | scale %d Uint:[%c]\r\n", frame.altitude.value , frame.altitude.scale, frame.altitude_units);
	printf("Satelitte quantity: %d\r\n", frame.satellites_tracked);

	printf("Latitude:\t%f\r\n"
		   "Longtitude:\t%f\r\n"
		   "Altitude:\t%f\r\n",
		minmea_tocoord(&frame.latitude),
		minmea_tocoord(&frame.longitude), 
		minmea_tofloat(&frame.altitude));

	printf("$xxRMC: raw coordinates and speed: (%d/%d,%d/%d) %d/%d\n",
		frameRmc.latitude.value, frameRmc.latitude.scale,
		frameRmc.longitude.value, frameRmc.longitude.scale,
		frameRmc.speed.value, frameRmc.speed.scale);
	printf("$xxRMC fixed-point coordinates and speed scaled to three decimal places: (%d,%d) %d\n",
		minmea_rescale(&frameRmc.latitude, 1000),
		minmea_rescale(&frameRmc.longitude, 1000),
		minmea_rescale(&frameRmc.speed, 1000));
	printf("$xxRMC floating point degree coordinates and speed: (%f,%f) %f\n",
		minmea_tocoord(&frameRmc.latitude),
		minmea_tocoord(&frameRmc.longitude),
		minmea_tofloat(&frameRmc.speed));

	return 0;
}
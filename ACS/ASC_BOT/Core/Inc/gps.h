/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/

#ifndef GPS_H
#define GPS_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx.h"
#include "main.h"
#include "stdio.h"
#include "string.h"

/*********************************************************************************************/
/************************************ EXTERNAL VARIABLE **************************************/
/*********************************************************************************************/

extern UART_HandleTypeDef huart6;


/*********************************************************************************************/
/***************************************** DEFINES *******************************************/
/*********************************************************************************************/

#define GpsReset()								HAL_GPIO_WritePin(GPIOB,GPIO_PIN_8,GPIO_PIN_SET)
#define GpsNReset()								HAL_GPIO_WritePin(GPIOB,GPIO_PIN_8,GPIO_PIN_RESET)

#define GpsStb()								HAL_GPIO_WritePin(GPIOB,GPIO_PIN_9,GPIO_PIN_RESET)
#define GpsNStb()								HAL_GPIO_WritePin(GPIOB,GPIO_PIN_9,GPIO_PIN_SET)

struct floatValue {
    int32_t value;
    int32_t scale;
};

struct sTime
{
	uint8_t hours;
	uint8_t minutes;
	uint8_t seconds;
};

typedef enum
{
	VALID_DATA = 0,
	INVALID_DATA
}eDataValidTypeDef;
	

typedef struct
{
	struct sTime time;
	struct floatValue latitude;
	struct floatValue longitude;
	uint8_t quality;
	uint8_t satteliteTracked;
	struct floatValue altitude;
	eDataValidTypeDef dataValid;
}gpsDataTypeDef;


/*********************************************************************************************/
/*********************************** FUNCTION PROTOTYPES *************************************/
/*********************************************************************************************/

//void setGpsOut(void); //set only GPGGA gps modul output
void getDataGPS(gpsDataTypeDef *frame, char *buffer);
float getCordinate(gpsDataTypeDef *frame, uint8_t coord);

#endif /*GPS_H_*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/

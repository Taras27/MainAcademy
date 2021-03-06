/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/

#ifndef WINDSENSOR_H
#define WINDSENSOR_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx.h"
#include "crc.h"

/*********************************************************************************************/
/***************************************** DEFINES *******************************************/
/*********************************************************************************************/

extern UART_HandleTypeDef huart3;

typedef enum
{
	WIND_SENSOR_OK,
	WIND_SENSOR_TIMEOUT,
	WIND_SENSOR_BAD_CRC,
	WIND_SENSOR_ERROR
}WIND_SensorStateTypeDef;

typedef struct
{
	uint16_t Speed;
	uint8_t Status;
}WIND_SensorTypeDef;

/*********************************************************************************************/
/*********************************** FUNCTION PROTOTYPES *************************************/
/*********************************************************************************************/

uint8_t getWindSpeed(WIND_SensorTypeDef *sensor);

#endif /*WINDSENSOR_H_*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/

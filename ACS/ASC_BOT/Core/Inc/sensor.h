/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/

#ifndef SENSOR_H
#define SENSOR_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx_hal.h"


extern UART_HandleTypeDef huart3; 


//#define debug 1

#define axisAZ 		0x01
#define axisEL 		0x02
#define axisPOL 	0x04


/* 
*	Multi byte command
*	High byte 0xFF
*	Low byte is cmd
*/

#define cmdPositionStatus			0x2F 

#define cmdHigh						0xFF

#define cmdSetOrigin				0x01
#define cmdSetAbsolutePosition		0x02
#define cmdReadMode					0x0B
#define cmdChangeMode				0x0D
#define cmdUnlock					0x2A
#define cmdGetMulti					0x34
#define cmdSetMulti					0x35

uint32_t getPosition (uint8_t axis);
uint8_t unlockSensor(uint8_t axis);
uint8_t setOrigin (uint8_t axis);
uint8_t setAbsolutePosition (uint8_t axis, uint16_t newPosition);
uint8_t readModeSensor(uint8_t axis);
uint8_t changeModeSensor(uint8_t axis, uint8_t mode);
uint32_t getMulti(uint8_t axis);
uint8_t setMulti (uint8_t axis, uint16_t mul, uint16_t div);

#endif /*SENSOR_H_*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/

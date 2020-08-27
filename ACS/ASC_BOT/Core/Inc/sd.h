/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/

#ifndef SD_H
#define SD_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx.h"
#include "fatfs.h"
#include "string.h"
#include "stdio.h"
#include "windSensor.h" 
#include "rtc.h"


extern sensorDataTypeDef sensorData;
extern RTC_TimeTypeDef timeRTC;
extern RTC_DateTypeDef dateRTC;


/*********************************************************************************************/
/*********************************** FUNCTION PROTOTYPES *************************************/
/*********************************************************************************************/

/* mounts the sd card*/
uint8_t mountSD (const TCHAR* path);

/* unmounts the sd card*/
uint8_t UnMountSD (const TCHAR* path);

/* write the data to the file
 * @ name : is the path to the file*/
FRESULT writeFile(char* name, char* data);

/* creates the file, if it does not exists
 * @ name : is the path to the file*/
FRESULT createFile(char* name);

/* creates a directory
 * @ name: is the path to the directory */
FRESULT createDirection (char *name);

/* updates the file. write pointer is set to the end of the file
 * @ name : is the path to the file */
FRESULT updateFile (char *name, char *data);


/*updates the file every 15 minutes
 *and create new file every day  */
uint8_t sdProcess(RTC_DateTypeDef *date, RTC_TimeTypeDef *time, sensorDataTypeDef *sensorData);

#endif /*SD_H_*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/



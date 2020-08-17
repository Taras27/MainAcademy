/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/

#ifndef PROTOCOL_H
#define PROTOCOL_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx.h"
#include "lenze.h"
#include "sensor.h"
#include "drivePol.h"
#include "windSensor.h"
#include "crc.h"
#include "main.h"
#include "gps.h"
#include "goto.h"
#include "externalRelay.h"
#include "rtc.h"

extern UART_HandleTypeDef huart1;
extern driveDataTypeDef driveStatus;
extern uint8_t softLimitSwitchStatus;
extern uint8_t hardLimitSwitchStatus;
extern sensorDataTypeDef sensorData;
extern gpsDataTypeDef gpsData;
extern int32_t gpsLatitude, gpsLongtitude;
extern userSettingsTypeDef workingSetting;
extern temperatureDataTypeDef temperarure;
extern swLimitSwitchTypeDef softwareLimitSwitch;
extern RTC_DateTypeDef dateRTC;

/*********************************************************************************************/
/***************************************** DEFINES *******************************************/
/*********************************************************************************************/

#define sensorDiv				0
#define sensorMantissa			0

#define limitSwitchLeft 		0x01
#define limitSwitchRight		0x02
#define limitSwitchTop 			0x04
#define limitSwitchBottom 		0x08

#define softLimitSwitchLeft 	0x01
#define softLimitSwitchRight	0x02
#define softLimitSwitchTop 		0x04
#define softLimitSwitchBottom 	0x08

#define beginPacket	0x7E

#define flagRight	0x01
#define flagLeft	0x02
#define flagTop		0x04
#define flagDown	0x08

/*********************************************************************************************/
/************************************ SETTING FUNCTION ***************************************/
/*********************************************************************************************/

typedef enum
{
	cmdTypeSet = 0x01,
	cmdTypeInfo = 0x02,
	cmdTypeWork = 0x03
}cmdUartTypeDef;

//**************

typedef enum
{
	cmdSetMaxSpeed = 0xF1,
	cmdSetMinSpeed = 0xF2,
	cmdSetSensorDir =	0xF3,
	cmdSetSensorMulti = 0xF4,
	cmdSetSoftLimits = 0xF5,
	cmdSetCurrPosition = 0xF6,
	cmdSetSpRelay = 0xF7,
	cmdSetDate = 0xF8
}cmdSetTypeDef;

/*********************************************************************************************/
/************************************** INFO FUNCTION ****************************************/
/*********************************************************************************************/
typedef enum
{
	cmdGetUtcTime = 0xF1,
	cmdGetGps = 0xF2,
	cmdGetSpeed = 0xF3,
	cmdGetSensorDir = 0xF4,
	cmdGetSensorMulti = 0xF5,
	cmdGetTemperature = 0xF6,
	cmdGetRelayState = 0xF7,
	cmdGetStatus = 0xF8,
	cmdGetDate = 0xF9
}cmdGetTypeDef;

/*********************************************************************************************/
/************************************** WORK FUNCTION ****************************************/
/*********************************************************************************************/

typedef enum
{
	cmdDriveTo = 0xF1,
	cmdDriveAxis = 0xF2,
	cmdStopDrive = 0xF3
}cmdWokrTypeDef;
/*********************************************************************************************/
/*********************************** FUNCTION PROTOTYPES *************************************/
/*********************************************************************************************/

//**************************** ІНФОРМАЦІЙНІ КОМАНДИ ****************************//

void cmdGetStatusACS (void);
void cmdGetUtcACS(void);
void cmdGetGpsAcs(void);
void cmdGetMinMaxSpeed(uint8_t axis);
void cmdGetSensorDirecrion(uint8_t axis);
void cmdGetSensorMultiply(uint8_t axis);
void cmdGetTemp(void);
void cmdGetSpRelayState(void);
void cmdGetDateNow(void);

//**************************** УСТАНОВОЧНІ КОМАНДИ ****************************//

void cmdLenzeSetMaxSpeed(uint8_t axis, uint8_t speed);
void cmdLenzeSetMinSpeed(uint8_t axis, uint8_t speed);
void cmdSensorChangeDir(uint8_t axis, uint8_t dir);
void cmdSensorSetMulti(uint8_t axis, uint16_t mull, uint16_t div);
void cmdSetSoftLimitSwitch(uint8_t axis, uint16_t lsOne, uint16_t lsTwo);
void cmdSetSensorAbsolutePos(uint8_t axis, uint16_t data);
void setSpRelayState(uint8_t relay);
void cmdSetDateNow(uint8_t day,uint8_t mouth, uint8_t year);

//***************************** ВИКОНАННЯ КОМАНДИ *****************************//

void moveAxis(uint8_t axis, uint8_t direction, uint8_t speed);
void stopAxis (uint8_t axis);
void driveCord(int32_t axisAz, int32_t axisEl, int32_t axisPol);

void protocollProcess(cmdUartTypeDef typeCmd, uint8_t cmd);

#endif /*PROTOCOL_H_*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/



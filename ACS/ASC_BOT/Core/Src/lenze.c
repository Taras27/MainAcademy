#include "lenze.h"


uint8_t lenzeRequest[8] = {0};

void lenzeChoiseAxis (uint8_t axis)
{
	switch(axis)
	{
		case lenzeAxisAz:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_3, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_4, GPIO_PIN_RESET);
		
			HAL_UART_Transmit(&huart2, lenzeRequest, sizeof(lenzeRequest), 100);
		
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_3, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_4, GPIO_PIN_SET);
			break;
		
		case lenzeAxisEl:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_3, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_4, GPIO_PIN_SET);
		
			HAL_UART_Transmit(&huart2, lenzeRequest, sizeof(lenzeRequest), 100);
		
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_3, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_4, GPIO_PIN_RESET);
			break;
	}
}

/*********************************************************
*																												*
*	return 32bit ->																				*
*	(sensorResponse[4] << 24)	->	error code							*
*	(sensorResponse[3] << 16)	->	actual direction				*
*	(sensorResponse[2] << 8)	->	actual speedH						*
*	sensorResponse[1]			->	actual speedL							*
*																												*
*********************************************************/

uint32_t getStatusLenze (uint8_t axis)
{	
	uint8_t lenzeResponse[17];
	uint16_t CS;
	uint32_t tmp = 0;
	
	lenzeRequest[0] = lenzeADDR;
	lenzeRequest[1] = lenzeFunCode03;
	lenzeRequest[2] = lenzeRegHi;
	lenzeRequest[3] = lenzeRegStateDrive;
	lenzeRequest[4] = 0x00;
	lenzeRequest[5] = 0x06;
	
	CS = CRC16(lenzeRequest, sizeof(lenzeRequest)-2);
	
	lenzeRequest[6] = (CS>>8) & 0xFF;
	lenzeRequest[7] = CS & 0xFF;
	
	lenzeChoiseAxis(axis);
	
	if (HAL_UART_Receive(&huart2, lenzeResponse, sizeof(lenzeResponse), 30) == HAL_OK )
	{
		CS = CRC16(lenzeResponse, sizeof(lenzeResponse)-2);
		uint16_t crcTmp = (lenzeResponse[15] << 8) + lenzeResponse[16];
		if(CS == crcTmp)
		{
			tmp = (lenzeResponse[13] << 24) + (lenzeResponse[9] << 16) 
				+ (lenzeResponse[5] << 8) + lenzeResponse[6];

			return tmp;
		}
		else
		{
			return 0xFFFFFFFF;
		}
	}
	else
	{
		return 0xFFFFFFFF;
	}
}
/*********************************************************/


/*********************************************************
*	Unlock Drive:														*
*																			*
*		SA		REG 	CMDH	CMDL	DH		DL		CRCH		CRCL	*
*		01 	06 	00	 	30 	00	 	00	 	XX			XX		*
*																			*
*		return 0x00 if no error										*
*		return 0xFF if some bad										*
*																			*
*********************************************************/
uint8_t lenzeUnlock(uint8_t axis)
{
	uint8_t lenzeResponse[8];
	uint16_t CS;
	
	lenzeRequest[0] = lenzeADDR;
	lenzeRequest[1] = lenzeFunCode06;
	lenzeRequest[2] = lenzeRegHi;
	lenzeRequest[3] = lenzeRegUnlockDrive;
	lenzeRequest[4] = 0x00;
	lenzeRequest[5] = 0x00;
	
	CS = CRC16(lenzeRequest, sizeof(lenzeRequest)-2);
	
	lenzeRequest[6] = (CS>>8) & 0xFF;
	lenzeRequest[7] = CS & 0xFF;
	
	lenzeChoiseAxis(axis);
	
	if (HAL_UART_Receive(&huart2, lenzeResponse, sizeof(lenzeResponse), 30) == HAL_OK )
	{
		uint16_t crcTmp = (lenzeResponse[6] << 8) + lenzeResponse[7];
		if(CS == crcTmp)
		{
			return 0;
		}
		else
		{
			return 0xFF;
		}
	}
	else
	{
		return 0xFF;
	}
}
/*********************************************************/

/*********************************************************
*	Start-Stop Drive:													*
*																			*
*		SA		REG 	CMDH	CMDL	DH		DL		CRCH		CRCL	*
*		01 	06 	00	 	01 	00	 	XX	 	XX			XX		*
*		DL = 0x04  Drive stop										*
*		DL = 0x08  Drive start										*
*																			*
*		axis: AZ 0x01 EL = 0x02										*
*		cmd:  START 0x00 STOP 0x01							*
*																			*
*		return 0x00 if no error										*
*		return 0xFF if some bad										*
*																			*
*********************************************************/
uint8_t lenzeStartStop (uint8_t axis, uint8_t cmd)
{
	uint8_t lenzeResponse[8];
	uint16_t CS;
	
	lenzeRequest[0] = lenzeADDR;
	lenzeRequest[1] = lenzeFunCode06;
	lenzeRequest[2] = lenzeRegHi;
	lenzeRequest[3] = lenzeRegManageDrive;
	lenzeRequest[4] = 0x00;
	if(cmd == cmdStart)
		lenzeRequest[5] = lenzeStartDrive;
	if(cmd == cmdStop)
		lenzeRequest[5] = lenzeStopDrive;
	
	CS = CRC16(lenzeRequest, sizeof(lenzeRequest)-2);
	
	lenzeRequest[6] = (CS>>8) & 0xFF;
	lenzeRequest[7] = CS & 0xFF;
	
	lenzeChoiseAxis(axis);
	
	if (HAL_UART_Receive(&huart2, lenzeResponse, sizeof(lenzeResponse), 30) == HAL_OK )
	{
		uint16_t crcTmp = (lenzeResponse[6] << 8) + lenzeResponse[7];
		if(CS == crcTmp)
		{
			return 0;
		}
		else
		{
			return 0xFF;
		}
	}
	else
	{
		return 0xFF;
	}
}
/*********************************************************/



/*********************************************************
*	Drive direction:													*
*																			*
*		SA		REG 	CMDH	CMDL	DH		DL		CRCH		CRCL	*
*		01 	06 	00	 	01 	00	 	XX	 	XX			XX		*
*		DL = 0x80  Direction forward								*
*		DL = 0x40  Direction reverse								*
*																			*
*		axis: AZ 0x01 EL = 0x02										*
*		cmd:  START 0x00 STOP 0x01									*
*																			*
*		return 0x00 if no error										*
*		return 0xFF if some bad										*
*																			*
*********************************************************/
uint8_t lenzeSetDirection (uint8_t axis, uint8_t cmd)
{
	uint8_t lenzeResponse[8];
	uint16_t CS;
	
	lenzeRequest[0] = lenzeADDR;
	lenzeRequest[1] = lenzeFunCode06;
	lenzeRequest[2] = lenzeRegHi;
	lenzeRequest[3] = lenzeRegManageDrive;
	lenzeRequest[4] = 0x00;
	if(cmd == cmdForward)
		lenzeRequest[5] = lenzeSetRotareForward;
	else if(cmd == cmdReverse)
		lenzeRequest[5] = lenzeSetRotateReverse;
	
	CS = CRC16(lenzeRequest, sizeof(lenzeRequest)-2);
	
	lenzeRequest[6] = (CS>>8) & 0xFF;
	lenzeRequest[7] = CS & 0xFF;
	
	lenzeChoiseAxis(axis);
	
	if (HAL_UART_Receive(&huart2, lenzeResponse, sizeof(lenzeResponse), 30) == HAL_OK )
	{
		uint16_t crcTmp = (lenzeResponse[6] << 8) + lenzeResponse[7];
		if(CS == crcTmp)
		{
			return 0;
		}
		else
		{
			return 0xFF;
		}
	}
	else
	{
		return 0xFF;
	}
}
/*********************************************************/


/*********************************************************
*	Drive speed:														*
*																			*
*		axis: AZ 0x01 EL = 0x02										*
*		speed:  0...255 Hz											*
*																			*
*		return 0x00 if no error										*
*		return 0xFF if some bad										*
*																			*
*********************************************************/
uint8_t lenzeSetSpeed (uint8_t axis, uint8_t speed)
{
	uint8_t lenzeResponse[8];
	uint16_t CS;
	uint16_t tmpSpeed = speed * 10;
	
	lenzeRequest[0] = lenzeADDR;
	lenzeRequest[1] = lenzeFunCode06;
	lenzeRequest[2] = lenzeRegHi;
	lenzeRequest[3] = lenzeRegSetDriveSpeed;
	lenzeRequest[4] = (tmpSpeed >> 8) & 0xFF;
	lenzeRequest[5] = tmpSpeed & 0xFF;
	
	CS = CRC16(lenzeRequest, sizeof(lenzeRequest)-2);
	
	lenzeRequest[6] = (CS>>8) & 0xFF;
	lenzeRequest[7] = CS & 0xFF;
	
	lenzeChoiseAxis(axis);
	
	if (HAL_UART_Receive(&huart2, lenzeResponse, sizeof(lenzeResponse), 30) == HAL_OK )
	{
		uint16_t crcTmp = (lenzeResponse[6] << 8) + lenzeResponse[7];
		if(CS == crcTmp)
		{
			return 0;
		}
		else
		{
			return 0xFF;
		}
	}
	else
	{
		return 0xFF;
	}	
}
/*********************************************************/


/*********************************************************
*	Set param:															*
*																			*
*		axis: AZ 0x01 EL = 0x02										*
*		direction: forward 0x00 reverse 0x01					*
*		speed:  0...255 Hz											*
*																			*
*		return 0x00 if no error										*
*		return 0xFF if some bad										*
*																			*
*********************************************************/

uint8_t lenzeDrive (uint8_t axis, uint8_t dir, uint8_t speed)
{
	if (lenzeUnlock(axis) == 0)
	{
		if( lenzeSetDirection(axis,dir) == 0)
		{
			if( lenzeSetSpeed(axis, speed) == 0)
			{
				if(lenzeStartStop(axis, cmdStart) == 0)
					{
						return 0;
					}
					else
					{
						return 0xFF;
					}
			}
			else
			{
				return 0xFF;
			}
		}
		else
		{
			return 0xFF;
		}
	}
	else
	{
		return 0xFF;
	}
}
/*********************************************************/

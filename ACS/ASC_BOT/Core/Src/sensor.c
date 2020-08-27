#include "sensor.h"

uint8_t bufSensor[3] = {0};
uint8_t counter=0;
HAL_StatusTypeDef UartStatus;

/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04		*
*																		*
*	cmd High: cmdHigh	0xFF											*
*																		*
*	cmd Low:		cmdSetOrigin				0x01					*
*					cmdSetAbsolutePosition		0x02					*
*					cmdReadMode					0x0B					*
*					cmdChangeMode				0x0D					*
*					cmdUnlock					0x2A					*
*					cmdGetMulti					0x34					*
*					cmdSetMulti					0x35					*
*********************************************************/
void sendRequest (uint8_t axis, uint16_t cmd)
{
	uint8_t dataH, dataL;
	dataL = cmd & 0xFF;
	dataH = (cmd>>8)& 0xFF;
	uint8_t buf[2];
	buf[0] = dataL;
	buf[1] = dataH;
	
	switch(axis)
	{
		case axisAZ:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_13 , GPIO_PIN_RESET);
			
			if(dataL == cmdPositionStatus)
			{
				HAL_UART_Transmit(&huart3, (uint8_t *)buf, 1,100);
			}
			else
			{
				HAL_UART_Transmit(&huart3, (uint8_t *)buf, sizeof(buf),100);
			}
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_13 , GPIO_PIN_SET);
			break;
			
		case axisEL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_13 , GPIO_PIN_RESET);
			
			if(dataL == cmdPositionStatus)
			{
				HAL_UART_Transmit(&huart3, (uint8_t *)buf, 1,100);
			}
			else
			{
				HAL_UART_Transmit(&huart3, (uint8_t *)buf, sizeof(buf),100);
			}
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_13 , GPIO_PIN_SET);
			break;
		
		case axisPOL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_13 , GPIO_PIN_RESET);
			
			if(dataL == cmdPositionStatus)
			{
				HAL_UART_Transmit(&huart3, (uint8_t *)buf, 1,100);
			}
			else
			{
				HAL_UART_Transmit(&huart3, (uint8_t *)buf, sizeof(buf),100);
			}
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_13 , GPIO_PIN_SET);
			break;
	}
}




/*********************************************************
*	cmd getPosition return data 0...65535						*
*	if error return value > 65535*								*
*********************************************************/
uint32_t getPosition (uint8_t axis)
{	
	uint16_t tmp=0;
	uint8_t CS;
	
#ifdef debug
	float sensorData=0;
#endif	
	
	sendRequest(axis, cmdPositionStatus); 

	if (HAL_UART_Receive(&huart3, bufSensor, sizeof(bufSensor), 60) == HAL_OK )
	{	
		CS = 0x2F ^ bufSensor[0] ^ bufSensor[1];
		CS = (CS ^ (CS >> 4)) & 0x0F;
		
		if(CS == bufSensor[2])
		{
			tmp = (bufSensor[0]<<8)+bufSensor[1];		
#ifdef debug
	sensorData = 0.00549 * tmp;
	printf("Sensor %d data: %.2f -> %05d -> CRC: %02d [CRC OK]\r\n",axis ,sensorData, tmp, CS);
#endif
			return tmp;
		}
	}
	else
	{
#ifdef debug
	printf("[CRC BAD]%d TMP->%d CS->%d\r\n", bufSensor[2], tmp, CS);
#endif
		uint32_t tmpReturn = 0x00FF0000;
#ifdef debug
	printf ("TMP RETURN = %d", tmpReturn);
#endif		
		return tmpReturn ;
	}
}


/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04	*
*********************************************************/
uint8_t unlockSensor(uint8_t axis)
{
	uint8_t sensorCS[1] = {0};
	uint8_t key = 0xA2;
	uint8_t unlockBuf[4] = {0};
	unlockBuf[0] = cmdHigh;
	unlockBuf[1] = cmdUnlock;
	unlockBuf[2] = key;
	uint8_t CS = unlockBuf[0] ^ unlockBuf[1] ^ unlockBuf[2];
	unlockBuf[3] = CS;
	
	switch(axis)
	{
		case axisAZ:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)unlockBuf, sizeof(unlockBuf),200);
		
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
		
		case axisEL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)unlockBuf, sizeof(unlockBuf),100);
		
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
		
		case axisPOL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)unlockBuf, sizeof(unlockBuf),100);
		
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
	}
	if (HAL_UART_Receive(&huart3, sensorCS, sizeof(sensorCS), 200) == HAL_OK )
	{
		if(sensorCS[0] == 0)
		{
#ifdef debug
	printf("CS = %d; sensorCS = %d \r\n", CS, sensorCS[0]);
#endif		
			return sensorCS[0];
		}
	}
	else
	{
#ifdef debug
	printf("[CRC BAD]\r\n");
#endif
	return 0xFF;
	}	
}



/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04	*
*********************************************************/
uint8_t setOrigin (uint8_t axis)
{
	uint8_t sensorResponse[1] = {0};
	uint16_t cmd = (cmdSetOrigin << 8) + cmdHigh;
	uint8_t CS = cmdHigh ^ cmdSetOrigin ^ 0x00;
	
	if (unlockSensor(axis) == 0)
	{
		sendRequest(axis, cmd);
		if (HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse), 200) == HAL_OK )
		{
			if(sensorResponse[0] == CS)
			{
				return 0;
			}
			else
			{
				return 0xFF; //error
			}
		}
		else
		{
			return 0xFF; //error
		}
	}
	else
	{
		return 0xFF; //error
	}	
}


/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04	*
*																			*
*	range newPosition 0...0xFFFF									*
*********************************************************/
uint8_t setAbsolutePosition (uint8_t axis, uint16_t newPosition)
{
	uint8_t sensorResponse[1] = {0};
	uint8_t sensorReq[4] = {0};
	uint8_t CS;
	
	sensorReq[0] = cmdHigh;
	sensorReq[1] = cmdSetAbsolutePosition;
	sensorReq[2] = (newPosition >> 8) & 0xFF;
	sensorReq[3] = newPosition & 0xFF;
	
	CS = cmdHigh ^ cmdSetAbsolutePosition ^ (newPosition >> 8) ^ (newPosition)	^ 0x00;
	
	if (unlockSensor(axis) == 0)
	{
		switch(axis)
		{
			case axisAZ:
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_SET);
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_RESET);
				
				HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 200);
				
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_RESET);
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_SET);			
				break;
				
			case axisEL:
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_SET);
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
				HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 200);
				
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_RESET);
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
				break;
			
			case axisPOL:
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_SET);
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
				
				HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 200);
				
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_RESET);
				HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
				break;
		}
		if (HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse), 200) == HAL_OK )
		{
			if(sensorResponse[0] == CS)
			{
#ifdef debug
	printf("[CRC OK] -> %d" , sensorResponse[0]); 
#endif
				return 0;
			}
			else
			{
				return sensorResponse[0];
			}
		}
	}	
}



/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04	*
*	return 0xFF if error 	if sucses return 0x00			*
*********************************************************/
uint8_t readModeSensor(uint8_t axis)
{
	uint8_t sensorResponse[2] = {0};
	uint16_t cmdTmp = (cmdReadMode << 8) + cmdHigh;
	sendRequest(axis, cmdTmp);

	/*UartStatus = HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse), 50);	*/

	if (HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse), 200) == HAL_OK )
		{
			uint8_t CS = cmdHigh ^ cmdReadMode ^ sensorResponse[0];
			if(sensorResponse[1] == CS)
			{
#ifdef debug
	printf("[CRC OK] -> MODE: %d", sensorResponse[1]);
#endif
				return sensorResponse[0];
			}
			else
			{
#ifdef debug
	printf("[CRC BAD] -> %d ", CS);
#endif
				return 0xFF;
			}
		}
	else
	{
#ifdef debug
	printf("[CRC BAD]");
#endif
		return 0xFF;
	}
}


/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04	*
*	return 0xFF if error 	if sucses return 0x00			*
*	mode 0 -> CW  1 -> CC											*
*********************************************************/

uint8_t changeModeSensor(uint8_t axis, uint8_t mode)
{
	
	uint8_t sensorResponse[1] = {0};
	uint8_t sensorReq[3];
	uint8_t CS;
	
	sensorReq[0] = cmdHigh;
	sensorReq[1] = cmdChangeMode;
	sensorReq[2] = mode;
	
	CS = cmdHigh ^ cmdChangeMode ^ mode ^ 0x00;
	
	if(unlockSensor(axis) == 0)
	{
		switch(axis)
		{
		case axisAZ:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 500);
			
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
			
		case axisEL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 500);
			
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
		
		case axisPOL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 500);
			
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
		}
		
		if (HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse), 200) == HAL_OK )
		{
			if(CS == sensorResponse[0])
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

/*********************************************************
*	axis:		axisAZ 	0x01	axisEL 	0x02	axisPOL 	0x04	*
*	return 32bit ->													*
*	MulH = (sensorResponse[4] << 24)								*
*	MulL = (sensorResponse[3] << 16)								*
*	DivH = (sensorResponse[2] << 8)								*
*	DivL = sensorResponse[1]										*
*																			*
*********************************************************/

uint32_t getMulti(uint8_t axis)
{
	uint8_t sensorResponse[5] = {0};
	uint8_t CS;
	uint16_t cmd = (cmdGetMulti << 8) + cmdHigh;
	uint32_t tmp;
	
	sendRequest(axis, cmd);
	
	if (HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse), 200) == HAL_OK )
	{
		CS = sensorResponse[3] ^ sensorResponse[2] ^ sensorResponse[1] ^ sensorResponse[0];
		if( CS == sensorResponse[4])
		{
			tmp = (sensorResponse[0] << 24) + (sensorResponse[1] << 16) + (sensorResponse[2] << 8) +  sensorResponse[3];
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

uint8_t setMulti (uint8_t axis, uint16_t mul, uint16_t div)
{
	uint8_t sensorResponse[1] = {0};
	uint8_t sensorReq[7];
	uint8_t CS;
	
	sensorReq[0] = cmdHigh;
	sensorReq[1] = cmdSetMulti;
	sensorReq[2] = (mul >> 8);
	sensorReq[3] = mul & 0xFF;
	sensorReq[4] = (div >> 8);
	sensorReq[5] = div & 0xFF;
	
	CS = sensorReq[0] ^ sensorReq[1] ^ sensorReq[2] ^ sensorReq[3] ^ sensorReq[4] ^ sensorReq[5];
	
	sensorReq[6] = CS;
	
	if(unlockSensor(axis) == 0)
	{
		switch(axis)
		{
		case axisAZ:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 500);
			
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_12, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
			
		case axisEL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 500);
			
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
		
		case axisPOL:
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_SET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_RESET);
			
			HAL_UART_Transmit(&huart3, (uint8_t *)sensorReq, sizeof(sensorReq), 500);
			
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10, GPIO_PIN_RESET);
			HAL_GPIO_WritePin(GPIOD, GPIO_PIN_11 | GPIO_PIN_12 | GPIO_PIN_15 , GPIO_PIN_SET);			
			break;
		}
		
		if (HAL_UART_Receive(&huart3, sensorResponse, sizeof(sensorResponse),200) == HAL_OK )
		{
			if(sensorResponse[0] == 0)
			{
				return 0;
			}
			else
			{
				return sensorResponse[0]; //return error code
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

#include "windSensor.h"

uint8_t windRequest[] = {0x01, 0x03, 0x00, 0x16, 0x00, 0x01, 0x65, 0xCE};
uint8_t windResponce[7] = {0};
HAL_StatusTypeDef resWind;

//returned vulue not more 300
// if returned value more 0xFFFF
// this is error or sensor is disconnected

void windSensorWriteEn(void)
{
	HAL_GPIO_WritePin(GPIOD, GPIO_PIN_13, GPIO_PIN_SET);
	HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_12 , GPIO_PIN_RESET);	
}

void windSensorReadEn(void)
{
	HAL_GPIO_WritePin(GPIOD, GPIO_PIN_13, GPIO_PIN_RESET);
	HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10 | GPIO_PIN_11 | GPIO_PIN_12 , GPIO_PIN_SET);	
}

uint8_t getWindSpeed(WIND_SensorTypeDef *sensor)
{
	windSensorWriteEn();
	resWind = HAL_UART_Transmit(&huart3, windRequest, sizeof(windRequest), 30);
	
	if(resWind == HAL_OK)
	{
		windSensorReadEn();
		resWind = HAL_UART_Receive(&huart3, windResponce, sizeof(windResponce), 100);
		if(resWind == HAL_OK)
		{
			uint16_t CrcTemp = CRC16(windResponce, sizeof(windResponce)-2);
			uint16_t Crc = windResponce[5]<<8|windResponce[6];
			
			if(CrcTemp == Crc)
			{
				sensor->Speed = windResponce[3]<<8|windResponce[4];
				sensor->Status = WIND_SENSOR_OK;
			}
			else
			{
				sensor->Speed = 0xFFFF;
				sensor->Status = WIND_SENSOR_BAD_CRC;
				return WIND_SENSOR_BAD_CRC;
			}						
		}
		else
		{
			sensor->Speed = 0xFFFF;
			sensor->Status = WIND_SENSOR_ERROR;
			return WIND_SENSOR_ERROR;
		}
	}
	else
	{
		sensor->Speed = 0xFFFF;
		sensor->Status = WIND_SENSOR_TIMEOUT;
		return WIND_SENSOR_TIMEOUT;
	}	
	return WIND_SENSOR_OK;
}

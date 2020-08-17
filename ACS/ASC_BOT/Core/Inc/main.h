/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.h
  * @brief          : Header for main.c file.
  *                   This file contains the common defines of the application.
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2020 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under Ultimate Liberty license
  * SLA0044, the "License"; You may not use this file except in compliance with
  * the License. You may obtain a copy of the License at:
  *                             www.st.com/SLA0044
  *
  ******************************************************************************
  */
/* USER CODE END Header */

/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __MAIN_H
#define __MAIN_H

#ifdef __cplusplus
extern "C" {
#endif

/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx_hal.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */

/* USER CODE END Includes */

/* Exported types ------------------------------------------------------------*/
/* USER CODE BEGIN ET */

/* USER CODE END ET */

/* Exported constants --------------------------------------------------------*/
/* USER CODE BEGIN EC */

/* USER CODE END EC */

/* Exported macro ------------------------------------------------------------*/
/* USER CODE BEGIN EM */

/* USER CODE END EM */

void HAL_TIM_MspPostInit(TIM_HandleTypeDef *htim);

/* Exported functions prototypes ---------------------------------------------*/
void Error_Handler(void);

/* USER CODE BEGIN EFP */

/* USER CODE END EFP */

/* Private defines -----------------------------------------------------------*/
/* USER CODE BEGIN Private defines */

#define FLASH_KEY	0xAA

/********************************GPIO DEFINES********************************/
#define ExternalRelayOneOn()		HAL_GPIO_WritePin(GPIOA,GPIO_PIN_7,GPIO_PIN_SET)
#define ExternalRelayOneOff()		HAL_GPIO_WritePin(GPIOA,GPIO_PIN_7,GPIO_PIN_RESET)

#define ExternalRelayTwoOn()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_4,GPIO_PIN_SET)
#define ExternalRelayTwoOff()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_4,GPIO_PIN_RESET)

#define ExternalRelayThreeOn()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_5,GPIO_PIN_SET)
#define ExternalRelayThreeOff()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_5,GPIO_PIN_RESET)

#define SpRelayAOn()				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_10,GPIO_PIN_SET)
#define SpRelayAOff()				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_10,GPIO_PIN_RESET)

#define SpRelayBOn()				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_11,GPIO_PIN_SET)
#define SpRelayBOff()				HAL_GPIO_WritePin(GPIOB,GPIO_PIN_11,GPIO_PIN_RESET)

#define SdLedOn()					HAL_GPIO_WritePin(GPIOD,GPIO_PIN_0,GPIO_PIN_SET)
#define SdLedOff()					HAL_GPIO_WritePin(GPIOD,GPIO_PIN_0,GPIO_PIN_RESET)

/**************************************************************************/

#define DEFAULT_VALUE 0
#define MIN_SPEED 10
#define MAX_SPEED 90
#define SOFT_LIMIT_DEFAULT_VALUE 0

/******************************** STRUCTS ********************************/

typedef struct
{
	int16_t insideTemperature;
	int16_t outsideTemperature;
	uint8_t outsideHumidity;
}temperatureDataTypeDef;

typedef struct
{
	uint32_t azData;
	int32_t elData;
	int32_t polData;
	uint16_t windData;
}sensorDataTypeDef;

typedef struct
{
	uint32_t azLenzeData;
	uint32_t elLenzeData;
	uint32_t polData;
}driveDataTypeDef;

typedef struct
{
	uint8_t minSpeed;
	uint8_t maxSpeed;
}driveSpeedTypeDef;

typedef struct
{
	int32_t softLimitsTop;
	int32_t softLimitsBottom;
	int32_t softLimitsLeft;
	int32_t softLimitsRight;
}swLimitSwitchTypeDef;

typedef struct
{
	uint32_t writeCount;

	int32_t gpsLatitude;
	int32_t gpsLongtitude;
	int32_t gpsAltitude;

	int32_t softLimitsTop;
	int32_t softLimitsBottom;
	int32_t softLimitsLeft;
	int32_t softLimitsRight;

	uint8_t lenzeAzMinSpeed;
	uint8_t lenzeAzMaxSpeed;

	uint8_t lenzeElMinSpeed;
	uint8_t lenzeElMaxSpeed;

	uint8_t polMinSpeed;
	uint8_t polMaxSpeed;

	uint8_t dateYear;
	uint8_t dateMonth;
	uint8_t dateDate;

	uint8_t key;
}userSettingsTypeDef;



/********************************DELAY DEFINES********************************/



/* USER CODE END Private defines */

#ifdef __cplusplus
}
#endif

#endif /* __MAIN_H */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

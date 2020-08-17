/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
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
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "fatfs.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "lenze.h"
#include "sensor.h"
#include "windSensor.h"
#include "protocol.h"
#include "drivePol.h"
#include "stdio.h"
#include "stdlib.h"
#include "string.h"
#include "stdint.h"
#include "gps.h"
#include "externalRelay.h"
#include "limitSwitch.h"
#include "am2302.h"
#include "ds18b20.h"
#include "minmea.h"
#include "rtc.h"
#include "sd.h"
#include "goto.h"
#include "flash.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
RTC_HandleTypeDef hrtc;

SD_HandleTypeDef hsd;

TIM_HandleTypeDef htim9;
TIM_HandleTypeDef htim12;
TIM_HandleTypeDef htim13;
TIM_HandleTypeDef htim14;

UART_HandleTypeDef huart1;
UART_HandleTypeDef huart2;
UART_HandleTypeDef huart3;
UART_HandleTypeDef huart6;

/* USER CODE BEGIN PV */

//********************** SAVE SETTING **********************//
userSettingsTypeDef defaulSetting = {
		  DEFAULT_VALUE,
		  DEFAULT_VALUE, DEFAULT_VALUE, DEFAULT_VALUE,
		  SOFT_LIMIT_DEFAULT_VALUE, SOFT_LIMIT_DEFAULT_VALUE, SOFT_LIMIT_DEFAULT_VALUE, SOFT_LIMIT_DEFAULT_VALUE,
		  MIN_SPEED, MAX_SPEED,
		  MIN_SPEED, MAX_SPEED,
		  MIN_SPEED, MAX_SPEED,
		  DEFAULT_VALUE, DEFAULT_VALUE, DEFAULT_VALUE,
		  FLASH_KEY
};
userSettingsTypeDef workingSetting;
userSettingsTypeDef flashCopySetting;

//********************** RELAY **********************//
eRelay relay=spRelayNone;
eRelayState relayState = relayOFF;
uint8_t statusRelay=0;

//********************** TEMPERATURE SENSOR **********************//

am2302TypeDef tempAM2302;
temperatureDataTypeDef temperarure;

//********************** WIND SENSOR **********************//

WIND_SensorTypeDef windSpeed;

//********************** ENCODER **********************//

sensorDataTypeDef sensorData;


//********************** LIMIT SWITCH **********************//

extern uint8_t hardLimitSwitchStatus;
extern uint8_t softLimitSwitchStatus;
swLimitSwitchTypeDef softwareLimitSwitch;


//********************** GPS **********************//

uint8_t gpsBuf[80] = {0};
uint8_t tmpGpsBuf[80] = {0};
gpsDataTypeDef gpsData;

int32_t gpsLatitude, gpsLongtitude;

//********************** LENZE **********************//

driveDataTypeDef driveStatus;
driveSpeedTypeDef speedAz, speedEl, speedPol;

//********************** SD CARD **********************//

char bufferSD[50]={0};
char sdBufferFolderName[30] = {0};
char sdFolderName[] = {"windData"};
char sdFileName[12] = {0};
extern char SDPath[4];
extern FRESULT fResult;  	// result
extern FIL file;

//********************** RTC **********************//

extern RTC_TimeTypeDef timeRTC;
extern RTC_DateTypeDef dateRTC;

//********************** UART1 **********************//

uint8_t uart1Buf[30] = { 0 };
uint8_t tmpUart1Buf[30] = { 0 };

//********************** GLOBAL COUNTER **********************//

uint32_t counterMs=0;



uint16_t tmpSpeedAz = 0;
uint16_t tmpSpeedEl = 0;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_RTC_Init(void);
static void MX_SDIO_SD_Init(void);
static void MX_TIM9_Init(void);
static void MX_TIM14_Init(void);
static void MX_USART1_UART_Init(void);
static void MX_USART2_UART_Init(void);
static void MX_USART3_UART_Init(void);
static void MX_USART6_UART_Init(void);
static void MX_TIM12_Init(void);
static void MX_TIM13_Init(void);
/* USER CODE BEGIN PFP */

int _write(int file, char *ptr, int len)
{
  /* Implement your write code here, this is used by puts and printf for example */
  int i=0;
  for(i=0 ; i<len ; i++)
    ITM_SendChar((*ptr++));
  return len;
}

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */

/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_RTC_Init();
  MX_SDIO_SD_Init();
  MX_TIM9_Init();
  MX_TIM14_Init();
  MX_USART1_UART_Init();
  MX_USART2_UART_Init();
  MX_USART3_UART_Init();
  MX_USART6_UART_Init();
  MX_TIM12_Init();
  MX_TIM13_Init();
  MX_FATFS_Init();
  /* USER CODE BEGIN 2 */

  HAL_TIM_Base_Start_IT(&htim14);
  HAL_TIM_Base_Start_IT(&htim13);
  HAL_UART_Receive_IT(&huart6,tmpGpsBuf,sizeof(tmpGpsBuf));
  HAL_UART_Receive_IT(&huart1, tmpUart1Buf, sizeof(tmpUart1Buf));
  initAM2302();
  ds18b20Init(DS18B20_Resolution_9_bit);

  if(mountSD(SDPath)!=FR_OK)
  		SdLedOn();
  	else
  		SdLedOff();

  uint8_t counterTemperature = 0;
  uint8_t counterFlashWrite = 0;

/*  uint8_t counterSensorStatus = 0;
  uint8_t counterLenzeStatus = 0;*/

  readFlash(&workingSetting);

  //*********************************************//
  softwareLimitSwitch.softLimitsBottom = workingSetting.softLimitsBottom;
  softwareLimitSwitch.softLimitsLeft = workingSetting.softLimitsLeft;
  softwareLimitSwitch.softLimitsRight = workingSetting.softLimitsRight;
  softwareLimitSwitch.softLimitsTop = workingSetting.softLimitsTop;
  //*********************************************//

  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
	  counterMs = 0;

	  workingSetting.softLimitsTop = softwareLimitSwitch.softLimitsTop;
	  workingSetting.softLimitsBottom = softwareLimitSwitch.softLimitsBottom;
	  workingSetting.softLimitsLeft = softwareLimitSwitch.softLimitsLeft;
	  workingSetting.softLimitsRight = softwareLimitSwitch.softLimitsRight;

	  if((gpsData.dataValid == VALID_DATA) && ((gpsData.time.minutes%1) == 0)&&(gpsData.time.seconds == 1))
	  {
		  setTime(gpsData.time.hours,gpsData.time.minutes,gpsData.time.seconds);
	  }
	  else
	  {
		  HAL_RTC_GetTime(&hrtc, &timeRTC, RTC_FORMAT_BIN);
		  HAL_RTC_GetDate(&hrtc, &dateRTC, RTC_FORMAT_BIN);
	  }

	  if((timeRTC.Seconds % 5 ) == 0)
		  getWindSpeed(&windSpeed);

	  if((timeRTC.Minutes % 1 ) == 0 && (timeRTC.Seconds == 10))
	  {
		  if(counterTemperature == 0)
		  {
			  temperarure.insideTemperature = ds18b20_getTemperature();
			  getSensorData(&tempAM2302);
		  }
		  if(tempAM2302.sensorState == CONNECTED)
		  {
			  temperarure.outsideTemperature = tempAM2302.temperature;
			  temperarure.outsideHumidity = tempAM2302.humidity;
		  }
		  else
		  {
			  temperarure.outsideTemperature = 0;
			  temperarure.outsideHumidity = 0;
		  }
		  counterTemperature++;
	  }
	  else
		  counterTemperature=0;

	  if(getPosition(axisAZ) > 0xFFFF)
		  sensorData.azData = 0xFF0000;
	  else
		  sensorData.azData = ((uint32_t)(((float)getPosition(axisAZ)*0.00549)*100));

	  if(getPosition(axisEL) > 0xFFFF)
		  sensorData.elData = 0xFF0000;
	  else
		  sensorData.elData = ((int32_t)((((float)getPosition(axisEL)*0.00549)*100)-18000)  & 0xFFFF);

	  if(getPosition(axisPOL) > 0xFFFF)
		  sensorData.polData = 0xFF0000;
	  else
		  sensorData.polData = ((int32_t)((((float)getPosition(axisPOL)*0.00549)*100)-18000) & 0xFFFF);

	  if(windSpeed.Status == WIND_SENSOR_OK)
		  sensorData.windData = windSpeed.Speed;
	  else
		  sensorData.windData = 0xFFFF;

	  tmpSpeedAz = (((driveStatus.azLenzeData >> 8) & 0xFF) << 8) +  (driveStatus.azLenzeData & 0xFF);
	  tmpSpeedEl = (((driveStatus.elLenzeData >> 8) & 0xFF) << 8) +  (driveStatus.elLenzeData & 0xFF);

	  if(((hardLimitSwitchStatus & limitSwitchRight )||(softLimitSwitchStatus & limitSwitchRight))
			  && (((driveStatus.azLenzeData & 0x00FF0000) >> 16) == cmdDirectionCC) && (tmpSpeedAz > 0))
	  {
		  lenzeStartStop(axisAZ, cmdStop);
	  }

	  if(((hardLimitSwitchStatus & limitSwitchLeft )||(softLimitSwitchStatus & limitSwitchLeft))
	 			  && (((driveStatus.azLenzeData & 0x00FF0000) >> 16) == cmdDirectionCCW) && (tmpSpeedAz > 0))
	  {
		  lenzeStartStop(axisAZ, cmdStop);
	  }

	  if(((hardLimitSwitchStatus & limitSwitchBottom )||(softLimitSwitchStatus & limitSwitchBottom))
	 			  && (((driveStatus.elLenzeData & 0x00FF0000) >> 16) == cmdDirectionCC) && (tmpSpeedEl > 0))
	 {
		  lenzeStartStop(axisEL, cmdStop);
	 }

	 if(((hardLimitSwitchStatus & limitSwitchTop )||(softLimitSwitchStatus & limitSwitchTop))
	 	 			  && (((driveStatus.elLenzeData & 0x00FF0000) >> 16) == cmdDirectionCCW) && (tmpSpeedEl > 0))
	 {
		 lenzeStartStop(axisEL, cmdStop);
	 }

	  sdProcess(&dateRTC, &timeRTC, &sensorData);

	  getDataGPS(&gpsData, (char*)gpsBuf);

	  if(gpsData.dataValid == VALID_DATA)
	  {
		  gpsLatitude = (int32_t)((float)getCordinate(&gpsData, 0x01)*1000000);
		  gpsLongtitude = (int32_t)((float)getCordinate(&gpsData, 0x02)*1000000);
	  }

	  driveStatus.azLenzeData  = getStatusLenze(lenzeAxisAz);

	  driveStatus.elLenzeData  = getStatusLenze(lenzeAxisEl);

	  driveStatus.polData = polStatus();

	  if((timeRTC.Minutes % 1 ) == 0 && (timeRTC.Seconds == 10))
	  {
		  if(counterFlashWrite == 0)
			  flashProcess(&workingSetting);
		  else
			  counterFlashWrite++;
	  }
	  else
		  counterFlashWrite=0;

	  HAL_Delay(150);

	/*cmdGetStatusACS();*/
  /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInitStruct = {0};

  /** Configure the main internal regulator output voltage
  */
  __HAL_RCC_PWR_CLK_ENABLE();
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE1);
  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_LSI|RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.LSIState = RCC_LSI_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 4;
  RCC_OscInitStruct.PLL.PLLN = 168;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 8;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV4;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_5) != HAL_OK)
  {
    Error_Handler();
  }
  PeriphClkInitStruct.PeriphClockSelection = RCC_PERIPHCLK_RTC;
  PeriphClkInitStruct.RTCClockSelection = RCC_RTCCLKSOURCE_LSI;
  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief RTC Initialization Function
  * @param None
  * @retval None
  */
static void MX_RTC_Init(void)
{

  /* USER CODE BEGIN RTC_Init 0 */

  /* USER CODE END RTC_Init 0 */

  RTC_TimeTypeDef sTime = {0};
  RTC_DateTypeDef sDate = {0};
  RTC_AlarmTypeDef sAlarm = {0};

  /* USER CODE BEGIN RTC_Init 1 */

  /* USER CODE END RTC_Init 1 */
  /** Initialize RTC Only
  */
  hrtc.Instance = RTC;
  hrtc.Init.HourFormat = RTC_HOURFORMAT_24;
  hrtc.Init.AsynchPrediv = 127;
  hrtc.Init.SynchPrediv = 255;
  hrtc.Init.OutPut = RTC_OUTPUT_DISABLE;
  hrtc.Init.OutPutPolarity = RTC_OUTPUT_POLARITY_HIGH;
  hrtc.Init.OutPutType = RTC_OUTPUT_TYPE_OPENDRAIN;
  if (HAL_RTC_Init(&hrtc) != HAL_OK)
  {
    Error_Handler();
  }

  /* USER CODE BEGIN Check_RTC_BKUP */
    
  /* USER CODE END Check_RTC_BKUP */

  /** Initialize RTC and set the Time and Date
  */
/*  sTime.Hours = 0;
  sTime.Minutes = 0;
  sTime.Seconds = 0;
  sTime.DayLightSaving = RTC_DAYLIGHTSAVING_NONE;
  sTime.StoreOperation = RTC_STOREOPERATION_RESET;
  if (HAL_RTC_SetTime(&hrtc, &sTime, RTC_FORMAT_BIN) != HAL_OK)
  {
    Error_Handler();
  }
  sDate.WeekDay = RTC_WEEKDAY_MONDAY;
  sDate.Month = RTC_MONTH_JULY;
  sDate.Date = 20;
  sDate.Year = 20;

  if (HAL_RTC_SetDate(&hrtc, &sDate, RTC_FORMAT_BIN) != HAL_OK)
  {
    Error_Handler();
  }*/
  /** Enable the Alarm A
  */
  sAlarm.AlarmTime.Hours = 0;
  sAlarm.AlarmTime.Minutes = 0;
  sAlarm.AlarmTime.Seconds = 0;
  sAlarm.AlarmTime.SubSeconds = 0;
  sAlarm.AlarmTime.DayLightSaving = RTC_DAYLIGHTSAVING_NONE;
  sAlarm.AlarmTime.StoreOperation = RTC_STOREOPERATION_RESET;
  sAlarm.AlarmMask = RTC_ALARMMASK_NONE;
  sAlarm.AlarmSubSecondMask = RTC_ALARMSUBSECONDMASK_ALL;
  sAlarm.AlarmDateWeekDaySel = RTC_ALARMDATEWEEKDAYSEL_DATE;
  sAlarm.AlarmDateWeekDay = 1;
  sAlarm.Alarm = RTC_ALARM_A;
  if (HAL_RTC_SetAlarm_IT(&hrtc, &sAlarm, RTC_FORMAT_BIN) != HAL_OK)
  {
    Error_Handler();
  }
  /** Enable the Alarm B
  */
  sAlarm.AlarmDateWeekDay = 1;
  sAlarm.Alarm = RTC_ALARM_B;
  if (HAL_RTC_SetAlarm_IT(&hrtc, &sAlarm, RTC_FORMAT_BIN) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN RTC_Init 2 */

  /* USER CODE END RTC_Init 2 */

}

/**
  * @brief SDIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_SDIO_SD_Init(void)
{

  /* USER CODE BEGIN SDIO_Init 0 */

  /* USER CODE END SDIO_Init 0 */

  /* USER CODE BEGIN SDIO_Init 1 */

  /* USER CODE END SDIO_Init 1 */
  hsd.Instance = SDIO;
  hsd.Init.ClockEdge = SDIO_CLOCK_EDGE_RISING;
  hsd.Init.ClockBypass = SDIO_CLOCK_BYPASS_DISABLE;
  hsd.Init.ClockPowerSave = SDIO_CLOCK_POWER_SAVE_DISABLE;
  hsd.Init.BusWide = SDIO_BUS_WIDE_1B;
  hsd.Init.HardwareFlowControl = SDIO_HARDWARE_FLOW_CONTROL_DISABLE;
  hsd.Init.ClockDiv = 6;
  /* USER CODE BEGIN SDIO_Init 2 */

  /* USER CODE END SDIO_Init 2 */

}

/**
  * @brief TIM9 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM9_Init(void)
{

  /* USER CODE BEGIN TIM9_Init 0 */

  /* USER CODE END TIM9_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_OC_InitTypeDef sConfigOC = {0};

  /* USER CODE BEGIN TIM9_Init 1 */

  /* USER CODE END TIM9_Init 1 */
  htim9.Instance = TIM9;
  htim9.Init.Prescaler = 30;
  htim9.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim9.Init.Period = 100;
  htim9.Init.ClockDivision = TIM_CLOCKDIVISION_DIV4;
  htim9.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim9) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim9, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  if (HAL_TIM_PWM_Init(&htim9) != HAL_OK)
  {
    Error_Handler();
  }
  sConfigOC.OCMode = TIM_OCMODE_PWM1;
  sConfigOC.Pulse = 0;
  sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
  sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;
  if (HAL_TIM_PWM_ConfigChannel(&htim9, &sConfigOC, TIM_CHANNEL_1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM9_Init 2 */

  /* USER CODE END TIM9_Init 2 */
  HAL_TIM_MspPostInit(&htim9);

}

/**
  * @brief TIM12 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM12_Init(void)
{

  /* USER CODE BEGIN TIM12_Init 0 */

  /* USER CODE END TIM12_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};

  /* USER CODE BEGIN TIM12_Init 1 */

  /* USER CODE END TIM12_Init 1 */
  htim12.Instance = TIM12;
  htim12.Init.Prescaler = 8399;
  htim12.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim12.Init.Period = 2000;
  htim12.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim12.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim12) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim12, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM12_Init 2 */

  /* USER CODE END TIM12_Init 2 */

}

/**
  * @brief TIM13 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM13_Init(void)
{

  /* USER CODE BEGIN TIM13_Init 0 */

  /* USER CODE END TIM13_Init 0 */

  /* USER CODE BEGIN TIM13_Init 1 */

  /* USER CODE END TIM13_Init 1 */
  htim13.Instance = TIM13;
  htim13.Init.Prescaler = 7999;
  htim13.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim13.Init.Period = 200;
  htim13.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim13.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim13) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM13_Init 2 */

  /* USER CODE END TIM13_Init 2 */

}

/**
  * @brief TIM14 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM14_Init(void)
{

  /* USER CODE BEGIN TIM14_Init 0 */

  /* USER CODE END TIM14_Init 0 */

  /* USER CODE BEGIN TIM14_Init 1 */

  /* USER CODE END TIM14_Init 1 */
  htim14.Instance = TIM14;
  htim14.Init.Prescaler = 7999;
  htim14.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim14.Init.Period = 200;
  htim14.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim14.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim14) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM14_Init 2 */

  /* USER CODE END TIM14_Init 2 */

}

/**
  * @brief USART1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART1_UART_Init(void)
{

  /* USER CODE BEGIN USART1_Init 0 */

  /* USER CODE END USART1_Init 0 */

  /* USER CODE BEGIN USART1_Init 1 */

  /* USER CODE END USART1_Init 1 */
  huart1.Instance = USART1;
  huart1.Init.BaudRate = 115200;
  huart1.Init.WordLength = UART_WORDLENGTH_8B;
  huart1.Init.StopBits = UART_STOPBITS_1;
  huart1.Init.Parity = UART_PARITY_NONE;
  huart1.Init.Mode = UART_MODE_TX_RX;
  huart1.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart1.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART1_Init 2 */

  /* USER CODE END USART1_Init 2 */

}

/**
  * @brief USART2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART2_UART_Init(void)
{

  /* USER CODE BEGIN USART2_Init 0 */

  /* USER CODE END USART2_Init 0 */

  /* USER CODE BEGIN USART2_Init 1 */

  /* USER CODE END USART2_Init 1 */
  huart2.Instance = USART2;
  huart2.Init.BaudRate = 115200;
  huart2.Init.WordLength = UART_WORDLENGTH_8B;
  huart2.Init.StopBits = UART_STOPBITS_1;
  huart2.Init.Parity = UART_PARITY_NONE;
  huart2.Init.Mode = UART_MODE_TX_RX;
  huart2.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart2.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart2) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART2_Init 2 */

  /* USER CODE END USART2_Init 2 */

}

/**
  * @brief USART3 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART3_UART_Init(void)
{

  /* USER CODE BEGIN USART3_Init 0 */

  /* USER CODE END USART3_Init 0 */

  /* USER CODE BEGIN USART3_Init 1 */

  /* USER CODE END USART3_Init 1 */
  huart3.Instance = USART3;
  huart3.Init.BaudRate = 9600;
  huart3.Init.WordLength = UART_WORDLENGTH_8B;
  huart3.Init.StopBits = UART_STOPBITS_1;
  huart3.Init.Parity = UART_PARITY_NONE;
  huart3.Init.Mode = UART_MODE_TX_RX;
  huart3.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart3.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart3) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART3_Init 2 */

  /* USER CODE END USART3_Init 2 */

}

/**
  * @brief USART6 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART6_UART_Init(void)
{

  /* USER CODE BEGIN USART6_Init 0 */

  /* USER CODE END USART6_Init 0 */

  /* USER CODE BEGIN USART6_Init 1 */

  /* USER CODE END USART6_Init 1 */
  huart6.Instance = USART6;
  huart6.Init.BaudRate = 9600;
  huart6.Init.WordLength = UART_WORDLENGTH_8B;
  huart6.Init.StopBits = UART_STOPBITS_1;
  huart6.Init.Parity = UART_PARITY_NONE;
  huart6.Init.Mode = UART_MODE_RX;
  huart6.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart6.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart6) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART6_Init 2 */

  /* USER CODE END USART6_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOC_CLK_ENABLE();
  __HAL_RCC_GPIOH_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOE_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();
  __HAL_RCC_GPIOD_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, GPIO_PIN_1|GPIO_PIN_7|GPIO_PIN_11, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOC, GPIO_PIN_4|GPIO_PIN_5, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOB, GPIO_PIN_10|GPIO_PIN_11|GPIO_PIN_12|GPIO_PIN_13
                          |GPIO_PIN_8|GPIO_PIN_9, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOB, GPIO_PIN_14, GPIO_PIN_SET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOD, GPIO_PIN_10|GPIO_PIN_11|GPIO_PIN_12|GPIO_PIN_13
                          |GPIO_PIN_0|GPIO_PIN_3|GPIO_PIN_4, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, GPIO_PIN_8, GPIO_PIN_SET);

  /*Configure GPIO pin : PA1 */
  GPIO_InitStruct.Pin = GPIO_PIN_1;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_PULLDOWN;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_MEDIUM;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : PA4 PA5 PA6 PA15 */
  GPIO_InitStruct.Pin = GPIO_PIN_4|GPIO_PIN_5|GPIO_PIN_6|GPIO_PIN_15;
  GPIO_InitStruct.Mode = GPIO_MODE_INPUT;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : PA7 PA11 */
  GPIO_InitStruct.Pin = GPIO_PIN_7|GPIO_PIN_11;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : PC4 PC5 */
  GPIO_InitStruct.Pin = GPIO_PIN_4|GPIO_PIN_5;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_PULLDOWN;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_MEDIUM;
  HAL_GPIO_Init(GPIOC, &GPIO_InitStruct);

  /*Configure GPIO pins : PE8 PE9 PE10 PE11
                           PE12 PE13 PE14 PE15 */
  GPIO_InitStruct.Pin = GPIO_PIN_8|GPIO_PIN_9|GPIO_PIN_10|GPIO_PIN_11
                          |GPIO_PIN_12|GPIO_PIN_13|GPIO_PIN_14|GPIO_PIN_15;
  GPIO_InitStruct.Mode = GPIO_MODE_INPUT;
  GPIO_InitStruct.Pull = GPIO_PULLDOWN;
  HAL_GPIO_Init(GPIOE, &GPIO_InitStruct);

  /*Configure GPIO pins : PB10 PB11 PB12 PB13
                           PB8 PB9 */
  GPIO_InitStruct.Pin = GPIO_PIN_10|GPIO_PIN_11|GPIO_PIN_12|GPIO_PIN_13
                          |GPIO_PIN_8|GPIO_PIN_9;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_PULLDOWN;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

  /*Configure GPIO pin : PB14 */
  GPIO_InitStruct.Pin = GPIO_PIN_14;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_OD;
  GPIO_InitStruct.Pull = GPIO_PULLUP;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

  /*Configure GPIO pins : PD10 PD11 PD12 PD13 */
  GPIO_InitStruct.Pin = GPIO_PIN_10|GPIO_PIN_11|GPIO_PIN_12|GPIO_PIN_13;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_PULLDOWN;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOD, &GPIO_InitStruct);

  /*Configure GPIO pin : PA8 */
  GPIO_InitStruct.Pin = GPIO_PIN_8;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_OD;
  GPIO_InitStruct.Pull = GPIO_PULLUP;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : PD0 PD3 PD4 */
  GPIO_InitStruct.Pin = GPIO_PIN_0|GPIO_PIN_3|GPIO_PIN_4;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOD, &GPIO_InitStruct);

}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback (UART_HandleTypeDef *huart)
{
	if(huart == &huart6)
	{
		if(huart6.ErrorCode == 0)
		{
			uint8_t size = strlen((char*)tmpGpsBuf);
			HAL_UART_AbortReceive_IT(&huart6);

			for(uint8_t i=0;i<size;i++)
			{
				gpsBuf[i]=0;
			}

			strcpy((char*)gpsBuf,(char*)tmpGpsBuf);

			for(uint8_t i=0;i<size;i++)
			{
				tmpGpsBuf[i]=0;
			}
			//huart6.pRxBuffPtr = tmpGpsBuf;
			HAL_UART_Receive_IT(&huart6,tmpGpsBuf,sizeof(tmpGpsBuf));
			__HAL_UART_CLEAR_OREFLAG(&huart6);

		}
		else
		{
			huart6.ErrorCode = 0;
		}
	}
	if(huart == &huart1)
		{
			if(huart1.ErrorCode == 0)
			{
				uint16_t tmpDiv = 0;
				uint16_t tmpMull = 0;
				uint16_t tmpOne = 0;
				uint16_t tmpTwo = 0;
				uint8_t tmpCRC = 0;
				uint16_t tmp = 0;

				uint8_t size = huart1.RxXferSize - huart1.RxXferCount;
				HAL_UART_AbortReceive_IT(&huart1);

				memset(uart1Buf, 0x00, sizeof(uart1Buf));

				for(uint8_t i=0;i<size;i++)
				{
					uart1Buf[i]= tmpUart1Buf[i];
				}
				memset(tmpUart1Buf, 0x00, sizeof(tmpUart1Buf));

				for(uint8_t i=0;i<size-1;i++)
				{
					tmpCRC ^= uart1Buf[i];
				}
				huart1.RxXferCount=huart1.RxXferSize;
				HAL_UART_Receive_IT(&huart1,tmpUart1Buf,sizeof(tmpUart1Buf));
				__HAL_UART_CLEAR_OREFLAG(&huart1);

				if(tmpCRC == uart1Buf[size-1])
				{
					switch(uart1Buf[2])
					{
						case cmdTypeSet:

							switch (uart1Buf[3])
							{
								case cmdSetMaxSpeed:	cmdLenzeSetMaxSpeed(uart1Buf[4], uart1Buf[5]);
									break;
								case cmdSetMinSpeed:	cmdLenzeSetMinSpeed(uart1Buf[4], uart1Buf[5]);
									break;
								case cmdSetSensorDir:	cmdSensorChangeDir(uart1Buf[4], uart1Buf[5]);
									break;
								case cmdSetSensorMulti:

									tmpMull = (uart1Buf[5] << 8) + uart1Buf[6];
									tmpDiv = (uart1Buf[7] << 8) +  uart1Buf[8];

									cmdSensorSetMulti(uart1Buf[4], tmpMull, tmpDiv);
									break;

								case cmdSetSoftLimits:

									tmpOne = (uart1Buf[5] << 8) + uart1Buf[6];
									tmpTwo = (uart1Buf[7] << 8) + uart1Buf[8];

									cmdSetSoftLimitSwitch(uart1Buf[4], tmpOne, tmpTwo);

									break;

								case cmdSetCurrPosition:

								 	tmp = (uart1Buf[5] << 8) + uart1Buf[6];

									cmdSetSensorAbsolutePos(uart1Buf[4], tmp);
									break;

								case cmdSetSpRelay:	setSpRelayState(uart1Buf[4]);
									break;

								case cmdSetDate: cmdSetDateNow(uart1Buf[4],uart1Buf[5],uart1Buf[6]);
										break;
							}

							break;
						case cmdTypeInfo:

							switch (uart1Buf[3])
							{
								case cmdGetUtcTime: cmdGetUtcACS();
									break;
								case cmdGetGps:	cmdGetGpsAcs();
									break;
								case cmdGetSpeed: cmdGetMinMaxSpeed(uart1Buf[4]);
									break;
								case cmdGetSensorDir: cmdGetSensorDirecrion(uart1Buf[4]);
									break;
								case cmdGetSensorMulti: cmdGetSensorMultiply(uart1Buf[4]);
									break;
								case cmdGetTemperature: cmdGetTemp();
									break;
								case cmdGetRelayState: cmdGetSpRelayState();
									break;
								case cmdGetStatus:	cmdGetStatusACS();
									break;
								case cmdGetDate: cmdGetDateNow();
									break;
							}

							break;
						case cmdTypeWork:

							switch (uart1Buf[3])
								{
									case cmdDriveTo: //driveCord();
										break;
									case cmdDriveAxis: moveAxis(uart1Buf[4], uart1Buf[5], uart1Buf[6]);
										break;
									case cmdStopDrive: stopAxis(uart1Buf[4]);
										break;
								}
							break;
					}

				}

			}
			else
			{
				huart1.RxXferCount=huart1.RxXferSize;
				huart1.ErrorCode = 0;
			}
		}
}

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */

  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     tex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

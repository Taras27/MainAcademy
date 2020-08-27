#include "limitSwitch.h"

uint8_t hardLimitSwitchStatus = 0;
uint8_t softLimitSwitchStatus = 0;

uint8_t getHardLimitSwitchStatus(void)
{
	//use TIM13
	//period 20 mS
	
	//Az left
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_8) == GPIO_PIN_RESET)
	{
		hardLimitSwitchStatus |= AzLeftLS;
		/*lenzeStartStop(lenzeAxisAz, cmdStop);*/
	}
	else
		hardLimitSwitchStatus &= ~AzLeftLS;
	
	//Az right
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_9) == GPIO_PIN_RESET)
	{
		hardLimitSwitchStatus |= AzRightLS;
		/*lenzeStartStop(lenzeAxisAz, cmdStop);*/
	}
	else
		hardLimitSwitchStatus &= ~AzRightLS;
	
	//El up
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_10) == GPIO_PIN_RESET)
	{
		hardLimitSwitchStatus |= ElTopLS;
		/*lenzeStartStop(lenzeAxisEl, cmdStop);*/
	}
	else
		hardLimitSwitchStatus &= ~ElTopLS;
	
	//El down
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_11) == GPIO_PIN_RESET)
	{
		hardLimitSwitchStatus |= ElBottomLS;
		/*lenzeStartStop(lenzeAxisEl, cmdStop);*/
	}
	else
		hardLimitSwitchStatus &= ~ElBottomLS;
	
	//Reserve A
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_12) == GPIO_PIN_RESET)
		hardLimitSwitchStatus |= ResLS_A;
	else
		hardLimitSwitchStatus &= ~ResLS_A;
	
	//Reserve B
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_13) == GPIO_PIN_RESET)
		hardLimitSwitchStatus |= ResLS_B;
	else
		hardLimitSwitchStatus &= ~ResLS_B;
	
	//Reserve C
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_14) == GPIO_PIN_RESET)
		hardLimitSwitchStatus |= ResLS_C;
	else
		hardLimitSwitchStatus &= ~ResLS_C;
	
	//Reserve D
	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_15) == GPIO_PIN_RESET)
		hardLimitSwitchStatus |= ResLS_D;
	else
		hardLimitSwitchStatus &= ~ResLS_D;
	
	return hardLimitSwitchStatus;
}

uint8_t getSoftLimitSwitchStatus(void)
{
	if(softwareLimitSwitch.softLimitsLeft == 0)
		softLimitSwitchStatus &= ~ AzLeftLS;
	else if(sensorData.azData <= softwareLimitSwitch.softLimitsLeft)
	{
		softLimitSwitchStatus |= AzLeftLS;
	}
	else
		softLimitSwitchStatus &= ~ AzLeftLS;

	if(softwareLimitSwitch.softLimitsRight == 0)
		softLimitSwitchStatus &= ~ AzRightLS;
	else if(sensorData.azData >= softwareLimitSwitch.softLimitsRight)
	{
		softLimitSwitchStatus |= AzRightLS;
	}
	else
		softLimitSwitchStatus &= ~ AzRightLS;

	if(softwareLimitSwitch.softLimitsTop == 0)
		softLimitSwitchStatus &= ~ ElTopLS;
	else if(sensorData.elData >= softwareLimitSwitch.softLimitsTop)
	{
		softLimitSwitchStatus |= ElTopLS;
	}
	else
		softLimitSwitchStatus &= ~ ElTopLS;

	if(softwareLimitSwitch.softLimitsBottom == 0)
		softLimitSwitchStatus &= ~ ElBottomLS;
	else if(sensorData.elData <= softwareLimitSwitch.softLimitsBottom)
	{
		softLimitSwitchStatus |= ElBottomLS;
	}
	else
		softLimitSwitchStatus &= ~ ElBottomLS;

	return softLimitSwitchStatus;
}



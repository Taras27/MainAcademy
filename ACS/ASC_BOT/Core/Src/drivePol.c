#include "drivePol.h"


void startPolCC (uint8_t speed)
{
	stopDirection();
	TIM9->CCR1 = speed;
	startPWM();
	pwmEn();
	direction_CC();
}

void startPolCW (uint8_t speed)
{
	stopDirection();
	TIM9->CCR1 = speed;
	startPWM();
	pwmEn();
	direction_CW();
}

void stopPol (void)
{
	pwmDisable();
	stopPWM();
	stopDirection();
}

uint32_t polStatus(void)
{
	uint32_t status=0;

	if(HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_1) == GPIO_PIN_RESET) //stop
		status = (status | 0xFF) << 8;

	if((HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_1) == GPIO_PIN_SET)&&(HAL_GPIO_ReadPin(GPIOB, GPIO_PIN_12) == GPIO_PIN_SET))//cc
	{
		status = (cmdDirectionCC << 8) + TIM9->CCR1;
	}
	if((HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_1) == GPIO_PIN_SET)&&(HAL_GPIO_ReadPin(GPIOB, GPIO_PIN_13) == GPIO_PIN_SET))//cw
	{
		status = (cmdDirectionCCW << 8) + TIM9->CCR1;
	}
	return status;
}




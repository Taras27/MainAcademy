#include "externalRelay.h"

void setRelay(uint8_t relay)
{
	//use TIM14 for external relay
	//Relay is on then the external button is close
	//button A enable relay A
	//button B enable relay B
	//button C enable relay C
	//
	if(relay & buttonA)
		extRelA_on();
	else
		extRelA_off();
			
	if(relay & buttonB)
		extRelB_on();
	else
		extRelB_off();
			
	if(relay & buttonC)
		extRelC_on();
	else
		extRelC_off();	
}

void setRelaySP(uint8_t spRelay)
{
	//set state of spare relay
	if(spRelay & spRelA_status)
		spRelA_on();
	else
		spRelA_off();
	
	if(spRelay & spRelB_status)
		spRelB_on();
	else
		spRelB_off();
}
uint8_t getRelaySP_status(void)
{
	//	return value 1 byte 0xFF
	// 	high half byte = number relay
	// 	low half = byte status
	//	using without timer
	//enable from compter or external unit command
	uint8_t status = 0;
	
	if(HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_10) == GPIO_PIN_SET)
	{
		status |= spRelA_status;
	}
	else
	{
		status &= ~spRelA_status;
	}
	
	if(HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_11) == GPIO_PIN_SET)
	{
		status |= spRelB_status;
	}
	else
	{
		status &= ~spRelB_status;
	}	
	return status;	
}




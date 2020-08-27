/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/

#ifndef EXTERNALRELAY_H
#define EXTERNALRELAY_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx.h"

/*********************************************************************************************/
/***************************************** DEFINES *******************************************/
/*********************************************************************************************/

typedef enum
{
	spRelayNone=0,
	spRelayA=1,
	spRelayB=2
}eRelay;

typedef enum
{
	relayOFF,
	relayON	
}eRelayState;

#define extRelA_on()		HAL_GPIO_WritePin(GPIOA,GPIO_PIN_7,GPIO_PIN_SET)
#define extRelA_off()		HAL_GPIO_WritePin(GPIOA,GPIO_PIN_7,GPIO_PIN_RESET)
													
#define extRelB_on()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_4,GPIO_PIN_SET)
#define extRelB_off()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_4,GPIO_PIN_RESET)
													
#define extRelC_on()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_5,GPIO_PIN_SET)
#define extRelC_off()		HAL_GPIO_WritePin(GPIOC,GPIO_PIN_5,GPIO_PIN_RESET)

#define spRelA_on()			HAL_GPIO_WritePin(GPIOB,GPIO_PIN_10,GPIO_PIN_SET)	
#define spRelA_off()		HAL_GPIO_WritePin(GPIOB,GPIO_PIN_10,GPIO_PIN_RESET)

#define spRelB_on()			HAL_GPIO_WritePin(GPIOB,GPIO_PIN_11,GPIO_PIN_SET)	
#define spRelB_off()		HAL_GPIO_WritePin(GPIOB,GPIO_PIN_11,GPIO_PIN_RESET)

#define extRelAll_OFF() extRelA_off();extRelB_off();extRelC_off()

#define buttonA	0x08
#define buttonB	0x10
#define buttonC	0x20

#define spRelA	0x10
#define spRelB	0x20

#define spRelA_status	0x01
#define spRelB_status	0x02 

/*********************************************************************************************/
/*********************************** FUNCTION PROTOTYPES *************************************/
/*********************************************************************************************/

void setRelay(uint8_t relay);
//void setRelaySP(eRelay relay, eRelayState relayState);
void setRelaySP(uint8_t spRelay);
uint8_t getRelaySP_status(void);

#endif /*EXTERNALRELAY_H_H_*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/


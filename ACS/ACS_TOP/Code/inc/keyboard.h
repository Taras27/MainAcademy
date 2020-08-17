#ifndef __KEYBOARD_H
#define __KEYBOARD_H

/*********************************************************************************************/
/**************************************** INCLUDES *******************************************/
/*********************************************************************************************/

#include "stm32f4xx.h"



#define	btnLeft 		0x01
#define	btnRight		0x02
#define	btnUp 			0x04
#define	btnDown 		0x08
#define	btnPolLeft 		0x10
#define	btnPolRight  	0x20

typedef enum
{
	pressed = 0,
	unpressed = 1
}buttonStateTypeDef;



uint8_t getKeyboardStatus(void);
void checkButtonLed(void);
void keyBoardProcess(uint8_t key, uint8_t speed);

#endif /*_KEYBOARD_H*/

/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/

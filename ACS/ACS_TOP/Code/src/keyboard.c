#include "keyboard.h"

uint8_t keyBoardStatus = 0;
extern UART_HandleTypeDef huart1;

extern buttonStateTypeDef buttonLeft;
extern buttonStateTypeDef buttonRight;
extern buttonStateTypeDef buttonUp;
extern buttonStateTypeDef buttonDown;
extern buttonStateTypeDef buttonPolLeft;
extern buttonStateTypeDef buttonPolRight;

//key1 PE14 -> UP -> led1 PE15
//key2 PE12 -> LEFT -> led2 PE13
//key3 PE10 -> RIGHT  -> led3 PE11
//key4 PE8 -> DOWN  -> led4 PE9
//key5 PB1 -> POL LEFT  -> led5 PE7
//key6 PC5 -> POL RIGHT  -> led6 PB0

uint8_t getKeyboardStatus(void)
{
	//use TIM14
	//period 20 mS

	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_14) == GPIO_PIN_RESET){
		keyBoardStatus |= btnUp;
		buttonUp = pressed;
	}
	else
		keyBoardStatus &= ~btnUp;

	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_12) == GPIO_PIN_RESET)
		keyBoardStatus |= btnLeft;
	else
		keyBoardStatus &= ~btnLeft;

	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_10) == GPIO_PIN_RESET)
		keyBoardStatus |= btnRight;
	else
		keyBoardStatus &= ~btnRight;

	if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_8) == GPIO_PIN_RESET)
		keyBoardStatus |= btnDown;
	else
		keyBoardStatus &= ~btnDown;

	if(HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_1) == GPIO_PIN_RESET)
		keyBoardStatus |= btnPolLeft;
	else
		keyBoardStatus &= ~btnPolLeft;

	if(HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_5) == GPIO_PIN_RESET)
		keyBoardStatus |= btnPolRight;
	else
		keyBoardStatus &= ~btnPolRight;

	return keyBoardStatus;
}

uint8_t arrayTmp[8] = { 0 };

void keyBoardProcess(uint8_t key, uint8_t speed)
{

}

void checkButtonLed(void)
{
	//key1 PE14 -> UP -> led1 PE15
	//key2 PE12 -> LEFT -> led2 PE13
	//key3 PE10 -> RIGHT  -> led3 PE11
	//key4 PE8 -> DOWN  -> led4 PE9
	//key5 PB1 -> POL LEFT  -> led5 PE7
	//key6 PC5 -> POL RIGHT  -> led6 PB0
	while(1)
	{
		if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_14) == GPIO_PIN_RESET)
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_15, GPIO_PIN_SET);
		else
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_15, GPIO_PIN_RESET);

		if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_12) == GPIO_PIN_RESET)
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_13, GPIO_PIN_SET);
		else
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_13, GPIO_PIN_RESET);

		if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_10) == GPIO_PIN_RESET)
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_11, GPIO_PIN_SET);
		else
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_11, GPIO_PIN_RESET);

		if(HAL_GPIO_ReadPin(GPIOE,GPIO_PIN_8) == GPIO_PIN_RESET)
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_9, GPIO_PIN_SET);
		else
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_9, GPIO_PIN_RESET);

		if(HAL_GPIO_ReadPin(GPIOB,GPIO_PIN_1) == GPIO_PIN_RESET)
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_7, GPIO_PIN_SET);
		else
			HAL_GPIO_WritePin(GPIOE, GPIO_PIN_7, GPIO_PIN_RESET);

		if(HAL_GPIO_ReadPin(GPIOC,GPIO_PIN_5) == GPIO_PIN_RESET)
			HAL_GPIO_WritePin(GPIOB, GPIO_PIN_0, GPIO_PIN_SET);
		else
			HAL_GPIO_WritePin(GPIOB, GPIO_PIN_0, GPIO_PIN_RESET);
		HAL_Delay(30);

	}
}






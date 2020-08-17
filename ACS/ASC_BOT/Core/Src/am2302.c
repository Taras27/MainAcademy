#include "am2302.h"

uint8_t am2302Data[5] = {0};

__STATIC_INLINE void DelayMicro(__IO uint32_t micros)
{
micros *= (SystemCoreClock / 1000000)/ 7; //core freq = 168 MHz
/* Wait till done */
while (micros--) ;
}

uint8_t initAM2302(void)
{
	HAL_Delay(2000);
	GPIOA->OTYPER |= GPIO_OTYPER_OT8;
	HAL_GPIO_WritePin(GPIOA,GPIO_PIN_8,GPIO_PIN_SET);
	return 0;
}

uint8_t getDataAM2302(uint8_t *data)
{
	uint8_t i, j = 0;
	//reset port
	GPIOA->ODR &= ~GPIO_ODR_OD8;//low level
	GPIOA->ODR |= GPIO_ODR_OD8;//high level
	DelayMicro(1000);
//	delayMicro(100000);
	GPIOA->ODR &= ~GPIO_ODR_OD8;//low level
	DelayMicro(10000);
//	delayMicro(18000);
	GPIOA->ODR |= GPIO_ODR_OD8;//high level
	//wait am2303 response
//	delayMicro(39);//20-40 ???
	DelayMicro(30);
	//if not response return 0 
	if(GPIOA->IDR & GPIO_IDR_ID8) { 
		return NOT_CONNECTED;
	}

	DelayMicro(80);
	//if am2302 not reset bus when error
	if(!(GPIOA->IDR & GPIO_IDR_ID8)) {
		return NOT_CONNECTED;
	}
	DelayMicro(80);
//	delayMicro(80);
	//read data 

	for (j=0; j<5; j++)
	{
		data[4-j]=0;
		for(i=0; i<8; i++)
		{
			while(!(GPIOA->IDR & GPIO_IDR_ID8)); //wair set bus
//			delayMicro(30);
			DelayMicro(30);
			if(GPIOA->IDR & GPIO_IDR_ID8) //read data after 30 us 
				//if bus not reset this is '1' else '0'
				data[4-j] |= (1<<(7-i));
			while(GPIOA->IDR & GPIO_IDR_ID8); //wait when am2303 pull down bus (if '1')
		}
	}
	return CONNECTED;
}

void getSensorData(am2302TypeDef *data)
{
	if(getDataAM2302(am2302Data) == CONNECTED)
	{
		data->humidity = ((am2302Data[4] << 8) + am2302Data[3])/10;
		data->temperature = (am2302Data[2] << 8) + am2302Data[1];
		data->sensorState = CONNECTED;
	}
	else
	{
		data->humidity = 0;
		data->temperature = 0; 
		data->sensorState = NOT_CONNECTED;		
	}	
}



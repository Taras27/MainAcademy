#include "ds18b20.h"

#define DELAY_RESET           500
#define DELAY_WRITE_0         60
#define DELAY_WRITE_0_PAUSE   10
#define DELAY_WRITE_1         10
#define DELAY_WRITE_1_PAUSE   60
#define DELAY_READ_SLOT       10
#define DELAY_BUS_RELAX       10
#define DELAY_READ_PAUSE      50
#define DELAY_T_CONVERT       760000
#define DELAY_PROTECTION      5

typedef enum {
	SKIP_ROM = 0xCC,
	CONVERT_T = 0x44,
	READ_SCRATCHPAD = 0xBE,
	WRITE_SCRATCHPAD = 0x4E,
	TH_REGISTER = 0x64,
	TL_REGISTER = 0x9E,
} COMMANDS;

uint32_t DELAY_WAIT_CONVERT = DELAY_T_CONVERT;

__STATIC_INLINE void delayMicro(__IO uint32_t micros)
{
micros *= (SystemCoreClock / 1000000)/ 7; //core freq = 168 MHz
/* Wait till done */
while (micros--) ;
}

void ds18b20Reset(void)
{
	GPIOB->ODR &= ~GPIO_ODR_OD14;
	delayMicro(DELAY_RESET);
	
	GPIOB->ODR |= GPIO_ODR_OD14;
	delayMicro(DELAY_RESET);
}

void writeBit(uint8_t bit)
{
	GPIOB->ODR &= ~GPIO_ODR_OD14;
	delayMicro(bit ? DELAY_WRITE_1 : DELAY_WRITE_0);
	GPIOB->ODR |= GPIO_ODR_OD14;
	delayMicro(bit ? DELAY_WRITE_1_PAUSE : DELAY_WRITE_0_PAUSE);
}

void writeByte(uint8_t data)
{
	for (uint8_t i = 0; i < 8; i++)
	{
		writeBit(data >> i & 1);
		delayMicro(DELAY_PROTECTION);
	}
}

uint8_t getDevider(DS18B20_RESOLUTION_t resolution)
{
	uint8_t devider;
	switch (resolution)
	{
	case DS18B20_Resolution_9_bit:
		devider = 8;
		break;
	case DS18B20_Resolution_10_bit:
		devider = 4;
		break;
	case DS18B20_Resolution_11_bit:
		devider = 2;
		break;
	case DS18B20_Resolution_12_bit:
	default:
		devider = 1;
		break;
	}

	return devider;
}

void setResolution(DS18B20_RESOLUTION_t resolution)
{
	ds18b20Reset();
	writeByte(SKIP_ROM);
	writeByte(WRITE_SCRATCHPAD);
	writeByte(TH_REGISTER);
	writeByte(TL_REGISTER);
	writeByte(resolution);
	DELAY_WAIT_CONVERT = DELAY_T_CONVERT / getDevider(resolution);
}

//connected to PB14
void ds18b20Init(DS18B20_RESOLUTION_t resolution)
{
	RCC->AHB1ENR |= RCC_AHB1ENR_GPIOBEN;	
	
	GPIOB->MODER &= ~GPIO_MODER_MODE14_1;
	GPIOB->MODER |= GPIO_MODER_MODE14_0;
	
	GPIOB->OTYPER |= GPIO_OTYPER_OT14;
	
	GPIOB->OSPEEDR |= GPIO_OSPEEDER_OSPEEDR14_1;
	GPIOB->OSPEEDR &= ~GPIO_OSPEEDER_OSPEEDR14_0;
	
	setResolution(resolution);
}

uint8_t readBit(void)
{
	uint8_t bit = 0;
	GPIOB->ODR &= ~GPIO_ODR_OD14;
	delayMicro(DELAY_READ_SLOT);//10uS
	GPIOB->ODR |= GPIO_ODR_OD14;
	// ... switch to INPUT
	delayMicro(DELAY_BUS_RELAX); //10uS
	bit = (GPIOB->IDR & GPIO_IDR_ID14 ? 1 : 0);
	delayMicro(DELAY_READ_PAUSE);//50 uS
	// ... switch to OUTPUT
	return bit;
}

uint8_t ds18b20ReadByte(void)
{
	uint8_t data = 0;
	for(uint8_t i=0;i<8;i++)
	{
		data += readBit() << i;
	}
	return data;
}


uint16_t readTemperature(void)
{
	uint16_t data = 0;
	for (uint8_t i = 0; i < 16; i++)
		data += (uint16_t) readBit() << i;
	return (uint16_t)(((float) data / 16.0) * 10.0);
}

uint16_t ds18b20_getTemperature(void)
{
	ds18b20Reset();
	writeByte(SKIP_ROM);//CC
	writeByte(CONVERT_T);//44
	delayMicro(DELAY_WAIT_CONVERT);

	ds18b20Reset();
	writeByte(SKIP_ROM);//CC
	writeByte(READ_SCRATCHPAD);//BE	

	return readTemperature();
}

void ds18b20ReadData(uint8_t *data)
{
		ds18b20Reset();
	writeByte(SKIP_ROM);//CC
	writeByte(CONVERT_T);//44
	delayMicro(DELAY_WAIT_CONVERT);

	ds18b20Reset();
	writeByte(SKIP_ROM);//CC
	writeByte(READ_SCRATCHPAD);//BE	
	
	for(uint8_t i=0;i<9;i++)
	{
		data[i] = ds18b20ReadByte();
	}	
}


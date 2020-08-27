/*
 * flash.h
 *
 *  Created on: Jul 29, 2020
 *      Author: Horyn
 */

#ifndef FLASH_H_
#define FLASH_H_

#include "stm32f4xx_hal.h"
#include "main.h"

#define FLASH_ADDR 0x080E0000
#define FLASH_ADDR_END 0x080E001C

extern userSettingsTypeDef flashCopySetting;
extern userSettingsTypeDef defaulSetting;
extern userSettingsTypeDef workingSetting;


uint8_t writeFlash (userSettingsTypeDef* userData);
uint8_t readFlash (userSettingsTypeDef* userData);
uint8_t flashProcess(userSettingsTypeDef* userData);

#endif /* FLASH_H_ */

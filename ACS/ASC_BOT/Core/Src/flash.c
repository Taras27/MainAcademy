/*
 * flash.c
 *
 *  Created on: Jul 29, 2020
 *      Author: Horyn
 */

#include "flash.h"

HAL_StatusTypeDef cmdRes;

uint8_t writeFlash (userSettingsTypeDef* userData)
{
	uint32_t addr = FLASH_ADDR;

	uint32_t *pWrite = (uint32_t *) userData;

	cmdRes = HAL_FLASH_Unlock();

	FLASH_Erase_Sector(FLASH_SECTOR_11,FLASH_VOLTAGE_RANGE_3);

	for ( uint8_t i = 0; i < sizeof(userSettingsTypeDef); i+=4, pWrite++, addr+=4)
	{
		cmdRes = HAL_FLASH_Program(FLASH_TYPEPROGRAM_WORD, addr, *pWrite);
	}
	cmdRes = HAL_FLASH_Lock();
	return cmdRes;
}

uint8_t readFlash (userSettingsTypeDef* userData)
{
	uint32_t *pWrite = (uint32_t *) userData;
	uint32_t addr = FLASH_ADDR;

	for (uint8_t i = 0; i < sizeof(userSettingsTypeDef) ; i+=4, pWrite++, addr+=4)
	{
		*pWrite = *(uint32_t *)addr;
	}

	return HAL_OK;
}


uint8_t flashProcess(userSettingsTypeDef* userData)
{
	cmdRes = readFlash(&flashCopySetting);  //зчитуємо дані із флеш памяті
	  uint8_t compareError = 0; //кількість помилок для порівняння структур

	  if(flashCopySetting.key != FLASH_KEY) // перевірка чи це не перший запуск
	  {
		  cmdRes = writeFlash(&defaulSetting);	  // якщо так, заповняємо структуру значеннями за замовчуванням

		  userData->writeCount = defaulSetting.writeCount;
		  userData->gpsLatitude = defaulSetting.gpsLatitude;
		  userData->gpsLongtitude = defaulSetting.gpsLongtitude;
		  userData->gpsAltitude = defaulSetting.gpsAltitude;
		  userData->softLimitsTop = defaulSetting.softLimitsTop;
		  userData->softLimitsBottom = defaulSetting.softLimitsBottom;
		  userData->softLimitsLeft = defaulSetting.softLimitsLeft;
		  userData->softLimitsRight = defaulSetting.softLimitsRight;
		  userData->lenzeAzMaxSpeed = defaulSetting.lenzeAzMaxSpeed;
		  userData->lenzeAzMinSpeed = defaulSetting.lenzeAzMinSpeed;
		  userData->lenzeElMinSpeed = defaulSetting.lenzeElMinSpeed;
		  userData->lenzeElMaxSpeed = defaulSetting.lenzeElMaxSpeed;
		  userData->polMinSpeed = defaulSetting.polMinSpeed;
		  userData->polMaxSpeed = defaulSetting.polMaxSpeed;

		  userData->key = defaulSetting.key;
	  }
	  else
	  {
		  uint32_t *pWorkingSetting = (uint32_t *) userData;
		  uint32_t *pFlashCopySetting = (uint32_t *) &flashCopySetting;

		  for(uint8_t i = 0; i < sizeof(userSettingsTypeDef); i+=4, pFlashCopySetting++, pWorkingSetting++)
		  {
			  if(*pWorkingSetting != *pFlashCopySetting)
				  compareError++;
		  }

		  if(compareError > 0)
		  {
			  flashCopySetting.writeCount = ++userData->writeCount;
			  flashCopySetting.gpsLatitude = userData->gpsLatitude;
			  flashCopySetting.gpsLongtitude = userData->gpsLongtitude;
			  flashCopySetting.gpsAltitude = userData->gpsAltitude;
			  flashCopySetting.softLimitsTop = userData->softLimitsTop;
			  flashCopySetting.softLimitsBottom = userData->softLimitsBottom;
			  flashCopySetting.softLimitsLeft = userData->softLimitsLeft;
			  flashCopySetting.softLimitsRight = userData->softLimitsRight;
			  flashCopySetting.lenzeAzMinSpeed = userData->lenzeAzMinSpeed;
			  flashCopySetting.lenzeAzMaxSpeed = userData->lenzeAzMaxSpeed;
			  flashCopySetting.lenzeElMinSpeed = userData->lenzeElMinSpeed;
			  flashCopySetting.lenzeElMaxSpeed = userData->lenzeElMaxSpeed;
			  flashCopySetting.polMinSpeed = userData->polMinSpeed;
			  flashCopySetting.polMaxSpeed = userData->polMaxSpeed;
			  flashCopySetting.key = userData->key;

			  cmdRes = writeFlash(&flashCopySetting);
		  }
	  }
	return cmdRes;
}

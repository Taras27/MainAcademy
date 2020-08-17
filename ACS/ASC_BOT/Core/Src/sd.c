#include "sd.h"

FATFS fileSystem;  		// file system
FIL file; 						// File
FILINFO fileInfo;			//File info
FRESULT fResult;  	// result
UINT bRead, bWrite;  	// File read/write count
extern char sdFileName[12];
extern char sdFolderName[];
extern char sdBufferFolderName[30];//шлях до файла
uint8_t counterWrite=0;
int16_t tmpPol = 0;
int16_t tmpEl = 0;

uint8_t mountSD (const TCHAR* path)
{
	fResult = f_mount(&fileSystem, path, 1);
	if(fResult == FR_OK)
		return FR_OK;
	else
		return fResult;
}

uint8_t UnMountSD (const TCHAR* path)
{
	fResult = f_mount(NULL, path, 1);
	if(fResult == FR_OK)
		return FR_OK;
	else
		return fResult;
}



FRESULT writeFile(char* name, char* data)
{
	fResult = f_stat(name, &fileInfo);
	
	if(fResult != FR_OK)
		return fResult;
	else
	{
		fResult = f_open(&file, name, FA_OPEN_EXISTING|FA_WRITE);
		
		if(fResult != FR_OK)
		return fResult;
		else
		{
			fResult = f_write(&file, data, strlen(data), &bWrite);
			
			if(fResult != FR_OK)
			{
				fResult = f_close(&file);
				return fResult;	
			}
			else
			{
				return fResult;
			}					
		}		
	}	
}


FRESULT createFile(char* name)
{
	fResult = f_stat(name, &fileInfo);
	
	if(fResult == FR_OK)
		return fResult;
	else
	{
		fResult = f_open(&file, name, FA_CREATE_ALWAYS|FA_READ|FA_WRITE);
		
		if(fResult != FR_OK)
			return fResult;
		else
		{
			f_close(&file);
			return fResult;
		}
	}
}

FRESULT createDirection (char *name)
{
	fResult = f_mkdir(name);	
	return 	fResult;	
}

FRESULT updateFile (char *name, char *data)
{
	fResult = f_stat(name, &fileInfo);
	
	if(fResult != FR_OK)
		return fResult;
	else
	{
		fResult = f_open(&file, name, FA_OPEN_APPEND|FA_WRITE);
		
		if(fResult != FR_OK)
			return fResult;
		else
		{
			fResult = f_write(&file, data, strlen(data), &bWrite);
							
			f_close(&file);
			return fResult;				
		}
	}
}


uint8_t sdProcess(RTC_DateTypeDef *date, RTC_TimeTypeDef *time, sensorDataTypeDef *sensorData)
{
	RTC_DateTypeDef dateTmp;
	RTC_DateTypeDef dateTmpOld = {0,0,0};
	uint8_t bufferSD[100]={0};

	if(HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_15) == GPIO_PIN_RESET) //перевірили чи встановлена sd карта
	{
		SdLedOff();

		dateTmp.Date = date->Date;
		dateTmp.Month = date->Month;
		dateTmp.Year = date->Year;

		if ((dateTmp.Date != dateTmpOld.Date) || (dateTmp.Year != dateTmpOld.Year))
		{
			sprintf(sdFileName,"%02d\%02d\%02d", dateTmp.Date, dateTmp.Month, dateTmp.Year);
			sprintf(sdBufferFolderName, "%s/%s.txt",sdFolderName, sdFileName);
			createFile(sdBufferFolderName);

			if(fResult == FR_OK || fResult == FR_EXIST)
				SdLedOff();
			else
			{
				f_close(&file);

				FATFS_UnLinkDriver(SDPath);

				FATFS_LinkDriver(&SD_Driver, SDPath);

				fResult = mountSD(SDPath);

				if(fResult == FR_OK)
					SdLedOff();
				else
					SdLedOn();
			}
		}
		dateTmpOld.Date = date->Date;
		dateTmpOld.Month = date->Month;
		dateTmpOld.Year = date->Year;


		if(sensorData->polData & 0x8000)
			tmpPol = ((~sensorData->polData) - 1) * -1;
		else
			tmpPol = sensorData->polData-180;

		if(sensorData->elData & 0x8000)
			tmpEl = ((~sensorData->elData) - 1) * -1;
		else
			tmpEl = sensorData->elData-180;


		if((time->Minutes % 10) == 0 && (time->Seconds == 1))
		{
			if(counterWrite == 0)
			{
			sprintf((char*)bufferSD, "[%02d/%02d/%02d | %02d:%02d:%02d][Az -> %.02f][El -> %.02f][Pol -> %.02f][wind -> %.02f m/s]\r\n",
								date->Date, date->Month, date->Year,time->Hours, time->Minutes, time->Seconds,
						  		(float)sensorData->azData/100, (float)(tmpEl/100.0),
								(float)(tmpPol/100.0), (float)sensorData->windData/10);

			if(updateFile(sdBufferFolderName,(char*)bufferSD)==FR_OK)
				SdLedOff();
			else if(fResult == FR_NO_PATH)
				{
					createDirection(sdFolderName);

						if(fResult == FR_OK || fResult == FR_EXIST)
							SdLedOff();
						else
							SdLedOn();
				}
			else if (fResult == FR_NO_FILE)
				{
					createFile(sdBufferFolderName);

						if(fResult == FR_OK || fResult == FR_EXIST)
							SdLedOff();
						else
							SdLedOn();
				}
			else
				{
					f_close(&file);

					FATFS_UnLinkDriver(SDPath);

					FATFS_LinkDriver(&SD_Driver, SDPath);

					fResult = mountSD(SDPath);

					if(fResult == FR_OK)
						SdLedOff();
					else
						SdLedOn();
				}
			counterWrite++;
			}
		}
		else
			counterWrite=0;
	}
	else
	{
		SdLedOn();
		return fResult;
	}
	return fResult;
}

/*
  if(HAL_GPIO_ReadPin(GPIOA,GPIO_PIN_15) == GPIO_PIN_RESET)
	  {
		SdLedOff();
		if((timeRTC.Minutes % 1) == 0 && (timeRTC.Seconds == 1))
		{
			sprintf(bufferSD, "[%02d/%02d/%02d | %02d:%02d:%02d] wind -> [%.2f] m/s\r\n" ,
					dateRTC.Date, dateRTC.Month, dateRTC.Year,
					timeRTC.Hours, timeRTC.Minutes, timeRTC.Seconds,
			  		(float)windSpeed.Speed/10);

			if(updateFile(sdBufferFolderName,bufferSD)==FR_OK)
				SdLedOff();
			else if(fResult == FR_NO_PATH)
			{
				createDirection(sdFolderName);

				if(fResult == FR_OK || fResult == FR_EXIST)
					SdLedOff();
				else
					SdLedOn();
			}
			else if (fResult == FR_NO_FILE)
			{
				createFile(sdBufferFolderName);

				if(fResult == FR_OK || fResult == FR_EXIST)
					SdLedOff();
				else
					SdLedOn();
			}
			else
			{
				f_close(&file);

				FATFS_UnLinkDriver(SDPath);

				FATFS_LinkDriver(&SD_Driver, SDPath);

				fResult = mountSD(SDPath);

				if(fResult == FR_OK)
					SdLedOff();
				else
					SdLedOn();
			}
		}
	  }
	  else
	  	SdLedOn();
*/


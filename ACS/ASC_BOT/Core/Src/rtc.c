#include "rtc.h"

RTC_TimeTypeDef timeRTC;
RTC_DateTypeDef dateRTC;
HAL_StatusTypeDef resTime, resDate;


HAL_StatusTypeDef setTime (uint8_t hours,uint8_t minutes, uint8_t seconds)
{
	timeRTC.Hours 		= hours;
	timeRTC.Minutes 	= minutes;
	timeRTC.Seconds 	= seconds;
	
	resTime = HAL_RTC_SetTime(&hrtc, &timeRTC, RTC_FORMAT_BIN);
	
	return resTime;
}

HAL_StatusTypeDef setDate(uint8_t day, uint8_t mouth, uint8_t year)
{
	dateRTC.Year = year;
	dateRTC.Month = mouth;
	dateRTC.Date = day;
	dateRTC.WeekDay = 0;
	
	resDate = HAL_RTC_SetDate(&hrtc, &dateRTC, RTC_FORMAT_BIN);
	
	return resDate;
}


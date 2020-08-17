#include "goto.h"

extern uint8_t limitSwitchStatus;
extern uint32_t counterMs;
extern HAL_UART_StateTypeDef huart1;
extern uint8_t uart1Buf[30];
extern uint8_t tmpUart1Buf[30];

uint8_t driveTo(int32_t setPointAz, int32_t setPointEl, int32_t setPointPol)
{
	PidInit(&PidAz);
	PidInit(&PidEl);
	PidInit(&PidPol);

	HAL_UART_Receive_IT(&huart1, tmpUart1Buf, sizeof(tmpUart1Buf));

	int32_t errorAz, errorEl, errorPol;
	int32_t pidValueAz, pidValueEl, pidValuePol;
	uint8_t directionAz,directionEl, directionPol;
	uint8_t speedAz, speedEl, speedPol;
	while(!(PID_OK))
	{

		if(getPosition(axisAZ) > 0xFFFF)
			pidValueAz = 0;
		else
			pidValueAz =(int32_t)(((float)getPosition(axisAZ)*0.00549)*100);

		if(getPosition(axisEL) > 0xFFFF)
			pidValueEl = 0;
		else
			pidValueEl = (int32_t)(((float)getPosition(axisEL)*0.00549 - 180)*100);

		if(getPosition(axisPOL) > 0xFFFF)
			pidValuePol = 0;
		else
			pidValuePol = (int32_t)(((float)getPosition(axisPOL)*0.00549 - 180)*100);
		//direction AZ
		if(setPointAz > pidValueAz)
			directionAz = cmdForward;
		else
			directionAz = cmdReverse;
		//direction EL
		if(setPointEl > pidValueEl)
			directionEl = cmdForward;
		else
			directionEl = cmdReverse;
		//direction POL
		if(setPointPol > pidValuePol)
			directionPol = cmdForward;
		else
			directionPol = cmdReverse;

		errorAz = setPointAz - pidValueAz;
		errorEl = setPointEl - pidValueEl;
		errorPol = setPointPol - pidValuePol;

		if(setPointAz != 0)
			speedAz = (uint8_t)PidUpdate(&PidAz, setPointAz, pidValueAz);

		if(setPointEl != 0)
			speedEl = (uint8_t)PidUpdate(&PidEl, setPointEl, pidValueEl);


		if(setPointPol != 0)
			speedPol = (uint8_t)PidUpdate(&PidPol, setPointPol, pidValuePol);

		if((errorAz <= 10) && (errorAz >= -10))
			lenzeStartStop(axisAZ, cmdStop);
		else
			lenzeDrive(axisAZ, directionAz, speedAz);

		if((errorEl <= 10) && (errorEl >= -10))
			lenzeStartStop(axisEL, cmdStop);
		else
			lenzeDrive(axisEL, directionEl, speedEl);

		if((errorPol <= 10) && (errorPol >= -10))
			stopPol();
		else
		{
			if(directionPol == cmdForward)
				startPolCC (speedPol);
			if(directionPol == cmdReverse)
				startPolCW(speedPol);
		}

		if((errorPol <= 10) && (errorEl <= 10) && (errorAz <= 10))
			return PID_OK;

		counterMs = 0;

		while(counterMs <= 100);
	}
	return PID_OK;
}

#include "protocol.h"


uint8_t flagStatus = 0;
uint8_t statusArray[27] = {0};
uint8_t utsArray[8] = {0};
uint8_t gpsArray[19] = {0};
uint8_t speedArray[8] = {0};
uint8_t sensorDirArray[7] = {0};
uint8_t sensorMultiArray[10] = {0};
uint8_t temperatureArray[10] = {0};
uint8_t relaySpArray[6] = {0};
uint8_t dateArray[] = {0};

uint8_t ansverOk[] = {0xFF, 0x00, 0xFF};
uint8_t ansverBad[] = {0xFF, 0xFF, 0x00};

//**************************** ІНФОРМАЦІЙНІ КОМАНДИ ****************************//
void cmdGetStatusACS (void)
{
	statusArray[0] = beginPacket;
	statusArray[1]  = 0x18; //кількість байт в посилці
	statusArray[2] = cmdTypeInfo;
	statusArray[3]  = cmdGetStatus;


	statusArray[4] = (driveStatus.azLenzeData & 0xFF000000) >> 24; 	//статус частотного перетворювача
	statusArray[5] = (driveStatus.azLenzeData & 0x00FF0000) >> 16; 	//напрямок руху частотного перетворювача
	statusArray[6] = (uint8_t)((driveStatus.azLenzeData & 0x0000FFFF)/10); //швидкість в Гц

	statusArray[7] = (driveStatus.elLenzeData & 0xFF000000) >> 24; 	//статус частотного перетворювача
	statusArray[8] = (driveStatus.elLenzeData & 0x00FF0000) >> 16; 	//напрямок руху частотного перетворювача
	statusArray[9] = (uint8_t)((driveStatus.elLenzeData & 0x0000FFFF)/10); //швидкість в Гц

	statusArray[10] = (driveStatus.polData & 0x00FF0000) >> 16; 	//статус осі поляризації
	statusArray[11] = (driveStatus.polData & 0x0000FF00) >> 8; 		//напрямок руху осі поляризації
	statusArray[12] = (driveStatus.polData & 0xFF); 				//швидкість в %

	statusArray[13] = (sensorData.azData & 0x00FF0000) >> 16; 		//статус датчика Az
	statusArray[14] = (sensorData.azData & 0x0000FF00) >> 8; 		//старша частина позиції
	statusArray[15] = (sensorData.azData & 0xFF); 					//молодша частина позиції

	statusArray[16] = (sensorData.elData & 0x00FF0000) >> 16; 		//статус датчика El
	statusArray[17] = (sensorData.elData & 0x0000FF00) >> 8; 		//старша частина позиції
	statusArray[18] = (sensorData.elData & 0xFF); 					//молодша частина позиції

	statusArray[19] = (sensorData.polData & 0x00FF0000) >> 16; 		//статус датчика Pol
	statusArray[20] = (sensorData.polData & 0x0000FF00) >> 8; 		//старша частина позиції
	statusArray[21] = (sensorData.polData & 0xFF); 					//молодша частина позиції

	statusArray[22] = (sensorData.windData & 0xFF00) >> 16;
	statusArray[23] = (sensorData.windData &0xFF);

	statusArray[24] = softLimitSwitchStatus;
	statusArray[25] = hardLimitSwitchStatus;

	statusArray[26] = 0;

	for(uint8_t i=0; i<=25; i++)
		statusArray[26] ^= statusArray[i];

	HAL_UART_Transmit_IT(&huart1, statusArray, 27);
}

void cmdGetUtcACS(void)
{
	utsArray[0] = beginPacket;
	utsArray[1] = 0x05; //кількість байт в посилці
	utsArray[2] = cmdTypeInfo;
	utsArray[3] = cmdGetUtcTime;

	utsArray[4] = gpsData.time.hours;
	utsArray[5] = gpsData.time.minutes;
	utsArray[6] = gpsData.time.seconds;
	utsArray[7] = 0;

	for(uint8_t i=0; i<=6; i++)
		utsArray[7] ^= utsArray[i];

	HAL_UART_Transmit_IT(&huart1, utsArray, 8);
}

void cmdGetGpsAcs(void)
{
	gpsArray[0] = beginPacket;
	gpsArray[1] = 0x10; //кількість байт в посилці

	gpsArray[2] = cmdTypeInfo;
	gpsArray[3] = cmdGetGps;


	if(gpsLatitude > 0)
		gpsArray[4] = 0x01; //!!
	else
	{
		int32_t tmp = ~gpsLatitude + 1;
		gpsLatitude = tmp;
		gpsArray[4] = 0x02; //!!
	}
	gpsArray[5] = (gpsLatitude >> 24) & 0xFF;
	gpsArray[6] = (gpsLatitude >> 16) & 0xFF;
	gpsArray[7] = (gpsLatitude >> 8) & 0xFF;
	gpsArray[8] = gpsLatitude & 0xFF;

	if(gpsLongtitude > 0)
			gpsArray[9] = 0x01; //!!
		else
		{
			int32_t tmp = ~gpsLongtitude + 1;
			gpsLongtitude = tmp;
			gpsArray[9] = 0x02; //!!
		}
	gpsArray[10] = (gpsLongtitude >> 24) & 0xFF;
	gpsArray[11] = (gpsLongtitude >> 16) & 0xFF;
    gpsArray[12] = (gpsLongtitude >> 8) & 0xFF;
	gpsArray[13] = gpsLongtitude & 0xFF;
	gpsArray[14] = (gpsData.altitude.value >> 8) & 0xFF;
	gpsArray[15] = gpsData.altitude.value & 0xFF;
	gpsArray[16] = gpsData.satteliteTracked;
	gpsArray[17] = gpsData.quality;

	gpsArray[18] = 0;

	for(uint8_t i=0; i<=17; i++)
		gpsArray[18] ^= gpsArray[i];

	HAL_UART_Transmit_IT(&huart1, gpsArray, 19);

}

void cmdGetMinMaxSpeed(uint8_t axis)
{
	speedArray[0] = beginPacket;
	speedArray[1] = 0x05;
	speedArray[2] = cmdTypeInfo;
	speedArray[3] = cmdGetSpeed;

	if(axis == axisAZ)
	{
		speedArray[4] = axisAZ;
		speedArray[5] = workingSetting.lenzeAzMaxSpeed;
		speedArray[6] = workingSetting.lenzeAzMinSpeed;
	}

	if(axis == axisEL)
	{
		speedArray[4] = axisEL;
		speedArray[5] = workingSetting.lenzeElMaxSpeed;
		speedArray[6] = workingSetting.lenzeElMinSpeed;
	}

	if(axis == axisPOL)
	{
		speedArray[4] = axisPOL;
		speedArray[5] = workingSetting.polMaxSpeed;
		speedArray[6] = workingSetting.polMinSpeed;
	}
	speedArray[7] = 0;

	for(uint8_t i=0; i<7; i++){
		speedArray[7] ^= speedArray[i];
	}
		HAL_UART_Transmit_IT(&huart1, speedArray, 8);
}

void cmdGetSensorDirecrion(uint8_t axis)
{
	sensorDirArray[0] = beginPacket;
	sensorDirArray[1] = 0x05;
	sensorDirArray[2] = cmdTypeInfo;
	sensorDirArray[3] = cmdGetSensorDir;

	if(axis == axisAZ)
	{
		sensorDirArray[4] = axisAZ;
		sensorDirArray[5] = readModeSensor(axisAZ);
	}

	if(axis == axisEL)
	{
		sensorDirArray[4] = axisEL;
		sensorDirArray[5] = readModeSensor(axisEL);
	}

	if(axis == axisPOL)
	{
		sensorDirArray[4] = axisPOL;
		sensorDirArray[5] = readModeSensor(axisPOL);
	}

	sensorDirArray[6] = 0;

		for(uint8_t i=0; i<6; i++){
			sensorDirArray[6] ^= sensorDirArray[i];
		}
			HAL_UART_Transmit_IT(&huart1, sensorDirArray, 7);
}

void cmdGetSensorMultiply(uint8_t axis)
{
	sensorMultiArray[0] = beginPacket;
	sensorMultiArray[1] = 0x07;
	sensorMultiArray[2] = cmdTypeInfo;
	sensorMultiArray[3] = cmdGetSensorMulti;

	if(axis == axisAZ)
	{
		sensorMultiArray[4] = axisAZ;
		uint32_t tmp = getMulti(axisAZ);
		sensorMultiArray[5] = (tmp >> 24) & 0xFF;
		sensorMultiArray[6] = (tmp >> 16) & 0xFF;
		sensorMultiArray[7] = (tmp >> 8) & 0xFF;
		sensorMultiArray[8] = tmp & 0xFF;
	}

	if(axis == axisEL)
	{
		sensorMultiArray[4] = axisEL;
		uint32_t tmp = getMulti(axisEL);
		sensorMultiArray[5] = (tmp >> 24) & 0xFF;
		sensorMultiArray[6] = (tmp >> 16) & 0xFF;
		sensorMultiArray[7] = (tmp >> 8) & 0xFF;
		sensorMultiArray[8] = tmp & 0xFF;
	}

	if(axis == axisPOL)
	{
		sensorMultiArray[4] = axisPOL;
		uint32_t tmp = getMulti(axisPOL);
		sensorMultiArray[5] = (tmp >> 24) & 0xFF;
		sensorMultiArray[6] = (tmp >> 16) & 0xFF;
		sensorMultiArray[7] = (tmp >> 8) & 0xFF;
		sensorMultiArray[8] = tmp & 0xFF;
	}

	sensorMultiArray[9] = 0;

	for(uint8_t i=0; i<9; i++)
		sensorMultiArray[9] ^= sensorMultiArray[i];

	HAL_UART_Transmit_IT(&huart1, sensorMultiArray, 10);
}

void cmdGetTemp(void)
{
	temperatureArray[0] = beginPacket;
	temperatureArray[1] = 0x07;
	temperatureArray[2] = cmdTypeInfo;
	temperatureArray[3] = cmdGetTemperature;

	temperatureArray[4] = (temperarure.insideTemperature >> 8) & 0xFF;
	temperatureArray[5] = temperarure.insideTemperature & 0xFF;

	temperatureArray[6] = temperarure.outsideHumidity;

	temperatureArray[7] = (temperarure.outsideTemperature >> 8) & 0xFF;
	temperatureArray[8] = temperarure.outsideTemperature & 0xFF;

	temperatureArray[9] = 0;

	for(uint8_t i=0; i<9; i++){
		temperatureArray[9] ^= temperatureArray[i];
	}
	HAL_UART_Transmit_IT(&huart1, temperatureArray, 10);
}

void cmdGetSpRelayState(void)
{
	relaySpArray[0] = beginPacket;
	relaySpArray[1] = 0x03;
	relaySpArray[2] = cmdTypeInfo;
	relaySpArray[3] = cmdGetRelayState;

	relaySpArray[4] = getRelaySP_status();

	relaySpArray[5] = 0;

	for(uint8_t i=0; i<5; i++){
		relaySpArray[5] ^= relaySpArray[i];
	}
	HAL_UART_Transmit_IT(&huart1, relaySpArray, 6);
}

void cmdGetDateNow(void)
{
	//[7E] [05] [02] [F9] [0D]  [08] [14] [CRC]

	dateArray[0] = 0x7E;
	dateArray[1] = 0x05;
	dateArray[2] = cmdTypeInfo;
	dateArray[3] = cmdGetDate;
	dateArray[4] = dateRTC.Date;
	dateArray[5] = dateRTC.Month;
	dateArray[6] = dateRTC.Year;

	dateArray[7] = 0;

	for(uint8_t i=0; i<7; i++){
		dateArray[7] ^= dateArray[i];
	}

	HAL_UART_Transmit_IT(&huart1, dateArray, 8);
}

//**************************** УСТАНОВОЧНІ КОМАНДИ ****************************//

void cmdLenzeSetMaxSpeed(uint8_t axis, uint8_t speed)
{
	if(axis == axisAZ)
	{
		workingSetting.lenzeAzMaxSpeed = speed;
	}
	if(axis == axisEL)
	{
		workingSetting.lenzeElMaxSpeed = speed;
	}
	if(axis == axisPOL)
	{
		workingSetting.polMaxSpeed = speed;
	}

	HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
}

void cmdLenzeSetMinSpeed(uint8_t axis, uint8_t speed)
{
	if(axis == axisAZ)
	{
		workingSetting.lenzeAzMinSpeed = speed;
	}
	if(axis == axisEL)
	{
		workingSetting.lenzeElMinSpeed = speed;
	}
	if(axis == axisPOL)
	{
		workingSetting.polMinSpeed = speed;
	}

	HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
}

void cmdSensorChangeDir(uint8_t axis, uint8_t dir)
{
	uint8_t tmp = 0;
	if(axis == axisAZ)
	{
		tmp = changeModeSensor(axis, dir);
	}
	if(axis == axisEL)
	{
		tmp = changeModeSensor(axis, dir);
	}
	if(axis == axisPOL)
	{
		tmp = changeModeSensor(axis, dir);
	}

	if(tmp == 0x00)
		HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
	else
		HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
}

void cmdSensorSetMulti(uint8_t axis, uint16_t mull, uint16_t div)
{
	uint8_t tmp=0;

	if(axis == axisAZ)
	{
		tmp = setMulti(axisAZ, mull, div);
	}
	if(axis == axisEL)
	{
		tmp = setMulti(axisEL, mull, div);
	}
	if(axis == axisPOL)
	{
		tmp = setMulti(axisPOL, mull, div);
	}

	if(tmp == 0x00)
		HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
	else
		HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
}

void cmdSetSoftLimitSwitch(uint8_t axis, uint16_t lsOne, uint16_t lsTwo)
{
	if(axis == axisAZ)
	{
		 softwareLimitSwitch.softLimitsLeft = lsOne;
		 softwareLimitSwitch.softLimitsRight = lsTwo;
	}
	if(axis == axisEL)
	{
		softwareLimitSwitch.softLimitsTop = lsOne;
		softwareLimitSwitch.softLimitsBottom = lsTwo;
	}
	HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
}

void cmdSetSensorAbsolutePos(uint8_t axis, uint16_t data)
{
	uint8_t tmp = 0;
	uint16_t tmpData = ((float)data/100)/0.00549;
	if(axis == axisAZ)
	{
		tmp = setAbsolutePosition(axisAZ, tmpData);
	}
	if(axis == axisEL)
	{
		tmp = setAbsolutePosition(axisEL, tmpData);
	}
	if(axis == axisPOL)
	{
		tmp = setAbsolutePosition(axisPOL, tmpData);
	}

	if(tmp == 0x00)
		HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
	else
		HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
}

void setSpRelayState(uint8_t relay)
{
	setRelaySP(relay);
	HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
}

void cmdSetDateNow(uint8_t day,uint8_t mouth, uint8_t year)
{
	if (setDate(day, mouth, year) == HAL_OK)
		HAL_UART_Transmit_IT(&huart1, ansverOk, sizeof(ansverOk));
	else
		HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));

}

//***************************** ВИКОНАННЯ КОМАНДИ *****************************//

void moveAxis(uint8_t axis, uint8_t direction, uint8_t speed)
{
	if(axis == axisAZ)
	{
		if(speed > workingSetting.lenzeAzMaxSpeed)
			speed = workingSetting.lenzeAzMaxSpeed;
		if(speed < workingSetting.lenzeAzMinSpeed)
			speed = workingSetting.lenzeAzMinSpeed;
	}

	if(axis == axisEL)
	{
		if(speed > workingSetting.lenzeElMaxSpeed)
			speed = workingSetting.lenzeElMaxSpeed;
		if(speed < workingSetting.lenzeElMinSpeed)
			speed = workingSetting.lenzeElMinSpeed;
	}

	if(axis == axisPOL)
	{
		if(speed > workingSetting.polMaxSpeed)
			speed = workingSetting.polMaxSpeed;
		if(speed < workingSetting.polMinSpeed)
			speed = workingSetting.polMinSpeed;
	}

	if(axis == axisAZ || axis == axisEL)
	{
		if(((hardLimitSwitchStatus & limitSwitchRight) || (softLimitSwitchStatus & softLimitSwitchRight)) && (direction == cmdDirectionCC))
		{
			flagStatus |= flagRight;
			lenzeStartStop(axisAZ, cmdStop);
			HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
		}
		else
			flagStatus &= ~flagRight;

		if(((hardLimitSwitchStatus & limitSwitchLeft) || (softLimitSwitchStatus & softLimitSwitchLeft)) && (direction == cmdDirectionCCW))
		{
			flagStatus |= flagLeft;
			lenzeStartStop(axisAZ, cmdStop);
			HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
		}
		else
			flagStatus &= ~flagLeft;

		if(((hardLimitSwitchStatus & limitSwitchBottom) || (softLimitSwitchStatus & softLimitSwitchBottom)) && (direction == cmdDirectionCC))
		{
			flagStatus |= flagDown;
			lenzeStartStop(axisEL, cmdStop);
			HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
		}
		else
			flagStatus &= ~flagDown;

		if(((hardLimitSwitchStatus & limitSwitchTop) || (softLimitSwitchStatus & softLimitSwitchTop)) && (direction == cmdDirectionCCW))
		{
			flagStatus |= flagTop;
			lenzeStartStop(axisEL, cmdStop);
			HAL_UART_Transmit_IT(&huart1, ansverBad, sizeof(ansverBad));
		}
		else
			flagStatus &= ~flagTop;
		if(axis == axisAZ)
		{
			if((!(flagStatus & flagRight)) && (direction == cmdDirectionCC))
				lenzeDrive(axis, direction, speed);

			if((!(flagStatus & flagLeft)) && (direction == cmdDirectionCCW))
				lenzeDrive(axis, direction, speed);
		}

		if(axis == axisEL)
		{
			if((!(flagStatus & flagTop)) && (direction == cmdDirectionCCW))
				lenzeDrive(axis, direction, speed);

			if((!(flagStatus & flagDown)) && (direction == cmdDirectionCC))
				lenzeDrive(axis, direction, speed);
		}
	}

	if(axis == axisPOL)
	{
		if(direction == cmdDirectionCC)
			startPolCC(speed);
		if(direction == cmdDirectionCCW)
			startPolCW(speed);
	}
}

void stopAxis (uint8_t axis)
{
	if(axis == axisAZ || axis == axisEL)
		lenzeStartStop(axis, cmdStop);
	if(axis == axisPOL)
		stopPol();
}

void driveCord(int32_t axisAz, int32_t axisEl, int32_t axisPol)
{
	driveTo(axisAz, axisEl, axisPol);
}

//***************************************************************************//
//***************************************************************************//



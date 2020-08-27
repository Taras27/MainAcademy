/*********************************************************************************************/
/************************************ BEGIN OF FILE ******************************************/
/*********************************************************************************************/
/*
 * pid.h
 *
 *  Created on: 27 лип. 2020 р.
 *      Author: Horyn
 */

#ifndef PID_H_
#define PID_H_

#include "stdlib.h"

/*********************************************************************************************/
/************************************ PRIVATE TYPEDEFS ***************************************/
/*********************************************************************************************/

typedef struct {

	/* Controller gains */
	float Kp;
	float Ki;
	float Kd;

	/* Derivative low-pass filter time constant */
	float tau;

	/* Output limits */
	float limMin;
	float limMax;

	/* Integrator limits */
	float limMinInt;
	float limMaxInt;

	/* Sample time (in seconds) */
	float T;

	/* Controller "memory" */
	float integrator;
	float prevError;			/* Required for integrator */
	float differentiator;
	float prevMeasurement;		/* Required for differentiator */

	/* Controller output */
	float out;

} PIDController;

/*********************************************************************************************/
/************************************* PRIVATE DEFINES ***************************************/
/*********************************************************************************************/

#define PID_KP  5.0f
#define PID_KI  3.0f
#define PID_KD  10.0f

#define PID_TAU 0.02f

#define PID_LIM_MIN 10.0f
#define PID_LIM_MAX  70.0f

#define PID_LIM_MIN_INT -5.0f
#define PID_LIM_MAX_INT  5.0f

#define SAMPLE_TIME_S 0.1f

/*********************************************************************************************/
/************************************ PRIVATE VARIABLES **************************************/
/*********************************************************************************************/

PIDController PidAz, PidEl, PidPol;


/*********************************************************************************************/
/*********************************** FUNCTION PROTOTYPES *************************************/
/*********************************************************************************************/

void PidInit(PIDController *pid);
float PidUpdate(PIDController *pid, float setpoint, float measurement);

#endif /* PID_H_ */
/*********************************************************************************************/
/************************************** END OF FILE ******************************************/
/*********************************************************************************************/

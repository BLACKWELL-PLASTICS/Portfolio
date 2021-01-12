#include <stdafx.h>

#ifndef __TIMERS_H__
#define __TIMERS_H__

class Timer
{
public :
	static void resetTimer();
	static float tickTimer();
	static float getDeltaTime();
	static float getTotalTime();
};

#endif // !__TIMERS_H__

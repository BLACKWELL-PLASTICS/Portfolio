#include <stdafx.h>
#include "rc_timers.h"

static std::chrono::time_point<std::chrono::system_clock> s_prevTime;
static float s_totalTime;
static float s_deltaTime;

void Timer::resetTimer()
{
	// this sets the previous time to the current time
	s_prevTime = std::chrono::system_clock::now();
	// total time and delta time to 0
	s_totalTime = 0.f;
	s_deltaTime = 0.f;
}
// This calculates all timers
float Timer::tickTimer() 
{
	auto currentTime = std::chrono::system_clock::now();
	std::chrono::duration<float>  tStep = currentTime - s_prevTime;
	s_deltaTime = tStep.count();
	s_totalTime += s_deltaTime;
	s_prevTime = currentTime;
	return s_deltaTime;
}
// returns the Delta Time (time between frames)
float Timer::getDeltaTime()
{
	return s_deltaTime;
}
// returns the Tital Time (time spent in game)

float Timer::getTotalTime()
{
	return s_totalTime;
}
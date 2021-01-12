#pragma once
#ifndef __CONSOLE_H__
#define __CONSOLE_H__

#include <stdafx.h>

class Console
{
public:
	// Constructor / Destructor
	Console();
	~Console();
	// Initialise function to allow for setting up console window and console screen buffer (permissible to fail during
	// initalisation and return false, cannot retunr false from constructor so constructors do as little as possible)
	bool Initialise(const char* a_windowTitle, const unsigned short a_xPos = 0, const unsigned short a_yPos = 0,
		const unsigned short a_width = 0, const unsigned short a_height = 0);

	// Function to write to console window location with data, data length indicates how many characters to write
	// do not pass through number of bytes to write
	unsigned int WriteToLocation(wchar_t* a_data, short a_numCharacters, short a_xPos, short a_yPos);
	//Return handle to console window
	HWND GetConsoleWindowHandle() { return m_consoleWindow; }

private:
	unsigned short m_xPos;
	unsigned short m_yPos;
	unsigned short m_consoleWidth;
	unsigned short m_consoleHeight;

	HANDLE m_consoleHandle;
	HWND m_consoleWindow;
};

#endif // !__CONSOLE_H__

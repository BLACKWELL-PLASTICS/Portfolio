#include <stdafx.h>
#pragma once

#ifndef __INPUT_MANAGER__
#define __INPUT_MANAGER__
// This is the main input handler class, as such it will be a static instance that is accessible from  anywhere in the application
class InputManager
{
public:
	// Our Singleton accessor function call this function to retrive an instance of the input manager
	static InputManager* GetInstance() { return m_instance; }
	// Our Singleton creation function, call this to create an instance of our Input Manager, and return it
	static InputManager* CreateInstance();
	// Destroy Instance this is what we call to delete the instance of our Input Manager 
	static void DestroyInstance();
	// Lest have that function to handle Window callback stuff in our Input Manager, it's a static function 
	static LRESULT CALLBACK HandleWindowCallBacks(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);

	// Set the value of a key in our keystate array
	void SetKey(u8 a_key, bool a_val);
	// Get the current state of the key in our keystate array
	bool GetKeyDown(u8 a_key);

private:
	// this is the static instance of our input manager class
	static InputManager* m_instance;
	// Constructor and Destructor are private, this means that they can only be accessed from within an instance of this class
	// So we cannot call InputManager* im = new InputManager() unless we are within a function belonging to this class!
	InputManager();
	~InputManager() {};

	// An array of 256 bools to keep track of keys that are currently being pressed (or not)
	bool m_keyCurrentState[256];
};

#endif // !__INPUT_MANAGER__

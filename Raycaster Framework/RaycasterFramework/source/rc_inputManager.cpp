#include <stdafx.h>
#include "rc_inputManager.h"
#include "rc_renderer.h"

InputManager* InputManager::m_instance = nullptr;

InputManager* InputManager::CreateInstance()
{
	// If there is no instance of the Input Manager
	if (m_instance == nullptr)
	{
		//Create a new Instance
		m_instance = new InputManager();
	}
	//return the instance
	return m_instance;
}

void InputManager::DestroyInstance()
{
	// if there is an instance of the Input Manager
	if (m_instance != nullptr)
	{
		// Delete it 
		delete m_instance;
		// Set it to a nullptr
		m_instance = nullptr;
	}
}

// This is the default constructor
InputManager::InputManager()
{
	memset(m_keyCurrentState, 0, 256);
}


LRESULT InputManager::HandleWindowCallBacks(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(wParam);
	UNREFERENCED_PARAMETER(lParam);
	PAINTSTRUCT paintStruct;
	HDC hdc;
	// get an instance of the renderer
	Renderer* renderer = Renderer::GetInstance();
	// If the Handle to the window is equal to the renderers window handle
	if (hwnd == renderer->GetWindowHandle())
	{
		// switch on the type of message is being inputted
		switch (message)
		{
		case WM_PAINT:
		{
			hdc = BeginPaint(hwnd, &paintStruct);

			RECT clRect;
			GetClientRect(hwnd, &clRect);
			BitBlt(hdc, clRect.left, clRect.top, (clRect.right - clRect.left) + 1,
				(clRect.bottom - clRect.top) + 1, renderer->GetBufferContext(), 0, 0, SRCCOPY);

			EndPaint(hwnd, &paintStruct);
			break;
		}
		case WM_DESTROY:
		{
			PostQuitMessage(0);
			break;
		}
		case WM_KEYDOWN:
		{
			InputManager* im = InputManager::GetInstance();
			im->SetKey((u8)wParam, true);
			break;
		}
		case WM_KEYUP:
		{
			InputManager* im = InputManager::GetInstance();
			im->SetKey((u8)wParam, false);
			break;
		}
		default:
			return DefWindowProc(hwnd, message, wParam, lParam);
			break;
		}
	}

	return DefWindowProc(hwnd, message, wParam, lParam);
}

// This function is called when the KeyDown case and KeyUp case are activated.
// It changes the value of specific keys are true or false
void InputManager::SetKey(u8 a_key, bool a_val)
{
	m_keyCurrentState[a_key] = a_val;
}

bool InputManager::GetKeyDown(u8 a_key)
{
	return m_keyCurrentState[a_key];
}

// Precompiled Headers
#include <stdafx.h>

// Includes
#include "rc_renderer.h"
#include "rc_console.h"
#include "rc_imageloader.h"
#include "rc_textureManager.h"
#include "rc_player.h"
#include "rc_level.h"
#include "rc_inputManager.h"

// States
#include "rc_gameStateManager.h"
#include "rc_splashState.h"
#include "rc_gameplayState.h"

int main(int argc, char* argv[])
{
	UNREFERENCED_PARAMETER(argv);
	UNREFERENCED_PARAMETER(argc);

	// Set up console for the application
	Console console;
	console.Initialise("Raycaster Console");

	// Creating a Gamestate Manager and a Texture Manager
	GameStateManager* gsManager = new GameStateManager();
	TextureManager* texMan = new TextureManager();

	// Here we create the Splash State,
	SplashState* splashState = new SplashState();
	// Because it is a child class of GameState we get the virtual attributes 
	// which i am setting here
	// State Name
	splashState->SetStateName("SplashState");
	// State Manager
	splashState->SetManager(gsManager);
	// Setting the Texture Manager
	splashState->SetTexMan(texMan);
	// We then push this state to be the active state using the GameState Manager
	gsManager->PushState(splashState);

	// Then create an instance of the Input Manager so that we can take playerinput
	InputManager::CreateInstance();

	// Create a render context window - or Bitmap render window
	u32 windowWidth = 640;
	u32 windowHeight = 480;
	Renderer mainWindow;
	if (!mainWindow.Initalise(console.GetConsoleWindowHandle(), windowWidth, windowHeight))
	{
		Player player;

		MSG msg = { 0 };

		// Create a timer with a current time and previous time to get delta time between frames
		auto currentTime = std::chrono::high_resolution_clock::now();
		auto previousTime = currentTime;
		// Delta time var
		std::chrono::duration<float> elapsedTime;

		unsigned int frame = 0;

		while (msg.message != WM_QUIT)
		{
			if (PeekMessage(&msg, 0, 0, 0, PM_REMOVE))
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
			else
			{
				previousTime = currentTime;
				currentTime = std::chrono::high_resolution_clock::now();
				elapsedTime = currentTime - previousTime;
				// This variable will be used to display the elapsed time of the game
				float fElapsedTime = elapsedTime.count();
				// The gamestate is then set to Update
				gsManager->Update((float)(fElapsedTime));

				// Clear the render buffer
				mainWindow.ClearRenderBuffer();
				
				// Set the Game State to Draw
				gsManager->Draw();
				// Then call the renderers Draw Function
				mainWindow.Draw();

				if (frame % 30 == 0)
				{
					// Buffer to hole FPS Value
					wchar_t fpsBuffer[8];
					unsigned int fps = (unsigned int)(1.0f / fElapsedTime);
					// swprintf_s -- adds a null terminator at n-1, saves us doing it manually
					// Due to this buffer needs to be an additional wchar_t longer.
					// Using a ternary to limit fps display to 999 if over 1000 as not enough charaters in buffer
					swprintf_s(fpsBuffer, 8, L"FPS=%3u", fps > 999 ? 999 : fps);
					console.WriteToLocation(fpsBuffer, 8, 0, 0);
				}
				++frame;
			}
		}
		// Once the game has been quit,
		// Delete the GameState Manager, Input Manager and Texture Manager
		delete gsManager;
		InputManager::DestroyInstance();
		delete texMan;
		return 0;
	}

}



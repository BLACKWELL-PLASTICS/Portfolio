#include <stdafx.h>
#include "rc_splashState.h"
#include "rc_gameStateManager.h"
#include "rc_imageLoader.h"
#include "rc_renderer.h"
#include "rc_gameplayState.h"
#include "rc_textureManager.h"

SplashState::SplashState() : GameState(), m_backgroundImageData(nullptr), m_bgWidth(0), m_bgHeight(0), m_texMan(nullptr), m_texture(nullptr)
{
}

SplashState::~SplashState()
{

}

void SplashState::Initialise(float a_fDT)
{
	UNREFERENCED_PARAMETER(a_fDT);
	// Load the background image for this state
	m_texMan->LoadTexture("../resources/images/TITLE_SCREEN.PCX", RC_ImageType::IM_PCX);

	m_isActive = true;
	m_fTimeInState = 0.f;
	// Change the Process into Update
	Process = &GameState::Update;
}

void SplashState::Update(float a_fDT)
{
	UNREFERENCED_PARAMETER(a_fDT);
	// this variable counts how long we have been in the splash state. 
	m_fTimeInState += a_fDT;
	// once we have been in the state for over 5 seconds
	if (m_fTimeInState > 5.f)
	{
		// reset timer
		m_fTimeInState = 0.f;
		// leave state
		Process = &GameState::Leave;
	}
}

void SplashState::Leave(float a_fDT)
{
	UNREFERENCED_PARAMETER(a_fDT);
	// Firstly we release the textures before we create a new Game State and pass along the Texture Manager
	m_texMan->ReleaseTexture(m_texture);

	// Set up the gameplay state
	GamePlayState* gpState = new GamePlayState();
	// Set the States Name
	gpState->SetStateName("GamePlayState");
	// Set the Game State Manager
	gpState->SetManager(GetManager());
	// Set the Texture Manager
	gpState->SetTexMan(m_texMan);
	// Switch to gameplay state
	GetManager()->PushState(gpState);
	// If we are leaving the state inform the gamestatemanager to remove us
	GetManager()->RemoveState(this);
}

void SplashState::Draw()
{
	// Draw background image
	// Get an instance of the renderer
	Renderer* renderer = Renderer::GetInstance();
	// Get the texture and store it in the Texture Pointer
	m_texture = m_texMan->GetTexture("../resources/images/TITLE_SCREEN.PCX");
	// Create a width and height unsigned int variable for 32 bit
	u32 w, h;
	// Set the dimensions of the texture into the new width and height variables
	m_texture->GetDimensions(w, h);
	// Fill render buffer using the texture pixel data
	renderer->FillRenderBuffer(0, 0, w, h, m_texture->GetPixelData());
	// draw this to renderer
	renderer->Draw();
}
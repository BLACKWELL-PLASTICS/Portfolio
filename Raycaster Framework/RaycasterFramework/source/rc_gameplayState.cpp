#include <stdafx.h>
#include "rc_gameplayState.h"
#include "rc_gameStateManager.h"
#include "rc_imageLoader.h"
#include "rc_renderer.h"
#include "rc_player.h"
#include "rc_level.h"
#include "rc_textureManager.h"

GamePlayState::GamePlayState() : GameState(), m_pLevel(nullptr), m_pPlayer(nullptr), m_texMan(nullptr)
{
	// Once this constructor is called, the State Process then moves to Initialise
	Process = &GameState::Initialise;
}

GamePlayState::~GamePlayState()
{
	if (m_pLevel)
	{
		delete m_pLevel;
		delete m_pPlayer;
	}
}

void GamePlayState::Initialise(float a_fDT)
{
	UNREFERENCED_PARAMETER(a_fDT);
	// I am creating a pointer to the Level
	m_pLevel = new Level();
	// Passing the texture manager to the Level
	m_pLevel->SetTexMan(m_texMan);
	// Then load the first map
	if (m_pLevel->LoadLevel("../resources/firstLevel.map"))
	{
		// I am creating a pointer to the Player
		m_pPlayer = new Player();
		m_isActive = true;
		// Then change the GameState to Update
		Process = &GameState::Update;
	}
}

void GamePlayState::Update(float a_fDT)
{
	UNREFERENCED_PARAMETER(a_fDT);
	// Here i am calling the player update function
	m_pPlayer->Update(a_fDT, m_pLevel); 
}

void GamePlayState::Leave(float a_fDT)
{
	UNREFERENCED_PARAMETER(a_fDT);
	// If we are leaving the state inform the gamestatemanager to remove us
	GetManager()->RemoveState(this);
}

void GamePlayState::Draw()
{
	// I am then getting an instance of the renderer
	Renderer* renderer = Renderer::GetInstance();
	unsigned int ceilingColour = 0x00505050;
	unsigned int floorColour = 0x00B2B2B2;
	// Filling the render buffer for the ceiling and floor
	renderer->FillRenderBuffer(0, 0, 640, 480, ceilingColour);
	renderer->FillRenderBuffer(0, 0, 640, 480, floorColour);
	// Draw level
	m_pLevel->Draw(m_pPlayer);
}
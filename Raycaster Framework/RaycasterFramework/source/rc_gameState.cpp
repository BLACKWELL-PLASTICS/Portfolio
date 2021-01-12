#include <stdafx.h>
#include "rc_gameState.h"
#include "rc_gameStateManager.h"

GameState::GameState() : m_Name(nullptr), m_fTimeInState(0.f), m_isActive(false), m_pManager(nullptr)
{
	// Set the current process function pointer to point to initialise
	Process = &GameState::Initialise;
}

GameState::~GameState()
{
	if (m_Name != nullptr)
	{
		delete[] m_Name;
		m_Name = nullptr;
	}
}

// Empty Draw function
void GameState::Draw()
{
}

// Set the States Name
void GameState::SetStateName(const char* a_pStateName)
{
	// If the State Name is null
	if (m_Name == nullptr)
	{
		u32 l = (u32)strlen(a_pStateName);
		// Allocate l+1 as null terminator is required
		m_Name = new char[l + 1];
		strcpy(m_Name, a_pStateName);
	}
}
// Get the name of the state
const char* GameState::GetStateName()
{
	return m_Name;
}

// Set the State Manager
void GameState::SetManager(GameStateManager* a_pManager)
{
	m_pManager = a_pManager;
}

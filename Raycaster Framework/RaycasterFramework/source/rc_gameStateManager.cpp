#include <stdafx.h>
#include "rc_gameState.h"
#include "rc_gameStateManager.h"

GameStateManager::GameStateManager()
{
	m_pStates.clear();
	m_pStatesToFree.clear();
}

GameStateManager::~GameStateManager()
{
	for (auto iter = m_pStatesToFree.begin(); iter != m_pStatesToFree.end(); ++iter)
	{
		GameState* pState = (*iter);
		delete pState;
		pState = nullptr;
	}
	m_pStatesToFree.clear();

	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		GameState* pState = (*iter);
		delete pState;
		pState = nullptr;
	}
	m_pStates.clear();
}

void GameStateManager::Update(float a_fDT)
{
	if (m_pStatesToFree.size() > 0)
	{
		for (auto iter = m_pStatesToFree.begin(); iter != m_pStatesToFree.end(); ++iter)
		{
			GameState* pState = (*iter);
			delete pState;
			pState = nullptr;
		}
		m_pStatesToFree.clear();
	}

	// Iterate through the states currently in the stack and call their process function
	for (auto iter = m_pStates.rbegin(); iter != m_pStates.rend(); ++iter)
	{
		u32 popStates = (u32)(m_pStatesToFree.size());
		// Calling a member function pointer
		void (GameState:: * func)(float) = (*iter)->Process;
		((*iter)->*func)(a_fDT);
		if (m_pStatesToFree.size() != popStates)
		{
			break;
		}
	}
}

void GameStateManager::Draw()
{
	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		if ((*iter)->IsActive())
		{
			(*iter)->Draw();
		}
	}
}

bool GameStateManager::RemoveState(GameState* a_pState)
{
	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		GameState* pState = (*iter);
		if (pState == a_pState)
		{
			m_pStatesToFree.push_back(pState);
			m_pStates.erase(iter);
			return true;
		}
	}
	return false;
}

bool GameStateManager::PopToState(GameState* a_pState)
{
	// Loop through the states and count how many need to be popped
	int i = 0;
	bool stateFound = false;
	for (std::vector<GameState*>::reverse_iterator iter = m_pStates.rbegin(); iter != m_pStates.rend(); ++iter, ++i)
	{
		if ((*iter) == a_pState)
		{
			stateFound = true;
			break;
		}
	}

	if (stateFound)
	{
		for (int j = i; j > 0; --j)
		{
			GameState* pLastState = m_pStates.back();
			m_pStatesToFree.push_back(pLastState);
			m_pStates.pop_back();
		}
	}

	return stateFound;
}

void GameStateManager::PushToState(GameState* a_pState)
{
	if (a_pState)
	{
		m_pStates.push_back(a_pState);
	}
}

void GameStateManager::PopState()
{
	if (m_pStates.size() > 0)
	{
		GameState* pLastState = m_pStates.back();
		m_pStatesToFree.push_back(pLastState);

		m_pStates.pop_back();
	}
}

GameState* GameStateManager::StateExists(const char* a_pStateName)
{
	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		GameState* pState = (*iter);
		const char* pName = pState->GetStateName();
		if (pName != nullptr && strcmp(pName, a_pStateName) == 0)
		{
			return pState;
		}
	}
	return nullptr;
}

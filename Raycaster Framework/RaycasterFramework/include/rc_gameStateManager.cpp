#include <stdafx.h>
#include "rc_gameState.h"
#include "rc_gameStateManager.h"


// When a manager is created
GameStateManager::GameStateManager()
{
	// Clear the States and States to Free
	m_pStates.clear();
	m_pStatesToFree.clear();
}
// When the manager is destroyed
GameStateManager::~GameStateManager()
{
	// Iterate through the states to free
	for (auto iter = m_pStatesToFree.begin(); iter != m_pStatesToFree.end(); ++iter)
	{
		GameState* pState = (*iter);
		// Delete the state
		delete pState;
		// Set the state to a nullptr 
		pState = nullptr;
	}
	m_pStatesToFree.clear();

	// Iterate through the states
	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		GameState* pState = (*iter);
		// Delete the state
		delete pState;
		// Set the state to a nullptr
		pState = nullptr;
	}
	m_pStates.clear();
}

void GameStateManager::Update(float a_fDT)
{
	if (m_pStatesToFree.size() > 0)
	{
		// Looks like we have some states to free
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
		// If we modify the states stack during an update we invalidate the iterator.
		// Best to bail out and start again next frame
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
	// iterate through the states existing and set them to Draw
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
	// iterate through the states existing
	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		GameState* pState = (*iter);
		// if the state passed in this iteration is the same state as passed in
		if (pState == a_pState)
		{
			//push this state into the states to free list
			m_pStatesToFree.push_back(pState);
			// erase the iterated state
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
			// Set stateFound to true if the iterated state is equal to the passed in state
			stateFound = true;
			break;
		}
	}

	if (stateFound)
	{
		// Count down from the end and pop states of until j = 0
		for (int j = i; j > 0; --j)
		{
			// Get the last state and push it into the states to clear next frame
			GameState* pLastState = m_pStates.back();
			m_pStatesToFree.push_back(pLastState);
			m_pStates.pop_back();
		}
	}
	// return the state which has been found
	return stateFound;
}

void GameStateManager::PushState(GameState* a_pState)
{
	// if a_pState = true
	if (a_pState)
	{
		// push the state back
		m_pStates.push_back(a_pState);
	}
}
// Pop the top state off the stack
void GameStateManager::PopState()
{
	if (m_pStates.size() > 0)
	{
		GameState* pLastState = m_pStates.back();
		m_pStatesToFree.push_back(pLastState);

		m_pStates.pop_back();
	}
}

// Finding if the state exists
GameState* GameStateManager::StateExists(const char* a_pStateName)
{
	for (auto iter = m_pStates.begin(); iter != m_pStates.end(); ++iter)
	{
		GameState* pState = (*iter);
		const char* pName = pState->GetStateName();
		// If the state name is equal to the state name found through the iterator
		if (pName != nullptr && strcmp(pName, a_pStateName) == 0)
		{
			// Return the state found
			return pState;
		}
	}
	// else return nothing
	return nullptr;
}

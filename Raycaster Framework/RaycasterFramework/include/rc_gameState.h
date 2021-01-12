
#include <stdafx.h>
#pragma once
#ifndef __GAME_STATE_H__
#define __GAME_STATE_H__

// Forward declaration for the GameStateManager class so that states can inform the manager to remove them
class GameStateManager;

// This is a virtual state class that base classes will inherit from
// This is an abstract class, not a concrete class
class GameState
{
public:
	GameState();
	virtual ~GameState();
	// all function for states below
	virtual void Initialise(float a_fDT) = 0;
	virtual void Update(float a_fDT) = 0;
	virtual void Leave(float a_fDT) = 0;

	virtual void Draw();

	void SetStateName(const char* a_name);
	const char* GetStateName();

	void SetManager(GameStateManager* a_pManager);
	GameStateManager* GetManager() { return m_pManager; }
	bool IsActive() { return m_isActive; }
	// This is a function pointer to a member function that represents 
	// the imediate process of this state
	void (GameState::* Process)(float); 

private:
	char* m_Name;
	GameStateManager* m_pManager;

protected:
	// Protected variables are able to be modified by child classes that 
	// publically inherit from GameState
	float m_fTimeInState;
	bool m_isActive;

};

#endif // !__GAME_STATE_H__


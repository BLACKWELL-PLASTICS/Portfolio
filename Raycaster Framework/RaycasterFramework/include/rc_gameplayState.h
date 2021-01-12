#include <stdafx.h>
#include "rc_gameState.h"
#pragma once
 
#ifndef __GAME_PLAY_STATE_H__
#define __GAME_PLAY_STATE_H__

class Player;
class Level;
class TextureManager;

class GamePlayState : public GameState
{
public:
	GamePlayState();
	virtual ~GamePlayState();

	//define the virtual parent methods and implement them in the source file
	virtual void Initialise(float a_fDT);
	virtual void Update(float a_fDT);
	virtual void Leave(float a_fDT);

	virtual void Draw();

	void SetTexMan(TextureManager* a_texManager) { m_texMan = a_texManager; }

private:

	Level* m_pLevel;
	Player* m_pPlayer;

	TextureManager* m_texMan;

};
#endif // !__GAME_PLAY_STATE_H__

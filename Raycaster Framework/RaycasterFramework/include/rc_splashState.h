#include <stdafx.h>
#include "rc_gameState.h"
#pragma once

#ifndef __SPLASH_STATE_H__
#define __SPLASH_STATE_H__

class TextureManager;
class Texture;

class SplashState : public GameState
{
public :
	SplashState();
	virtual ~SplashState();

	//define the virtual parent methods and implement them in the source file
	virtual void Initialise(float a_fDT);
	virtual void Update(float a_fDT);
	virtual void Leave(float a_fDT);

	virtual void Draw();
	void SetTexMan(TextureManager* a_texManager) { m_texMan = a_texManager; }

private:
	void* m_backgroundImageData;
	u32 m_bgWidth;
	u32 m_bgHeight;

	TextureManager* m_texMan;
	Texture* m_texture;
};

#endif // !__SPLASH_STATE_H__

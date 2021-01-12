#include <stdafx.h>
#pragma once
#ifndef __RC_LEVEL_H__
#define __RC_LEVEL_H__

class Player;
class Texture;
class TextureManager;

class Level
{
public:
	Level();
	~Level();

	void GetSize(u32& a_w, u32& a_h);
	u8 GetGridValue(u32 a_x, u32 a_y);

	bool LoadLevel(const char* a_filename);

	void Draw(const Player* a_player);

	void SetTexMan(TextureManager* a_texManager) { m_texMan = a_texManager; }

private:
	u32 m_width;
	u32 m_height;

	u8* m_map;

	Texture* m_texture;
	TextureManager* m_texMan;
};

#endif // !__RC_LEVEL_H__

#include <stdafx.h>
#include "rc_texture.h"
#pragma once
#ifndef __TEXTURE_MANAGER_H__
#define __TEXTURE_MANAGER_H__


// Forward declaration for a texture class
class Texture;

class TextureManager
{
public:
	TextureManager();
	~TextureManager();

	// Function to test if a texture exists in memory
	bool TextureExists(const char* a_filename);
	// Load a texture from a filename
	Texture* LoadTexture(const char* a_filename, u32 a_format);
	Texture* GetTexture(const char* a_filename);

	void ReleaseTexture(Texture* a_pTexture);

private:
	// As small structure to reference count a texture
	// reference count indicates how many pointers are
	// currently pointing to this texture
	typedef struct TextureRef
	{
		Texture* pTexture;
		unsigned int refCount;
	}TextureRef;

	std::map<std::string, TextureRef> m_pTextureMap;

};

#endif // !__TEXTURE_MANAGER_H__

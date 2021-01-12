#include <stdafx.h>
#include "rc_textureManager.h"

TextureManager::TextureManager() : m_pTextureMap()
{
}

TextureManager::~TextureManager()
{
	// Need to iterate through the texturemap and
	// remove any references to images and unload
	m_pTextureMap.clear();
}

// Load Texture
// Uses and std map as a texture dictionary to track loaded textures
// attempts to load a texture already in memeory will increment
// a ref count for that texture
Texture* TextureManager::LoadTexture(const char* a_filename, u32 a_format)
{
	Texture* pTexture = nullptr;

	if (a_filename != nullptr)
	{
		std::map<std::string, TextureRef>::iterator dictionaryIter =
			m_pTextureMap.find(a_filename);
		if (dictionaryIter != m_pTextureMap.end())
			// If iterator is not at the end, then texture was located
		{
			TextureRef& texRef = (TextureRef&)(dictionaryIter->second);
			// Get reference to texture ref struct
			pTexture = texRef.pTexture;
			++texRef.refCount;
		}
		else
		{
			// Better load the texture in as its not in the texture map yet
			pTexture = new Texture();
			if (pTexture->Load(a_filename, a_format))
			{
				// Load successful place into texRef structure
				// and insert into dictionary.
				TextureRef texRef = { pTexture, 1 };
				m_pTextureMap[a_filename] = texRef;
			}
			else { delete pTexture; pTexture = nullptr; }
			// Load failed free memory and reset to nullptr
		}
	}

	return pTexture;
}



// Remove a texture from memory
// This will either unload the texture or simply decrement
// its reference count until this reaches 0 and then upload
void TextureManager::ReleaseTexture(Texture* a_pTexture)
{
	for (auto dictionaryIter = m_pTextureMap.begin();
		dictionaryIter != m_pTextureMap.end(); ++dictionaryIter)
	{
		TextureRef& texRef = (TextureRef&)(dictionaryIter->second);
		if (a_pTexture == texRef.pTexture) // Found the texture to remove
		{
			// Predecrement will be evaluated before call to <=
			// -- it's safe code could be seperated into two lines if you want to
			if (--texRef.refCount == 0)
			{
				delete texRef.pTexture;
				texRef.pTexture = nullptr;
				m_pTextureMap.erase(dictionaryIter);
				break; // Escape the for loop to return
			}
		}
	}
}

bool TextureManager::TextureExists(const char* a_filename)
{
	auto dictionaryIter = m_pTextureMap.find(a_filename);
	if (dictionaryIter != m_pTextureMap.end())
		// If iterator is not at the end then texture was located
	{
		return true;
	}

	return false;
}

// return a pointer to the texture and increments the reference count
Texture* TextureManager::GetTexture(const char* a_filename)
{
	Texture* pTexture = nullptr;
	auto dictionaryIter = m_pTextureMap.find(a_filename);
	if (dictionaryIter != m_pTextureMap.end())
		// If iterator is not at the end then texture was located
	{
		TextureRef& texRef = (TextureRef&)(dictionaryIter->second);
		// Get reference to texture ref struct
		texRef.refCount++;
		pTexture = texRef.pTexture;
	}

	return pTexture;
}
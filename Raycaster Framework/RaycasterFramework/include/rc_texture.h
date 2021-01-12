#include <stdafx.h>
#pragma once
#ifndef __TEXTURE_H__
#define __TEXTURE_H__
// A class to store texture data
// A texture is just a data buffer that contrains some pixel values
// Values are specified by member variables of the texture class

class Texture
{
public:
	// Constructor & Destructor
	Texture();
	~Texture();

	// Functionality to load a texture from a provided file name
	bool Load(const char* a_filename, u32 a_format);

	// Getters to retrieve texture information
	const std::string& GetFileName() const { return m_filename; }
	void GetDimensions(u32& a_width, u32& a_height) const;
	u8 GetBPP() { return m_bpp; }
	// Get the pallete information from the image 
	// return value is palette count,
	// parameter returns pointer to palette data in R8G8B8 format.
	u16 GetPalette(void* a_palette);
	void* GetPixelData() { return m_pixelData; }

private:
	std::string m_filename;
	u32 m_width;
	u32 m_height;
	u16 m_paletteSize; 
	u8 m_bpp;
	void* m_palette;
	void* m_pixelData;

};

#endif // !__TEXTURE_H__


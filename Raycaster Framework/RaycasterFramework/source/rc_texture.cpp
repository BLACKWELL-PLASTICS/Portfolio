#include <stdafx.h>
#include "rc_texture.h"
#include "rc_imageLoader.h"

Texture::Texture() :
	m_filename(""), m_width(0), m_height(0),
	m_bpp(0), m_paletteSize(0), m_palette(nullptr), m_pixelData(nullptr)
{
}

Texture::~Texture()
{
	// If these are not null than an image was loaded, call delete[] on them
	if (m_palette) { delete[] m_palette; m_palette = nullptr; }
	if (m_pixelData) { delete[] m_pixelData; m_pixelData = nullptr; }
}

bool Texture::Load(const char* a_filename, u32 a_format)
{
	// Fill this Void pointer with the data from the image which is being loaded from file
	m_pixelData = ImageLoader::LoadFromFile(a_filename, a_format,
		m_width, m_height, m_bpp, m_palette);
	if (m_pixelData)
	{
		// if the pixel data exists
		// set the filename to the passed in filename
		m_filename = a_filename;
		return true;
	}
	// else set everything to 0 and return false
	m_width = m_height = 0;
	m_bpp = 0;
	m_paletteSize = 0;
	return false;
}

void Texture::GetDimensions(u32& a_width, u32& a_height) const
{
	// Get the width and height variables which were passed in equal to the textures width and height
	a_width = m_width;
	a_height = m_height;
}

u16 Texture::GetPalette(void* a_palette)
{
	// Get the pallete data
	a_palette = m_palette;
	return m_paletteSize;
}


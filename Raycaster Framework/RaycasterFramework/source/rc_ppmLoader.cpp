#include <stdafx.h>
#include "..\include\rc_ppmLoader.h"
#pragma once

PPMLoader::PPMLoader()
{
}
// This function has been added in from the tutorial we did in class
void* PPMLoader::LoadFromFile(std::fstream* a_stream, u32& a_w, u32& a_h, u8& a_bpp, void*& a_imgPalette)
{
	UNREFERENCED_PARAMETER(a_imgPalette);
	UNREFERENCED_PARAMETER(a_bpp);
	UNREFERENCED_PARAMETER(a_h);
	UNREFERENCED_PARAMETER(a_w);
	UNREFERENCED_PARAMETER(a_stream);

	std::fstream file;

	PPM image;
	// Read in first two bytes of file reading as text
	char buffer[512];
	memset(buffer, 0, 512);
	file.getline(buffer, 512);
	//unsigned short id;
	memcpy(&image.id, buffer, 2);
	if (image.id != 13904)
	{
		file.close();
		return NULL;
	}
	// Get the comment line out of the file
	// All files have a comment, line just not always a comment following the #
	memset(buffer, 0, 512);
	file.getline(buffer, 512);

	if (buffer[0] == '#')
	{
		// This file has a comment
		memcpy(image.comment, buffer, 512);
		std::cout << image.comment << std::endl;
	}

	// Read in images dimensions
	file >> image.width >> image.height;
	file >> image.maxColours;
	file.ignore(1);

	// Create a PPM image object to store pixel data
	unsigned int pixelSize = 0;
	if (image.maxColours > 255)
	{
		image.pixelData = new PPMPixel<unsigned short>[image.width * image.height];
		pixelSize = image.width * image.height * sizeof(PPMPixel<unsigned short>);
	}
	else
	{
		image.pixelData = new PPMPixel<unsigned char>[image.width * image.height];
		pixelSize = image.width * image.height * sizeof(PPMPixel<unsigned char>);

	}

	file.read((char*)image.pixelData, pixelSize);
	
	file.close();

	return image.pixelData;
	 
}

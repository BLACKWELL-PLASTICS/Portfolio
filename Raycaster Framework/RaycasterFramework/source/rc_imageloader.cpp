#include <stdafx.h>
#include "rc_imageloader.h"
#include "rc_pcxloader.h"
#include "rc_ppmloader.h"

void* ImageLoader::LoadFromFile(const char* a_filename, u32 a_type, u32& a_w, u32& a_h, u8& a_bpp, void*& a_imgPallet)
{
	//get a filestream
	std::fstream file;
	file.open(a_filename, std::ios_base::in | std::ios_base::binary);
	if (file.is_open())
	{
		// Success file has been opened, verify contents of file
		file.ignore(std::numeric_limits<std::streamsize>::max());
		std::streamsize filelength = file.gcount(); // Gets the size of the file in bytes
		file.clear(); // Ignore EOF file flag that was previously set by reading whole file
		file.seekg(0, std::ios_base::beg);
		if (filelength == 0) // If file has no bytes then dont try process it
		{
			file.close();
			return nullptr;
		}
		void* imageData = nullptr;
		switch (a_type)
		{
		case IM_BITMAP:
		{
			break;
		}
		case IM_PCX:
		{
			// This loads the image
			imageData = PCXLoader::LoadFromFile(&file, a_w, a_h, a_bpp, a_imgPallet);
			// If the bits per pixel are not 32 then convert them to 32 BPP
			if (a_bpp != 32)
			{
				imageData = PCXLoader::ConvertTo32bpp(imageData, a_imgPallet, a_w, a_h, a_bpp);
			}
			break;
		}
		case IM_PPM: // This has been added in from the tutorial in class
		{
			imageData = PPMLoader::LoadFromFile(&file, a_w, a_h, a_bpp, a_imgPallet);
			break;
		}
		default:
		{		
			// if the case defaults, close the stream and then return nullptr
			file.close();
			return nullptr;
			break;
		}
		}
		// this is here to make sure we always close the file stream
		file.close();
		return imageData;
	}
	// file has failed to open, return nullptr
	return nullptr;
}

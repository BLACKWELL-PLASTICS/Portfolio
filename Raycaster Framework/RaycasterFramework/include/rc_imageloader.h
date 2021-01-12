#include <stdafx.h>

#ifndef __IMAGE_LOADER_H__
#define __IMAGE_LOADER_H__

typedef enum RC_ImageType
{
	IM_PCX,
	IM_PPM,
	IM_BITMAP,

	IM_MAX
}RC_ImageType;

class ImageLoader
{
public:
	ImageLoader() {};		// Default constructor - no real functionality
	~ImageLoader() {};		// Default Destructor - no additional functionality

	// A static function to load an image from a provided file
	// Both the retuned inamge ipxel data and the palette data will need to be freed by the caller with a delete[] operator
	/*!
		\param a_filename The filenmae and path of the image to load
		\param a_width a reference that will be used to store the width in pixels of the image
		\param a_height a reference that will be used to store the height in pixels of the image
		\param a_bpp a reference to store the number of bits per pixel for the image
		\param a_paletteData a reference pointer to the palette data that may be loaded with the image,
			for non-palettised images pass in nullptr
		\return returns a void pointer to the image pixel data that has been extracted from the file
	
	*/
	static void* LoadFromFile(const char* a_filename, u32 a_type, u32& a_w, u32& a_h, u8& a_bpp, void*& a_imgPallet);

private:

};


#endif //!__IMAGE_LOADER_H__
#include <stdafx.h>
#include "rc_pcxLoader.h"

int PCX_getEncodedByte(u8& a_value, u8& a_frequency, std::fstream* a_stream)
{
	if (a_stream->peek() == EOF)					// Safety First, test for unexpecred file
	{
		return EOF;
	}
	a_frequency = 1;								// As a default set frequency to a value of 1
	a_stream->read((char*)(&a_value), 1);			// read in one character from file
	if ((a_value & PCX_RLE_MASK) == PCX_RLE_MASK)	// test to see if value is a run length frequency 
	{
		a_frequency = a_value & PCX_RLE_FREQ_MASK;	// this is a run length and not a value use requency mask to convert
		if (a_stream->peek() == EOF)				// Safety first, test for unexpected end of file
		{
			return EOF;
		}
		a_stream->read((char*)(&a_value), 1);		// Read the next byte to get the pixel value
	}
	return 0;
}

// A function for loading a PCX image, returns pointer to raw image data
	//param a_stream a constant void pointer to the filestream to read from
	//param a_width a integer reference for the width in pixels of the image the load function will populate this value
	//param a_height a integer reference for the hight in pixels of the image the load function will populate this value
	//param a_bitsPerPixel an integer reference for the number of bits per pixel
	// param a_imagePallette pointer to image palette data stored in RGB format, for non palettised images pass nullptr as parameter
	// return the raw image data

void* PCXLoader::LoadFromFile(std::fstream* a_stream, u32& a_w, u32& a_h, u8& a_bpp, void*& a_imgPalette)
{

	std::fstream* file = (std::fstream*)(a_stream); // Get pointer to filestream
	PCXHeader header;
	// Read 128 bytes from file
	file->read((char*)(&header), sizeof(PCXHeader));

	// check for valid header
	if (header.identifier != PCX_VALID_HEADER || header.encoding != PC_RLE_ENCODING)
	{
		file->close();
		return nullptr;
	}
	// This is a valid pcx continue loading
	// Get palette info if present
	if (header.version == 3)
	{
		// Ver 3 had no palette and used a different one
		u8* egaPalette = (u8*)(header.colourPalette);
		for (int i = 0; i < 48; ++i)
		{
			egaPalette[i] = PCX_defaultPalette[i];
		}
	}
	if (header.bitsPerPixel == 8)
	{
		// If there are less than 8 bpp no palette data outside existing data
		file->seekg(PCX_VGA_PALETTE_OFFSET, std::ios_base::end);	// Seek to the palette offset location
		char paletteIndicator = 0;
		file->read(&paletteIndicator, 1);							// Read in the single byte at this offset location
		if (paletteIndicator == 0xC)								// if byte read in is 0xC then we have a palette 
		{
			// we have a palette at the end fo the file proceed to read palette data from file
			a_imgPalette = new PCXHeader::PCXPaletteColour[256];
			file->read((char*)a_imgPalette, 256 * sizeof(PCXHeader::PCXPaletteColour));

		}
		file->clear();
		file->seekg(0, std::ios_base::beg);
		file->seekg(sizeof(PCXHeader), std::ios_base::beg);			// seek from the beggining of the file to the end of the PCX header
	}
	// if we get here and a_palette is still null then allocate memory for 16 colour palette
	if (!a_imgPalette && (header.numColourPlanes * header.bitsPerPixel) < 24)
	{
		// We havent allocated a palette use the header palette info
		a_imgPalette = new PCXHeader::PCXPaletteColour[16];
		memcpy(a_imgPalette, header.colourPalette, 48);
	}
	// Get the pixel size of the image
	a_w = header.dimensions.right - header.dimensions.left + 1;
	a_h = header.dimensions.bottom - header.dimensions.top + 1;
	a_bpp = header.bitsPerPixel * header.numColourPlanes;
	// size of the decompressed iamge in bytes
	u32 bytesInRow = (u32)(a_w * (float)(a_bpp / 8.0f));
	u32 decompImageSize = a_h * bytesInRow;
	// The way we will process the omage data is to decompress one image scanline at a time
	// Number of bytes in a decompressed scanline (when  colour planes greater than 1 bytes per scanline give split between R/G/B values)
	u32 decompScanLine = header.bytesPerScanline * header.numColourPlanes;
	// PCX images may contain some line padding - calculate line padding
	u32 scanLinePadding = decompScanLine - bytesInRow;
	u32 actualBytesPerImageRow = decompScanLine - scanLinePadding;
	// Create a data buffer large enough to hold the decompressed image
	u8* imageData = new u8[decompImageSize];
	memset(imageData, 0, decompImageSize);
	u8* scanLineData = new u8[decompScanLine];
	memset(scanLineData, 0, decompScanLine);

	// Create some stack variables to hold the value and frequency for the data read from file
	u8 value = 0; // The current pixel value to be decoded
	u8 frequency = 0; // The frequency/occurences of this pixel value
	// While all of the image data has not been extracted
	u32 bytesProcessed = 0;
	std::streamsize streamLocation;
	u32 row = 0;
	while ( row < a_h-1 )
	{
		streamLocation = file->tellg();
		for (u8* slp = scanLineData; slp < (scanLineData + decompScanLine);)
		{
			if (EOF == PCX_getEncodedByte(value, frequency, file))
			{
				// If file ends suddenly release and null data
				delete[] imageData;
				imageData = nullptr;

				if (!a_imgPalette)
				{
					// If there is no image pallet
					// delete the image palette data
					delete[] a_imgPalette;
					// make the image palette variable a null pointer
					a_imgPalette = nullptr;
				}
				return imageData;
			}
			for (u8 i = 0; i < frequency; ++i)
			{
				*slp++ = value;
			}
		}
		++row;
		// Completeing the above for loop gives us one scanline of data decompressed to copy into our image buffer
		// Now copy off numbers of colour planes
		if (header.numColourPlanes != 1)
		{
			// Scan line is broken down into rrrrr... ggggg... bbbbb... (aaaaa)...
			// Need to iterate through this image and copy across data to appropriate rgb channels
			u8* red = scanLineData;
			u8* green = scanLineData + header.bytesPerScanline;
			u8* blue = scanLineData + (header.bytesPerScanline * 2);
			u8* alpha = header.numColourPlanes == 4 ? scanLineData + (header.bytesPerScanline * 3) : nullptr;

			for (u32 processedBytes = bytesProcessed; processedBytes < (bytesProcessed + actualBytesPerImageRow);)
			{
				if (header.bitsPerPixel == 8)
				{
					imageData[processedBytes + 0] = *red++;
					imageData[processedBytes + 1] = *green++;
					imageData[processedBytes + 2] = *blue++;
					if (alpha != nullptr)
					{
						imageData[processedBytes + 3] = *alpha++;
					}
					processedBytes += header.numColourPlanes;
				}
				else
				{
					// Format not supported YET
				}
			}			
		}
		else
		{
			memcpy(&imageData[bytesProcessed], scanLineData, actualBytesPerImageRow);
		}
		bytesProcessed += actualBytesPerImageRow;
	}

	return imageData;
}

// If the Bits Per Pixel of the PCX image that is loaded isnt 32 this function is called
void* PCXLoader::ConvertTo32bpp(void* a_imageData, void* a_palette, u32& a_w, u32& a_h, u8& a_bpp)
{
	u8* rawImage = new u8[a_w * a_h * 4]; // Allocate enough memory for raw iamge data in RGBA format
	u32 currentDataSize = a_w * (u32)(a_h * ((float)a_bpp / 8.f));
	u8* currentImage = (u8*)a_imageData;

	if (a_palette != nullptr) // Convert a palettised image
	{
		PCXHeader::PCXPaletteColour* palette = (PCXHeader::PCXPaletteColour*)a_palette;
		// for each pixel in the current data set
		for (u32 pixel = 0, i = 0; pixel < currentDataSize; ++pixel, i += 4)
		{
			u8 pi = currentImage[pixel];
			if (a_bpp == 8)
			{
				rawImage[i + 0] = palette[pi].B;
				rawImage[i + 1] = palette[pi].G;
				rawImage[i + 2] = palette[pi].R;
				rawImage[i + 3] = 0;
			}
			else if (a_bpp == 4)
			{
				rawImage[i + 0] = palette[(pi >> 4) & 0xF].B;
				rawImage[i + 1] = palette[(pi >> 4) & 0xF].G;
				rawImage[i + 2] = palette[(pi >> 4) & 0xF].R;
				rawImage[i + 3] = 0;
				i += 4;
				rawImage[i + 0] = palette[pi & 0xF].B;
				rawImage[i + 1] = palette[pi & 0xF].G;
				rawImage[i + 2] = palette[pi & 0xF].R;
				rawImage[i + 3] = 0;
			}
			else
			{
				// Not Supported Format yet
			}
		}
	}
	else // Convert an RGB image to RGBA
	{
		for (u32 pixel = 0, i = 0; pixel < currentDataSize; pixel += 3, i += 4)
		{
			rawImage[i + 0] = currentImage[pixel + 2];
			rawImage[i + 1] = currentImage[pixel + 1];
			rawImage[i + 2] = currentImage[pixel + 0];
			rawImage[i + 3] = 0;
		}
	}

	delete[] a_imageData;
	a_imageData = nullptr;
	delete[] a_palette;
	a_palette = nullptr;

	return rawImage;
}

#include <stdafx.h>
#pragma once

#ifndef __PCX_LOADER_H__
#define __PCX_LOADER_X__

#define PCX_VALID_HEADER 10
#define PC_RLE_ENCODING 1
#define PCX_VGA_PALETTE_OFFSET -769
#define PCX_RLE_MASK 0xC0 // 0b1100 0000
#define PCX_RLE_FREQ_MASK 0x3F // 0b0011 1111

// Default EGA palette for PCX images (v3)
const u8 PCX_defaultPalette[48] = {
	0x00, 0x00, 0x00,	0x00, 0x00, 0x80,	 0x00, 0x80, 0x00,
	0x00, 0x80, 0x80,	0x80, 0x00, 0x00,	 0x80, 0x00, 0x80,
	0x80, 0x80, 0x00,	0x80, 0x80, 0x80,	 0xC0, 0xC0, 0xC0,
	0x00, 0x00, 0xFF,	0x00, 0xFF, 0x00,	 0x00, 0xFF, 0xFF,
	0xFF, 0x00, 0x00,	0xFF, 0x00, 0xFF,	 0xFF, 0xFF, 0x00,
	0xFF, 0xFF, 0xFF
};
typedef struct PCXHeader
{
	u8						identifier;			// PCX Id number (always 0x0A)
	u8						version;			// Version number
	u8						encoding;			// Encoding (always 1 no other value used)
	u8						bitsPerPixel;		// bits per pixel (1, 2, 4, 8)
	struct PCXDimensions { u16 left; u16 top; u16 right; u16 bottom; }
	dimensions;									// image dimensions struct (left, top, right, bottom)
	u16						hRes;				// Horizontal Resolution
	u16						vRes;				// Vertical Resolution
	struct PCXPaletteColour { u8 R; u8 G; u8 B; }
	colourPalette[16];							// 16 colour EGA Palette struct (u8 R, u8 G, u8 B)
	u8						reservedBytes;		// Reserved byte (always 0)
	u8						numColourPlanes;	// Number of colour planes (1,3,4)
	u16						bytesPerScanline;	// Bytes per scanline
	u16						paletteInfo;		// Palette Type
	u16						hScreenRes;			// Horizontal Screen Size
	u16						vScreenRes;			// Vertical Screen Size
	u8						padding[54];		// Reserved (always 0)

}PCXHeader;

class PCXLoader
{
public:
	PCXLoader() {};
	~PCXLoader() {};

	static void* LoadFromFile(std::fstream* a_stream, u32& a_w, u32& a_h, u8& a_bpp, void*& a_imgPalette);

	static void* ConvertTo32bpp(void* a_imageData, void* palette, u32& a_w, u32& a_h, u8& a_bpp);

};
#endif //!__PCX_LOADER_H__
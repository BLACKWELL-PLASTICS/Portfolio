#include <stdafx.h>
#pragma once

#ifndef __PPM_LOADER_H__
#define __PPM_LOADER_H__

template <typename T>
struct PPMPixel
{
	T r;
	T g;
	T b;
};

struct PPM
{
	unsigned short id;
	char comment[512];
	unsigned int width;
	unsigned int height;
	unsigned int maxColours;

	void* pixelData;
};

class PPMLoader
{
public:
	PPMLoader();
	~PPMLoader() {};

	static void* LoadFromFile(std::fstream* a_stream, u32& a_w, u32& a_h, u8& a_bpp, void*& a_imgPalette);

private:

};

#endif // !__PPM_LOADER_H__

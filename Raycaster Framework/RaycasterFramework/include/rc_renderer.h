#include <stdafx.h>
#pragma once
#ifndef __RENDERER_H__
#define __RENDERER_H__

class Renderer
{
public:
	// Constructor & Destructor
	Renderer();
	~Renderer();
	// Get a valid instance of the class
	static Renderer* GetInstance() { return m_instance; }
	// Initialise function
	int Initalise(HWND a_consoleWindow, unsigned int a_width, unsigned int a_height);

	void ClearRenderBuffer();
	void Draw();

	void FillRenderBuffer(const unsigned int& a_x, const unsigned int& a_y, const unsigned int& a_width, const unsigned int& a_height, const void* a_data);
	// Overwritten function to fil render buffer with a solid colour
	void FillRenderBuffer(const unsigned int& a_x, const unsigned int& a_y, const unsigned int& a_width, const unsigned int& a_height, const u32 a_colour);
	HWND GetWindowHandle() const { return m_windowHandle; }
	HDC GetBufferContext() const { return m_bufferDC; }
	
	void GetWindowSize(u32& a_w, u32& a_h) { a_w = m_windowWidth; a_h = m_windowHeight; }


private:

	static Renderer*	m_instance;

	unsigned int	    m_windowWidth;
	unsigned int		m_windowHeight;

	HWND			    m_windowHandle;
	HDC					m_windowDC;
	void*				m_bitBuffer;
	BITMAPINFO*			m_bmpInfo;
	HBITMAP				m_bufferBmp;
	HDC					m_bufferDC;
	HBITMAP				m_bitmapHandle;
};

#endif // !__RENDERER_H__
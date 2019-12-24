#pragma once
#include "Frame.h"
#include <Windows.h>

class GDI
{
public:
	GDI(void);
	GDI(int Width, int Height);
	~GDI();

	Frame* frame;

	void Create(int Width, int Height);
	void Draw(HDC hdc);

private:
	BITMAPINFO* info;
	BITMAPINFOHEADER* header;
};


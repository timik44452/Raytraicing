#pragma once
#include "Pixel.h"

class Frame
{
public:
	int Width;
	int Height;
	int Length;

	int* buffer;

	Frame();
	Frame(int Width, int Height);
	~Frame();

	void Fill(Pixel pixel);

	void SetPixel(int X, int Y, Pixel* pixel);
	Pixel GetPixel(int X, int Y);
};


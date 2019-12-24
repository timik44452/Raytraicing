#include "Frame.h"

Frame::Frame()
{
	Width = 0;
	Height = 0;
	Length = 0;

	buffer = new int[0];
}

Frame::Frame(int Width, int Height)
{
	this->Width = Width;
	this->Height = Height;
	Length = Width * Height;

	buffer = new int[Length];

	Fill(Pixel(0, 0, 0, 1));
}

Frame::~Frame()
{
	delete[] buffer;
}

void Frame::Fill(Pixel pixel)
{
	for (int i = 0; i < Length; i++)
	{
		buffer[i] = pixel.get_RGB();
	}
}

void Frame::SetPixel(int X, int Y, Pixel* pixel)
{
	if (X >= 0 && X < Width && Y >= 0 && Y < Height)
		buffer[X + Y * Width] = pixel->get_RGB();
}

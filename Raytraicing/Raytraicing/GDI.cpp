#include "GDI.h"

GDI::GDI()
{
	Create(0, 0);
}
GDI::GDI(int Width, int Height)
{
	Create(Width, Height);
}

GDI::~GDI()
{
	delete frame;
}

void GDI::Create(int Width, int Height)
{
	info = new BITMAPINFO();
	header = new BITMAPINFOHEADER();
	frame = new Frame(Width, Height);

	header->biSize = sizeof(BITMAPINFOHEADER);
	header->biBitCount = 32;
	header->biPlanes = 1;
	header->biHeight = -Height;
	header->biWidth = Width;
	header->biSizeImage = Width * Height;

	info->bmiHeader = *header;
}

void GDI::Draw(HDC hdc)
{
	SetDIBitsToDevice(hdc, 0, 0, frame->Width, frame->Height, 0, 0, 0, frame->Height, frame->buffer, info, 0);
}
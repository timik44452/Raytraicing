#include "Pixel.h"

Pixel::Pixel()
{
	r = 0;
	g = 0;
	b = 0;
	a = 1;

	Update();
}

Pixel::Pixel(float R, float G, float B)
{
	r = R;
	g = G;
	b = B;
	a = 1;

	Update();
}

Pixel::Pixel(float R, float G, float B, float A)
{
	r = R;
	g = G;
	b = B;
	a = A;

	Update();
}

Pixel::~Pixel()
{

}

float Pixel::get_R()
{
	return r;
}

float Pixel::get_G()
{
	return g;
}

float Pixel::get_B()
{
	return b;
}

float Pixel::get_A()
{
	return a;
}

int Pixel::get_RGB()
{
	return rgb;
}

void Pixel::set_R(float value)
{
	r = value;

	Update();
}

void Pixel::set_G(float value)
{
	g = value;

	Update();
}

void Pixel::set_B(float value)
{
	b = value;

	Update();
}

void Pixel::set_A(float value)
{
	a = value;

	Update();
}

void Pixel::Update()
{
	rgb =
		(int)(a * 255) << 24 |
		(int)(r * 255) << 16 |
		(int)(g * 255) << 8 |
		(int)(b * 255);
}
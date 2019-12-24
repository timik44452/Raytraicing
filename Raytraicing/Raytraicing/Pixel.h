#pragma once
struct  Pixel
{
public:
	Pixel();
	Pixel(float R, float G, float B);
	Pixel(float R, float G, float B, float A);
	~Pixel();

	float get_R();
	float get_G();
	float get_B();
	float get_A();

	int get_RGB();

	void set_R(float value);
	void set_G(float value);
	void set_B(float value);
	void set_A(float value);

private:
	float r;
	float g;
	float b;
	float a;

	int rgb;

	void Update();
};


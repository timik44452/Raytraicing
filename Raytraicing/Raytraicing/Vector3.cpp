#include "Vector3.h"

Vector3::Vector3()
{
	set_X(0);
	set_Y(0);
	set_Z(0);
}

Vector3::Vector3(float x, float y, float z)
{
	set_X(x);
	set_Y(y);
	set_Z(z);
}

float Vector3::get_X()
{
	return x;
}

float Vector3::get_Y()
{
	return y;
}

float Vector3::get_Z()
{
	return z;
}

void Vector3::set_X(float value)
{
	x = value;
}

void Vector3::set_Y(float value)
{
	y = value;
}

void Vector3::set_Z(float value)
{
	z = value;
}

Vector3 Vector3::empty()
{
	return Vector3(0, 0, 0);
}

Vector3 Vector3::one()
{
	return Vector3(1, 1, 1);
}

Vector3 Vector3::up()
{
	return Vector3(0, 1, 0);
}

Vector3 Vector3::right()
{
	return Vector3(1, 0, 0);
}

Vector3 Vector3::forward()
{
	return Vector3(0, 0, 1);
}

Vector3 operator+(Vector3 a, Vector3 b)
{
	a.set_X(a.x + b.x);
	a.set_Y(a.y + b.y);
	a.set_Z(a.z + b.z);

	return a;
}

Vector3 operator*(Vector3 a, float b)
{
	a.set_X(a.x * b);
	a.set_Y(a.y * b);
	a.set_Z(a.z * b);

	return a;
}

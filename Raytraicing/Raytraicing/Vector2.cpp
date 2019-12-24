#include "Vector2.h"

Vector2::Vector2()
{
	set_X(0);
	set_Y(0);
}

Vector2::Vector2(float x, float y)
{
	set_X(x);
	set_Y(y);
}

float Vector2::get_X()
{
	return x;
}

float Vector2::get_Y()
{
	return y;
}

void Vector2::set_X(float value)
{
	x = value;
}

void Vector2::set_Y(float value)
{
	y = value;
}

Vector2 Vector2::empty()
{
	return Vector2(0, 0);
}

Vector2 Vector2::one()
{
	return Vector2(1, 1);
}

Vector2 Vector2::up()
{
	return Vector2(0, 1);
}

Vector2 Vector2::right()
{
	return Vector2(1, 0);
}

Vector2 operator-(Vector2 a, Vector2 b)
{
	a.set_X(a.x - b.x);
	a.set_Y(a.y - b.y);

	return a;
}

Vector2 operator+(Vector2 a, Vector2 b)
{
	a.set_X(a.x + b.x);
	a.set_Y(a.y + b.y);

	return a;
}

Vector2 operator*(Vector2 a, float b)
{
	a.set_X(a.x * b);
	a.set_Y(a.y * b);

	return a;
}

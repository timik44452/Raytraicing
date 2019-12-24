#pragma once
struct Vector2
{
public:
	Vector2();
	Vector2(float x, float y);

	static Vector2 empty();
	static Vector2 one();

	static Vector2 up();
	static Vector2 right();

	float get_X();
	float get_Y();

	void set_X(float value);
	void set_Y(float value);

	friend Vector2 operator - (Vector2 a, Vector2 b);

	friend Vector2 operator + (Vector2 a, Vector2 b);

	friend Vector2 operator * (Vector2 a, float b);

private:
	float x;
	float y;
	float z;
};


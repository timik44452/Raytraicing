#pragma once
struct Vector3
{
public:
	Vector3();
	Vector3(float x, float y, float z);

	static Vector3 empty();
	static Vector3 one();

	static Vector3 up();
	static Vector3 right();
	static Vector3 forward();

	float get_X();
	float get_Y();
	float get_Z();

	void set_X(float value);
	void set_Y(float value);
	void set_Z(float value);

	Vector3 operator + (Vector3 b)
	{
		b.set_X(b.x + x);
		b.set_Y(b.y + y);
		b.set_Z(b.z + z);

		return b;
	}

	friend Vector3 operator * (Vector3 a, float b)
	{
		a.set_X(a.x * b);
		a.set_Y(a.y * b);
		a.set_Z(a.z * b);

		return a;
	}

private:
	float x;
	float y;
	float z;
};


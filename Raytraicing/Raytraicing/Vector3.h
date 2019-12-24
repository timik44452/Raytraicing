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

	friend Vector3 operator + (Vector3 a, Vector3 b);

	friend Vector3 operator * (Vector3 a, float b);
private:
	float x;
	float y;
	float z;
};


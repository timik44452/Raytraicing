#pragma once
#include "Vector3.h"
#include "Matrix4x4.h"

enum Space
{
	Local,
	World
};

class Transform
{
public:
	Transform();

	Vector3 get_Up();
	Vector3 get_Right();
	Vector3 get_Forward();

	Vector3 get_position();

	void Move(Vector3 delta, Space space);
	void Rotate(Vector3 delta, Space space);

private:
	Vector3 up;
	Vector3 right;
	Vector3 forward;

	Vector3 position;
	Vector3 rotation;

	Vector3 radian_rotation;

	Matrix4x4 rotation_matrix;
	Matrix4x4 rotation_x_matrix;
	Matrix4x4 rotation_y_matrix;
	Matrix4x4 rotation_z_matrix;
};


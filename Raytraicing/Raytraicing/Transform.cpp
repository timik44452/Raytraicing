#include "Transform.h"
#include <math.h>

const float TO_RADIAN = 3.1415926 / 180;

Transform::Transform()
{
	up = Vector3::up();
	right = Vector3::right();
	forward = Vector3::forward();

	rotation_matrix = Matrix4x4::idenity();
	rotation_x_matrix = Matrix4x4::idenity();
	rotation_y_matrix = Matrix4x4::idenity();
	rotation_z_matrix = Matrix4x4::idenity();
}

Vector3 Transform::get_Up()
{
	return up;
}

Vector3 Transform::get_Right()
{
	return right;
}

Vector3 Transform::get_Forward()
{
	return forward;
}

Vector3 Transform::get_position()
{
	return position;
}

void Transform::Rotate(Vector3 delta, Space space)
{
	rotation = rotation + delta;
	radian_rotation = rotation * TO_RADIAN;

	if (delta.get_X() != 0)
	{
		float cos_v = cos(radian_rotation.get_X());
		float sin_v = sin(radian_rotation.get_X());

		rotation_x_matrix.set(
			1, 0, 0, 0,
			0, cos_v, sin_v, 0,
			0, -sin_v, cos_v, 0,
			0, 0, 0, 1);
	}

	if (delta.get_Y() != 0)
	{
		float cos_v = cos(radian_rotation.get_Y());
		float sin_v = sin(radian_rotation.get_Y());

		rotation_y_matrix.set(
			cos_v, 0, -sin_v, 0,
			0, 1, 0, 0,
			sin_v, 0, cos_v, 0,
			0, 0, 0, 1);
	}

	if (delta.get_Z() != 0)
	{
		float cos_v = cos(radian_rotation.get_Z());
		float sin_v = sin(radian_rotation.get_Z());

		rotation_z_matrix.set(
			cos_v, sin_v, 0, 0,
			-sin_v, cos_v, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1);
	}

	rotation_matrix = rotation_z_matrix.Multiply(rotation_y_matrix).Multiply(rotation_x_matrix);

	up = rotation_matrix.Multiply(0, 1, 0);
	right = rotation_matrix.Multiply(1, 0, 0);
	forward = rotation_matrix.Multiply(0, 0, 1);
}

void Transform::Move(Vector3 delta, Space space)
{
	switch (space)
	{
		case Local:
		{
			position = position +
				up * delta.get_Y() +
				right * delta.get_X() +
				forward * delta.get_Z();
		}
		break;
		case World:
		{
			position = position + delta;
		}
		break;
	}
}
#pragma once
#include "Vector3.h"

struct Matrix4x4
{
public:
	Matrix4x4();
	Matrix4x4(
		float m00, float m10, float m20, float m30,
		float m01, float m11, float m21, float m31,
		float m02, float m12, float m22, float m32,
		float m03, float m13, float m23, float m33);

	void set(
		float m00, float m10, float m20, float m30,
		float m01, float m11, float m21, float m31,
		float m02, float m12, float m22, float m32,
		float m03, float m13, float m23, float m33);

	Matrix4x4 Multiply(Matrix4x4 value);
	Vector3 Multiply(Vector3 value);

	Vector3 Multiply(float x, float y, float z);

	static Matrix4x4 idenity()
	{
		return Matrix4x4(
			1, 0, 0, 0,
			0, 1, 0, 0,
			0, 0, 1, 0,
			0, 0, 0, 1);
	}

private:
	float m00; float m10; float m20; float m30;
	float m01; float m11; float m21; float m31;
	float m02; float m12; float m22; float m32;
	float m03; float m13; float m23; float m33;
};


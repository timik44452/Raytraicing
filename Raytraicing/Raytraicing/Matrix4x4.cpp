#include "Matrix4x4.h"

Matrix4x4::Matrix4x4()
{
	m00 = 0;
	m10 = 0;
	m20 = 0;
	m30 = 0;
	
	m01 = 0;
	m11 = 0;
	m21 = 0;
	m31 = 0;

	m02 = 0;
	m12 = 0;
	m22 = 0;
	m32 = 0;

	m03 = 0;
	m13 = 0;
	m23 = 0;
	m33 = 0;
}

Matrix4x4::Matrix4x4(
	float m00, float m10, float m20, float m30,
	float m01, float m11, float m21, float m31,
	float m02, float m12, float m22, float m32,
	float m03, float m13, float m23, float m33)
{
	this->m00 = m00;
	this->m10 = m10;
	this->m20 = m20;
	this->m30 = m30;

	this->m01 = m01;
	this->m11 = m11;
	this->m21 = m21;
	this->m31 = m31;

	this->m02 = m02;
	this->m12 = m12;
	this->m22 = m22;
	this->m32 = m32;

	this->m03 = m03;
	this->m13 = m13;
	this->m23 = m23;
	this->m33 = m33;
}

void Matrix4x4::set(
	float m00, float m10, float m20, float m30,
	float m01, float m11, float m21, float m31,
	float m02, float m12, float m22, float m32,
	float m03, float m13, float m23, float m33)
{
	this->m00 = m00;
	this->m10 = m10;
	this->m20 = m20;
	this->m30 = m30;

	this->m01 = m01;
	this->m11 = m11;
	this->m21 = m21;
	this->m31 = m31;

	this->m02 = m02;
	this->m12 = m12;
	this->m22 = m22;
	this->m32 = m32;

	this->m03 = m03;
	this->m13 = m13;
	this->m23 = m23;
	this->m33 = m33;
}

Matrix4x4 Matrix4x4::Multiply(Matrix4x4 value)
{
	return Matrix4x4
	(
		m00 * value.m00 + m10 * value.m01 + m20 * value.m02 + m30 * value.m03,
		m00 * value.m10 + m10 * value.m11 + m20 * value.m12 + m30 * value.m13,
		m00 * value.m20 + m10 * value.m21 + m20 * value.m22 + m30 * value.m23,
		m00 * value.m30 + m10 * value.m31 + m20 * value.m32 + m30 * value.m33,

		m01 * value.m00 + m11 * value.m01 + m21 * value.m02 + m31 * value.m03,
		m01 * value.m10 + m11 * value.m11 + m21 * value.m12 + m31 * value.m13,
		m01 * value.m20 + m11 * value.m21 + m21 * value.m22 + m31 * value.m23,
		m01 * value.m30 + m11 * value.m31 + m21 * value.m32 + m31 * value.m33,

		m02 * value.m00 + m12 * value.m01 + m23 * value.m02 + m33 * value.m03,
		m02 * value.m10 + m12 * value.m11 + m23 * value.m12 + m33 * value.m13,
		m02 * value.m20 + m12 * value.m21 + m23 * value.m22 + m33 * value.m23,
		m02 * value.m30 + m12 * value.m31 + m23 * value.m32 + m33 * value.m33,

		m03 * value.m00 + m13 * value.m01 + m23 * value.m02 + m33 * value.m03,
		m03 * value.m10 + m13 * value.m11 + m23 * value.m12 + m33 * value.m13,
		m03 * value.m20 + m13 * value.m21 + m23 * value.m22 + m33 * value.m23,
		m03 * value.m30 + m13 * value.m31 + m23 * value.m32 + m33 * value.m33
	);
}

Vector3 Matrix4x4::Multiply(Vector3 value)
{
	return Vector3(
		m00 * value.get_X() + m10 * value.get_Y() + m20 * value.get_Z() + m30,
		m01 * value.get_X() + m11 * value.get_Y() + m21 * value.get_Z() + m31,
		m02 * value.get_X() + m12 * value.get_Y() + m22 * value.get_Z() + m32
	);
}

Vector3 Matrix4x4::Multiply(float x, float y, float z)
{
	return Vector3(
		m00 * x + m10 * y + m20 * z + m30,
		m01 * x + m11 * y + m21 * z + m31,
		m02 * x + m12 * y + m22 * z + m32
	);
}
#include "Scene.h"
#include <iostream>

Pixel* Trace(Vector3 from, Vector3 direction);
bool RayBoxIntersection(Vector3 ray_pos, Vector3 dir, float* tmin_o, float* tmax_o);

Pixel* p;
Pixel* background;

Scene::Scene()
{
	camera = Camera();
	camera.transform.Move(Vector3(0, 0, -100), Space::World);

	p = new Pixel[100 * 100 * 100];
	background = new Pixel(0, 0, 0);

	for (int x = 0; x < 1000000; x++)
		p[x] = Pixel(1, 1, 1);
}

Scene::~Scene()
{

}

void Scene::Draw(Frame* frame)
{
	for(int x = 0; x < frame->Width; x++)
		for (int y = 0; y < frame->Height; y++)
		{
			float dx = ((x / (float)frame->Width) - 0.5F) * 2;
			float dy = ((y / (float)frame->Width) - 0.5F) * 2;

			Pixel* pixel = Trace(camera.transform.get_position(), camera.transform.get_Forward() + camera.transform.get_Up() * dy + camera.transform.get_Right() * dx);

			frame->SetPixel(x, y, pixel);
		}
}

Pixel* Trace(Vector3 from, Vector3 direction)
{
	float tmin = 0;
	float tmax = 0;

	if (RayBoxIntersection(from, direction, &tmin, &tmax))
	{
		return &p[0];
	}

	return background;
}

bool RayBoxIntersection(Vector3 ray_pos, Vector3 dir, float* tmin_o, float* tmax_o)

{
	float lo = -ray_pos.get_X() / dir.get_X();

	float hi = (99 - ray_pos.get_X()) / dir.get_X();;

	float tmin = 0;
	float tmax = 0;

	if (lo > hi)
	{
		tmin = hi;
		tmax = lo;
	}
	else
	{
		tmin = lo;
		tmax = hi;
	}

	float lo1 = -ray_pos.get_Y() / dir.get_Y();

	float hi1 = (99 - ray_pos.get_Y()) / dir.get_Y();

	if (lo1 > hi1)
	{
		tmin = (hi1 > tmin) ? hi1 : tmin;
		tmax = (lo1 < tmax) ? lo1 : tmax;
	}
	else
	{
		tmin = (lo1 > tmin) ? lo1 : tmin;
		tmax = (hi1 < tmax) ? hi1 : tmax;
	}

	float lo2 = -ray_pos.get_Z() / dir.get_Z();

	float hi2 = (99 - ray_pos.get_Z()) / dir.get_Z();

	if (lo2 > hi2)
	{
		tmin = (hi2 > tmin) ? hi2 : tmin;
		tmax = (lo2 < tmax) ? lo2 : tmax;
	}
	else
	{
		tmin = (lo2 > tmin) ? lo2 : tmin;
		tmax = (hi2 < tmax) ? hi2 : tmax;
	}

	tmin_o = &tmin;
	tmax_o = &tmax;

	return (tmin <= tmax) && (tmax >= 0);

}
#pragma once
#include "Camera.h"
#include "Frame.h"

class Scene
{
public:
	Camera camera;

	Scene();
	~Scene();

	void Draw(Frame* frame);
};


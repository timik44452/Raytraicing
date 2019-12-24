#pragma once
#include "Vector2.h"

class Input
{
public:
	static void set_mouse_position(Vector2 value);

	static Vector2 get_mouse_position();
	
	static Vector2 get_mouse_delta();

private:
	static Vector2 mouse_delta;
	static Vector2 mouse_position;
};
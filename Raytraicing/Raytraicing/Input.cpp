#include "Input.h"

Vector2 Input::mouse_position = Vector2::empty();
Vector2 Input::mouse_delta = Vector2::empty();

void Input::set_mouse_position(Vector2 value)
{
	mouse_delta = mouse_position - value;
	mouse_position = value;
}

Vector2 Input::get_mouse_position()
{
	return Input::mouse_position;
}

Vector2 Input::get_mouse_delta()
{
	return Input::mouse_delta;
}
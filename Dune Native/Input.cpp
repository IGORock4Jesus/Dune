#include "Input.h"
#include <Windows.h>

namespace Input
{
bool keys[256];
bool mouses[4];
POINT cursor;


void KeyDown(int key) {
	keys[key] = true;
}
void KeyUp(int key) {
	keys[key] = false;
}
void KeyPress(int key) {}

void MouseDown(int key) {
	mouses[key] = true;
}
void MouseUp(int key) {
	mouses[key] = false;
}
void MouseMove(int x, int y) {
	cursor = { x,y };
}



}


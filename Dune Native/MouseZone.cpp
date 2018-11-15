#include "MouseZone.h"



MouseZone::MouseZone()
{
}


MouseZone::~MouseZone()
{
}

bool MouseZone::CheckHit(int x, int y)
{
	return x >= rect.left && x < rect.right && y >= rect.top && y < rect.bottom;
}

void MouseZone::SetRect(FRECT & rect)
{
	this->rect = rect;
}

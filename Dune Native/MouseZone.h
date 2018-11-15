#pragma once

#include <Windows.h>
#include "Trivial.h"

class MouseZone
{
	FRECT rect;

public:
	MouseZone();
	~MouseZone();

	bool CheckHit(int x, int y);

	void SetRect(FRECT& rect);

};


#pragma once

#include <Windows.h>


class MouseZone
{
	RECT rect;

public:
	MouseZone();
	~MouseZone();

	bool CheckHit(int x, int y);

	void SetRect(RECT& rect);

};


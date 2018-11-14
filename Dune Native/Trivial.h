#pragma once

#include <Windows.h>


struct FRECT
{
	float left, top, right, bottom;
};


inline void Log(LPCWSTR text) {
	OutputDebugString(text);
	OutputDebugString(L"\n");
}
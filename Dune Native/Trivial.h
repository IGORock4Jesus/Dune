#pragma once

#include <Windows.h>


inline void Log(LPCWSTR text) {
	OutputDebugString(text);
	OutputDebugString(L"\n");
}
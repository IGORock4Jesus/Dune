#pragma once

#include <Windows.h>
#include "Event.h"


namespace System
{
extern Event<> CreateEvent, DestroyEvent;
extern Event<BYTE> KeyDownEvent, KeyUpEvent, KeyPressEvent;
extern Event<BYTE> MouseDownEvent, MouseUpEvent;
extern Event<int, int> MouseMoveEvent;

bool Initial(HINSTANCE hinstance);
void Release();
void Run();

}
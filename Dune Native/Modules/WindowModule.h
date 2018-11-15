#pragma once

#include <Windows.h>
#include "..\Event.h"
#include "..\Module.h"

#ifdef CreateEvent
#undef CreateEvent
#endif // CreateEvent


class WindowModule : public Module
{
	HWND hwnd;
	LPCWSTR windowName = L"DuneWindow";

	LRESULT Process(HWND h, UINT m, WPARAM w, LPARAM l);
	static LRESULT CALLBACK WndProc(HWND h, UINT m, WPARAM w, LPARAM l);

	virtual bool OnInitialize(Module *dependencies[]) override;
	virtual void OnUpdate(float time) override;

public:
	Event<> CreateEvent, CloseEvent;
	Event<BYTE> KeyDownEvent, KeyUpEvent, KeyPressEvent;
	Event<BYTE> MouseDownEvent, MouseUpEvent;
	Event<int, int> MouseMoveEvent;

	WindowModule();
	~WindowModule();

	// Унаследовано через Module
	virtual std::vector<std::string> GetDependencies() override;
	virtual std::string GetName() override;

	HWND GetHandle() { return hwnd; }


};


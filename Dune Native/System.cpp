#include "System.h"
#include "Renderer.h"
#include "Input.h"
#include <windowsx.h>


namespace System
{
HINSTANCE hinstance;
HWND hwnd;
LPCWSTR windowName = L"DuneWindow";


LRESULT CALLBACK WndProc(HWND h, UINT m, WPARAM w, LPARAM l) {
	switch (m)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;

	case WM_CREATE:
		Renderer::Initial(h);
		return 0;

	case WM_CLOSE:
		Renderer::Release();
		DestroyWindow(hwnd);
		return 0;

	case WM_PAINT:
		Renderer::Rendering();
		return 0;

	case WM_KEYDOWN:
		Input::KeyDown((int)w);
		break;

	case WM_KEYUP:
		Input::KeyUp((int)w);
		break;

	case WM_LBUTTONDOWN:
		Input::MouseDown(0);
		break;
	case WM_RBUTTONDOWN:
		Input::MouseDown(1);
		break;
	case WM_MBUTTONDOWN:
		Input::MouseDown(2);
		break;

	case WM_LBUTTONUP:
		Input::MouseUp(0);
		break;
	case WM_RBUTTONUP:
		Input::MouseUp(1);
		break;
	case WM_MBUTTONUP:
		Input::MouseUp(2);
		break;

	case WM_MOUSEMOVE:
		Input::MouseMove(GET_X_LPARAM(l), GET_Y_LPARAM(l));
		break;

	default:
		return DefWindowProc(h, m, w, l);
	}
}

bool Initial(HINSTANCE hinstance)
{
	System::hinstance = hinstance;

	WNDCLASS wc{ 0 };
	wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wc.hInstance = hinstance;
	wc.lpfnWndProc = WndProc;
	wc.lpszClassName = windowName;
	wc.style = CS_HREDRAW | CS_VREDRAW;
	RegisterClass(&wc);

	hwnd = CreateWindow(windowName, windowName, WS_POPUPWINDOW, 0, 0, 800, 600, HWND_DESKTOP, nullptr, hinstance, nullptr);
	if (!hwnd)
		return false;

	ShowWindow(hwnd, SW_NORMAL);
	UpdateWindow(hwnd);

	return true;
}
void Release() {
	SendMessage(hwnd, WM_CLOSE, 0, 0);
}
void Run() {
	MSG msg{ 0 };
	while (GetMessage(&msg, nullptr, 0,0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}

}
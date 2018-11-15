#include "WindowModule.h"
#include <windowsx.h>


LRESULT WindowModule::Process(HWND h, UINT m, WPARAM w, LPARAM l)
{
	switch (m)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;

	case WM_CREATE:
		CreateEvent.Process();
		return 0;

	case WM_CLOSE:
		CloseEvent.Process();
		DestroyWindow(hwnd);
		return 0;

	case WM_PAINT:
		//Renderer::Rendering();
		return 0;

	case WM_KEYDOWN:
		KeyDownEvent.Process((BYTE)w);
		break;

	case WM_KEYUP:
		KeyUpEvent.Process((BYTE)w);
		break;

	case WM_LBUTTONDOWN:
		MouseDownEvent.Process(0);
		break;
	case WM_RBUTTONDOWN:
		MouseDownEvent.Process(1);
		break;
	case WM_MBUTTONDOWN:
		MouseDownEvent.Process(2);
		break;

	case WM_LBUTTONUP:
		MouseUpEvent.Process(0);
		break;
	case WM_RBUTTONUP:
		MouseUpEvent.Process(1);
		break;
	case WM_MBUTTONUP:
		MouseUpEvent.Process(2);
		break;

	case WM_MOUSEMOVE:
		MouseMoveEvent.Process(GET_X_LPARAM(l), GET_Y_LPARAM(l));
		break;

	default:
		return DefWindowProc(h, m, w, l);
	}
}

LRESULT WindowModule::WndProc(HWND h, UINT m, WPARAM w, LPARAM l)
{
	if (m == WM_NCCREATE) {
		auto p = (LPCREATESTRUCT)l;
		SetWindowLongPtr(h, GWLP_USERDATA, (LONG_PTR)p->lpCreateParams);
		return TRUE;
	}
	else {
		auto p = (WindowModule*)GetWindowLongPtr(h, GWLP_USERDATA);
		return p->Process(h, m, w, l);
	}
}

bool WindowModule::OnInitialize(Module *dependencies[])
{
	auto hinstance = GetModuleHandle(nullptr);

	WNDCLASS wc{ 0 };
	wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wc.hInstance = hinstance;
	wc.lpfnWndProc = WndProc;
	wc.lpszClassName = windowName;
	wc.style = CS_HREDRAW | CS_VREDRAW;
	RegisterClass(&wc);

	hwnd = CreateWindow(windowName, windowName, WS_POPUPWINDOW, 0, 0, 800, 600, HWND_DESKTOP, nullptr, hinstance, this);
	if (!hwnd)
		return false;

	ShowWindow(hwnd, SW_NORMAL);
	UpdateWindow(hwnd);
	return true;
}

void WindowModule::OnUpdate(float time)
{
	MSG msg{ 0 };
	if(PeekMessage(&msg, nullptr, 0, 0, PM_REMOVE))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
}

WindowModule::WindowModule()
{
}


WindowModule::~WindowModule()
{
}

std::vector<std::string> WindowModule::GetDependencies()
{
	return {};
}

std::string WindowModule::GetName()
{
	return "Window";
}

#include "Renderer.h"
#include "Trivial.h"


namespace Renderer
{
LPDIRECT3D9 direct;
LPDIRECT3DDEVICE9 device;


bool Initial(HWND hwnd) {
	Log(L"Renderer::Initial");
	if (!(direct = Direct3DCreate9(D3D_SDK_VERSION)))
		return false;

	D3DPRESENT_PARAMETERS pp{ 0 };
	pp.AutoDepthStencilFormat = D3DFMT_D24S8;
	pp.BackBufferCount = 1;
	pp.BackBufferFormat = D3DFMT_X8R8G8B8;
	RECT cr;
	GetClientRect(hwnd, &cr);
	pp.BackBufferHeight = cr.bottom - cr.top;
	pp.BackBufferWidth = cr.right - cr.left;
	pp.EnableAutoDepthStencil = TRUE;
	pp.hDeviceWindow = hwnd;
	pp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	pp.Windowed = TRUE;

	if (FAILED(direct->CreateDevice(0, D3DDEVTYPE_HAL, hwnd, D3DCREATE_HARDWARE_VERTEXPROCESSING, &pp, &device)))
		return false;



	return true;
}
void Release() {
	Log(L"Renderer::Release");
	if (direct) {
		direct->Release(); 
		direct = nullptr;
	}
	if (device) {
		device->Release();
		device = nullptr;
	}
}
void Rendering() {
	device->Clear(0, nullptr, D3DCLEAR_STENCIL | D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER, 0xff404040, 1.0f, 0);
	device->BeginScene();


	device->EndScene();
	device->Present(nullptr, nullptr, nullptr, nullptr);
}
}

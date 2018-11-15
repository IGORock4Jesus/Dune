#include "RendererModule.h"
#include "..\Trivial.h"


bool Renderer::OnInitialize(Module * dependencies[])
{
	window = (WindowModule*)dependencies[0];

	Log(L"Renderer::Initial");
	if (!(direct = Direct3DCreate9(D3D_SDK_VERSION)))
		return false;

	D3DPRESENT_PARAMETERS pp{ 0 };
	pp.AutoDepthStencilFormat = D3DFMT_D24S8;
	pp.BackBufferCount = 1;
	pp.BackBufferFormat = D3DFMT_X8R8G8B8;
	RECT cr;
	GetClientRect(window->GetHandle(), &cr);
	pp.BackBufferHeight = cr.bottom - cr.top;
	pp.BackBufferWidth = cr.right - cr.left;
	pp.EnableAutoDepthStencil = TRUE;
	pp.hDeviceWindow = window->GetHandle();
	pp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	pp.Windowed = TRUE;

	if (FAILED(direct->CreateDevice(0, D3DDEVTYPE_HAL, window->GetHandle(), D3DCREATE_HARDWARE_VERTEXPROCESSING, &pp, &device)))
		return false;

	return true;
}

void Renderer::OnRelease()
{
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

void Renderer::OnUpdate(float time)
{
	device->Clear(0, nullptr, D3DCLEAR_STENCIL | D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER, 0xff404040, 1.0f, 0);
	device->BeginScene();


	device->EndScene();
	device->Present(nullptr, nullptr, nullptr, nullptr);
}

std::vector<std::string> Renderer::GetDependencies()
{
	return { "Window" };
}

std::string Renderer::GetName()
{
	return "Renderer";
}

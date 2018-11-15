#pragma once

#include <d3dx9.h>
#include "..\Module.h"
#include "WindowModule.h"


class Renderer : public Module
{
	LPDIRECT3D9 direct;
	LPDIRECT3DDEVICE9 device;
	WindowModule *window;

	virtual bool OnInitialize(Module *dependencies[]) override;
	virtual void OnRelease() override;
	virtual void OnUpdate(float time) override;

public:
	// Унаследовано через Module
	virtual std::vector<std::string> GetDependencies() override;
	virtual std::string GetName() override;
};

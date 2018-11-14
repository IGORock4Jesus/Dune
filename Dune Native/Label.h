#pragma once

#include <string>
#include <d3d9.h>


class Label
{
public:
	std::string text;
	D3DCOLOR color;

public:
	Label();
	~Label();

	void Render(LPDIRECT3DDEVICE9 device);
};


#pragma once

#include <d3dx9.h>
#include "Trivial.h"


class Sprite
{
	LPDIRECT3DTEXTURE9 texture;
	FRECT rect;
	FRECT textureRect{ 0.0f, 0.0f, 1.0f, 1.0f };

public:
	Sprite();
	~Sprite();

	void SetTexture(LPDIRECT3DTEXTURE9 texture);
	void Render(LPDIRECT3DDEVICE9 device);
};


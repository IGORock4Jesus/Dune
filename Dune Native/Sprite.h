#pragma once

#include <d3dx9.h>


class Sprite
{
	LPDIRECT3DTEXTURE9 texture;
	D3DXVECTOR2 scalingCenter;
	float scalingRotation;
	D3DXVECTOR2 scaling;
	D3DXVECTOR2 rotationCenter;
	float rotation;
	D3DXVECTOR2 translation;

public:
	Sprite();
	~Sprite();

	void Render(LPDIRECT3DDEVICE9 device);
};


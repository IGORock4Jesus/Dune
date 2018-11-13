#pragma once

#include <d3dx9.h>


struct TextureVertex
{
	D3DXVECTOR3 position;
	D3DXVECTOR2 texel;

	//static const DWORD size;
	//static const DWORD format;
};

constexpr DWORD TextureVertexSize = sizeof(TextureVertex);
constexpr DWORD TextureVertexFormat = D3DFVF_XYZ | D3DFVF_TEX1;





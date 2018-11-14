#pragma once

#include <d3dx9.h>


struct Texture2DVertex
{
	D3DXVECTOR4 position;
	D3DXVECTOR2 texel;

	//static const DWORD size;
	//static const DWORD format;
};

constexpr DWORD Texture2DVertexSize = sizeof(Texture2DVertex);
constexpr DWORD Texture2DVertexFormat = D3DFVF_XYZRHW | D3DFVF_TEX1;





#include "Sprite.h"
#include "Vertices.h"


Sprite::Sprite()
{
}


Sprite::~Sprite()
{
}

void Sprite::SetTexture(LPDIRECT3DTEXTURE9 texture)
{
	this->texture = texture;
}

void Sprite::Render(LPDIRECT3DDEVICE9 device)
{
	device->SetTexture(0, texture);
	//D3DXMATRIX m;
	//D3DXMatrixTransformation2D(&m, &scalingCenter, scalingRotation, &scaling, &rotationCenter, rotation, &translation);
	//device->SetTransform(D3DTS_WORLD, &m);

	Texture2DVertex vertices[]{
		{{rect.left, rect.top, 0.0f, 1.0f}, {textureRect.left, textureRect.top}},
		{{rect.right, rect.top, 0.0f, 1.0f}, {textureRect.right, textureRect.top}},
		{{rect.right, rect.bottom, 0.0f, 1.0f}, {textureRect.right, textureRect.bottom}},
		{{rect.left, rect.bottom, 0.0f, 1.0f}, {textureRect.left, textureRect.bottom}},
	};
	device->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, 2, vertices, Texture2DVertexSize);
}

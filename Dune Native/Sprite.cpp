#include "Sprite.h"
#include "Vertices.h"


Sprite::Sprite()
{
}


Sprite::~Sprite()
{
}

void Sprite::Render(LPDIRECT3DDEVICE9 device)
{
	if (texture) {
		device->SetTexture(0, texture);
		D3DXMATRIX m;
		D3DXMatrixTransformation2D(&m, &scalingCenter, scalingRotation, &scaling, &rotationCenter, rotation, &translation);
		device->SetTransform(D3DTS_WORLD, &m);

		/*device->DrawPrimitiveUP(D3DPT_TRIANGLEFAN, 2, {
			{{}}
			})*/
	}

}

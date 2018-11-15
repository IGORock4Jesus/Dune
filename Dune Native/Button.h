#pragma once

#include "MouseZone.h"
#include "Sprite.h"
#include "Label.h"


class Button
{
	MouseZone mouseZone;
	Sprite sprite;
	Label label;
	FRECT rect;

	void SetTexture(LPDIRECT3DTEXTURE9 texture);

public:
	Button();
	~Button();

	void SetRect(FRECT& rect);
};


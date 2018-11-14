#include "Button.h"



void Button::SetTexture(LPDIRECT3DTEXTURE9 texture)
{
	sprite.SetTexture(texture);
}

Button::Button()
{
}


Button::~Button()
{
}

void Button::SetRect(RECT & rect)
{
	this->rect = rect;
	mouseZone.SetRect(rect);
	sprite.SetRect(rect);
}

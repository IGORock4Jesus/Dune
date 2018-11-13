#include "System.h"


int WINAPI wWinMain(HINSTANCE hinstance, HINSTANCE, LPWSTR, int) {
	if (System::Initial(hinstance)) {
		System::Run();
		System::Release();
	}

	return 0;
}
#include "System.h"
#include "ModuleManager.h"

#include "Modules/WindowModule.h"
#include "Modules/RendererModule.h"


ModuleManager* mm;

void TestKeyDown(BYTE key) {
	if (key == VK_ESCAPE) {
		mm->Stop();
	}
}

int WINAPI wWinMain(HINSTANCE hinstance, HINSTANCE, LPWSTR, int) {
	/*if (System::Initial(hinstance)) {
		System::Run();
		System::Release();
	}*/

	WindowModule window;
	Renderer renderer;

	mm = new ModuleManager({
		/*std::shared_ptr<Module>{new HUDModule()},*/
		&renderer,
		/*std::shared_ptr<Module>{new InputModule()},*/
		&window
		});

	auto w = mm->Get<WindowModule>();
	if (w) {
		w->KeyDownEvent.Add(TestKeyDown);
	}

	if (mm->Initialize())
	{
		mm->Run();
		mm->Release();
	}

	delete mm;

	return 0;
}
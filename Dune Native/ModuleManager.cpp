#include "ModuleManager.h"
#include <list>
#include <Windows.h>


ModuleManager::ModuleManager(std::vector<Module*> modules)
{
	// сортируем
	std::list<Module*> list(modules.begin(), modules.end());

	while (list.size() != 0) {
		std::list<Module*> cutter(list.begin(), list.end());
		for (auto&& m : cutter) {
			auto deps = m->GetDependencies();
			// если все эти зависимости есть в отсортированном списке - добавляем
			bool ready = true;
			for (auto&& d : deps) {
				bool found = false;
				for (auto&& s : this->modules) {
					if (s->GetName() == d) {
						found = true;
						break;
					}
				}
				if (!found) {
					ready = false;
					break;
				}
			}

			if (ready) {
				list.remove(m);
				this->modules.push_back(m);
			}
		}
	}
}


ModuleManager::~ModuleManager()
{
}

bool ModuleManager::Initialize()
{
	for (auto&& p : modules) {
		std::vector<Module*> deps;
		for (auto&& dep : p->GetDependencies()) {
			deps.push_back(Get(dep));
		}
		if (!p->Initialize(this, deps.data()))
			return false;
	}
	return true;
}

void ModuleManager::Release()
{
	for (auto&& p : std::list<Module*>{ modules.rbegin(), modules.rend() }) {
		p->Release();
	}
}

void ModuleManager::Run()
{
	if (enabled) return;
	enabled = true;

	DWORD oldTime = timeGetTime();
	while (enabled)
	{
		DWORD newTime = timeGetTime();
		float elapsedTime = (newTime - oldTime)*0.001f;
		for (auto&& p : modules) {
			p->Update(elapsedTime);
		}
	}
}

void ModuleManager::Stop() {
	enabled = false;
}
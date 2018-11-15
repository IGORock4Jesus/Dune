#pragma once

#include <vector>
#include <list>

#include "Module.h"


class ModuleManager
{
	std::list<Module*> modules;
	bool enabled{ false };


public:
	ModuleManager(std::vector<Module*> modules);
	~ModuleManager();

	bool Initialize();
	void Release();
	void Run();
	void Stop();

	template <typename T>
	T *Get() {
		for (auto&& p : modules) {
			auto d = dynamic_cast<T*>(p);
			if (d != nullptr)
				return d;
		}
		return nullptr;
	}

	Module *Get(std::string name) {
		for (auto&& p : modules) {
			if (p->GetName() == name)
				return p;
		}
		return nullptr;
	}
};


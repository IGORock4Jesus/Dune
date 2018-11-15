#pragma once

#include <vector>

class ModuleManager;

class Module
{
	friend ModuleManager;
	ModuleManager *manager;

	bool Initialize(ModuleManager *manager, Module *dependencies[]);
	void Release();
	void Update(float time);

protected:
	// 
	virtual bool OnInitialize(Module *dependencies[]) { return true; }
	virtual void OnRelease() {}
	virtual void OnUpdate(float time) {}

public:
	Module();
	virtual ~Module();

	// получить список модулий, от которых зависит данный модуль
	virtual std::vector<std::string> GetDependencies() = 0;

	// возвращает имя данного модуля
	virtual std::string GetName() = 0;



};


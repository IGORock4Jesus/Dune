#include "Module.h"



bool Module::Initialize(ModuleManager * manager, Module *dependencies[]) {
	this->manager = manager; 
	return OnInitialize(dependencies);
}

void Module::Release()
{
	OnRelease();
}

void Module::Update(float time)
{
	OnUpdate(time);
}

Module::Module()
{
}


Module::~Module()
{
}

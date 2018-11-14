#pragma once

#include <list>
#include <memory>



template <typename ...TArgs>
class Event {
	enum class DelegateType
	{
		Static,
		Class
	};

	struct Delegate
	{
		DelegateType type;

		Delegate(DelegateType type)
			: type{ type }
		{

		}

		virtual void Process(TArgs ...args) = 0;
	};

	template <typename TFunc>
	struct StaticDelegate : Delegate
	{
		TFunc func;

		StaticDelegate(TFunc func)
			: Delegate(DelegateType::Static), func{ func }
		{

		}

		virtual void Process(TArgs ...args) override {
			func(args...);
		}

		bool Compare(TFunc func) {
			return this->func == func;
		}
	};

	template <typename TClass, typename TMethod>
	struct ClassDelegate : Delegate
	{
		TClass *object;
		TMethod method;

		ClassDelegate(TClass *object, TMethod method)
			: Delegate(DelegateType::Class), object{ object }, method{ method }
		{

		}

		virtual void Process(TArgs ...args) override {
			(object->*method)(args...);
		}

		bool Compare(TClass *object, TMethod method) {
			return this->object == object && this->method == method;
		}
	};

	std::list<std::unique_ptr<Delegate>> delegates;

public:
	void Process(TArgs ...args) {
		for (auto&& d : delegates) {
			d.Process(args...);
		}
	}

	template <typename TFunc>
	void Add(TFunc func) {
		StaticDelegate<TFunc> *d = new StaticDelegate<TFunc>(func);
		std::unique_ptr<Delegate> p{ d };
		delegates.push_back(p);
	}

	template <typename TFunc>
	void Remove(TFunc func) {
		delegates.remove_if([func](p) {
			if (p->type == DelegateType::Static) {
				auto s = std::dynamic_pointer_cast<StaticDelegate>(p);
				return s->Compare(func);
			}
			return false;
		});
	}

	template <typename TClass, typename TMethod>
	void Add(TClass *object, TMethod method) {
		ClassDelegate<TClass, TMethod> *d = new ClassDelegate<TClass, TMethod>(object, method);
		std::unique_ptr<Delegate> p{ d };
		delegates.push_back(p);
	}

	template <typename TClass, typename TMethod>
	void Remove(TClass *object, TMethod method) {
		delegates.remove_if([func](p) {
			if (p->type == DelegateType::Class) {
				auto s = std::dynamic_pointer_cast<TClass, TMethod>(p);
				return s->Compare(object, method);
			}
			return false;
		});
	}
};

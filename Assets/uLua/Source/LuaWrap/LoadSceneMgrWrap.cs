using System;
using UnityEngine;
using LuaInterface;

public class LoadSceneMgrWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Init", Init),
			new LuaMethod("SetLoadScene", SetLoadScene),
			new LuaMethod("AddPreLoadPrefab", AddPreLoadPrefab),
			new LuaMethod("LoadJsonFile", LoadJsonFile),
			new LuaMethod("ChangeScene", ChangeScene),
			new LuaMethod("ChangeSceneDirect", ChangeSceneDirect),
			new LuaMethod("OnLoadEmptylevel", OnLoadEmptylevel),
			new LuaMethod("OnLoadScnene", OnLoadScnene),
			new LuaMethod("New", _CreateLoadSceneMgr),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("LOADING_UI_RES", get_LOADING_UI_RES, null),
			new LuaField("IsStartLoad", get_IsStartLoad, set_IsStartLoad),
			new LuaField("Instance", get_Instance, null),
		};

		LuaScriptMgr.RegisterLib(L, "LoadSceneMgr", typeof(LoadSceneMgr), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLoadSceneMgr(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LoadSceneMgr obj = new LoadSceneMgr();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LoadSceneMgr.New");
		}

		return 0;
	}

	static Type classType = typeof(LoadSceneMgr);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LOADING_UI_RES(IntPtr L)
	{
		LuaScriptMgr.Push(L, LoadSceneMgr.LOADING_UI_RES);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsStartLoad(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LoadSceneMgr obj = (LoadSceneMgr)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsStartLoad");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsStartLoad on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsStartLoad);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, LoadSceneMgr.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsStartLoad(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LoadSceneMgr obj = (LoadSceneMgr)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsStartLoad");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsStartLoad on a nil value");
			}
		}

		obj.IsStartLoad = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.Init(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLoadScene(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SetLoadScene(arg0);
			return 0;
		}
		else if (count == 3)
		{
			LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			obj.SetLoadScene(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LoadSceneMgr.SetLoadScene");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPreLoadPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.AddPreLoadPrefab(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadJsonFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		obj.LoadJsonFile();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeScene(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		obj.ChangeScene();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeSceneDirect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		obj.ChangeSceneDirect();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnLoadEmptylevel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		obj.OnLoadEmptylevel();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnLoadScnene(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LoadSceneMgr obj = (LoadSceneMgr)LuaScriptMgr.GetNetObjectSelf(L, 1, "LoadSceneMgr");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.OnLoadScnene(arg0);
		return 0;
	}
}


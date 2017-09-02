using System;
using System.Collections.Generic;
using LuaInterface;

public class SettingManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("TotalRecord", TotalRecord),
			new LuaMethod("ClearCoin", ClearCoin),
			new LuaMethod("ClearMonthInfo", ClearMonthInfo),
			new LuaMethod("ClearTotalRecord", ClearTotalRecord),
			new LuaMethod("GetMonthData", GetMonthData),
			new LuaMethod("LogGameTimes", LogGameTimes),
			new LuaMethod("LogUpTime", LogUpTime),
			new LuaMethod("LogNumberOfGame", LogNumberOfGame),
			new LuaMethod("AddTicket", AddTicket),
			new LuaMethod("AddCoin", AddCoin),
			new LuaMethod("Save", Save),
			new LuaMethod("CopyToPo", CopyToPo),
			new LuaMethod("New", _CreateSettingManager),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("CheckID", get_CheckID, set_CheckID),
			new LuaField("GameRate", get_GameRate, set_GameRate),
			new LuaField("GameVolume", get_GameVolume, set_GameVolume),
			new LuaField("GameLanguage", get_GameLanguage, set_GameLanguage),
			new LuaField("TicketModel", get_TicketModel, set_TicketModel),
			new LuaField("GameLevel", get_GameLevel, set_GameLevel),
			new LuaField("HasCoin", get_HasCoin, set_HasCoin),
		};

		LuaScriptMgr.RegisterLib(L, "SettingManager", typeof(SettingManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSettingManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SettingManager obj = new SettingManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SettingManager.New");
		}

		return 0;
	}

	static Type classType = typeof(SettingManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, SettingManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CheckID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CheckID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CheckID on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.CheckID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameRate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.GameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameVolume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameVolume on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.GameVolume);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameLanguage(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameLanguage");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameLanguage on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.GameLanguage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TicketModel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name TicketModel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index TicketModel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.TicketModel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameLevel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.GameLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HasCoin(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name HasCoin");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index HasCoin on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.HasCoin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CheckID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name CheckID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index CheckID on a nil value");
			}
		}

		obj.CheckID = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameRate on a nil value");
			}
		}

		obj.GameRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameVolume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameVolume on a nil value");
			}
		}

		obj.GameVolume = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameLanguage(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameLanguage");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameLanguage on a nil value");
			}
		}

		obj.GameLanguage = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_TicketModel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name TicketModel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index TicketModel on a nil value");
			}
		}

		obj.TicketModel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name GameLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index GameLevel on a nil value");
			}
		}

		obj.GameLevel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_HasCoin(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SettingManager obj = (SettingManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name HasCoin");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index HasCoin on a nil value");
			}
		}

		obj.HasCoin = LuaScriptMgr.GetArrayNumber<int>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TotalRecord(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		float[] o = obj.TotalRecord();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearCoin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		obj.ClearCoin();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearMonthInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		obj.ClearMonthInfo();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearTotalRecord(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		obj.ClearTotalRecord();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMonthData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
			List<float[]> o = obj.GetMonthData();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2)
		{
			SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float[] o = obj.GetMonthData(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SettingManager.GetMonthData");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogGameTimes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.LogGameTimes(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogUpTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.LogUpTime(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogNumberOfGame(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.LogNumberOfGame(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTicket(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddTicket(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddCoin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddCoin(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Save(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		obj.Save();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyToPo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SettingManager obj = (SettingManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SettingManager");
		obj.CopyToPo();
		return 0;
	}
}


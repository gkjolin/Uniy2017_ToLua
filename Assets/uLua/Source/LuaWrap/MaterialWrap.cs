﻿using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;
using DG.Tweening;

public class MaterialWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("HasProperty", HasProperty),
			new LuaMethod("GetTag", GetTag),
			new LuaMethod("SetOverrideTag", SetOverrideTag),
			new LuaMethod("SetShaderPassEnabled", SetShaderPassEnabled),
			new LuaMethod("GetShaderPassEnabled", GetShaderPassEnabled),
			new LuaMethod("Lerp", Lerp),
			new LuaMethod("SetPass", SetPass),
			new LuaMethod("GetPassName", GetPassName),
			new LuaMethod("FindPass", FindPass),
			new LuaMethod("CopyPropertiesFromMaterial", CopyPropertiesFromMaterial),
			new LuaMethod("EnableKeyword", EnableKeyword),
			new LuaMethod("DisableKeyword", DisableKeyword),
			new LuaMethod("IsKeywordEnabled", IsKeywordEnabled),
			new LuaMethod("SetFloat", SetFloat),
			new LuaMethod("SetInt", SetInt),
			new LuaMethod("SetColor", SetColor),
			new LuaMethod("SetVector", SetVector),
			new LuaMethod("SetMatrix", SetMatrix),
			new LuaMethod("SetTexture", SetTexture),
			new LuaMethod("SetBuffer", SetBuffer),
			new LuaMethod("SetTextureOffset", SetTextureOffset),
			new LuaMethod("SetTextureScale", SetTextureScale),
			new LuaMethod("SetFloatArray", SetFloatArray),
			new LuaMethod("SetColorArray", SetColorArray),
			new LuaMethod("SetVectorArray", SetVectorArray),
			new LuaMethod("SetMatrixArray", SetMatrixArray),
			new LuaMethod("GetFloat", GetFloat),
			new LuaMethod("GetInt", GetInt),
			new LuaMethod("GetColor", GetColor),
			new LuaMethod("GetVector", GetVector),
			new LuaMethod("GetMatrix", GetMatrix),
			new LuaMethod("GetFloatArray", GetFloatArray),
			new LuaMethod("GetVectorArray", GetVectorArray),
			new LuaMethod("GetColorArray", GetColorArray),
			new LuaMethod("GetMatrixArray", GetMatrixArray),
			new LuaMethod("GetTexture", GetTexture),
			new LuaMethod("GetTextureOffset", GetTextureOffset),
			new LuaMethod("GetTextureScale", GetTextureScale),
			new LuaMethod("DOBlendableColor", DOBlendableColor),
			new LuaMethod("DOVector", DOVector),
			new LuaMethod("DOTiling", DOTiling),
			new LuaMethod("DOOffset", DOOffset),
			new LuaMethod("DOFloat", DOFloat),
			new LuaMethod("DOFade", DOFade),
			new LuaMethod("DOColor", DOColor),
			new LuaMethod("New", _CreateMaterial),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("shader", get_shader, set_shader),
			new LuaField("color", get_color, set_color),
			new LuaField("mainTexture", get_mainTexture, set_mainTexture),
			new LuaField("mainTextureOffset", get_mainTextureOffset, set_mainTextureOffset),
			new LuaField("mainTextureScale", get_mainTextureScale, set_mainTextureScale),
			new LuaField("passCount", get_passCount, null),
			new LuaField("renderQueue", get_renderQueue, set_renderQueue),
			new LuaField("shaderKeywords", get_shaderKeywords, set_shaderKeywords),
			new LuaField("globalIlluminationFlags", get_globalIlluminationFlags, set_globalIlluminationFlags),
			new LuaField("enableInstancing", get_enableInstancing, set_enableInstancing),
			new LuaField("doubleSidedGI", get_doubleSidedGI, set_doubleSidedGI),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.Material", typeof(Material), regs, fields, typeof(Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMaterial(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material)))
		{
			Material arg0 = (Material)LuaScriptMgr.GetUnityObject(L, 1, typeof(Material));
			Material obj = new Material(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Shader)))
		{
			Shader arg0 = (Shader)LuaScriptMgr.GetUnityObject(L, 1, typeof(Shader));
			Material obj = new Material(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.New");
		}

		return 0;
	}

	static Type classType = typeof(Material);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shader(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.shader);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTextureOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTextureOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTextureScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTextureScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_passCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name passCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index passCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.passCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.renderQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shaderKeywords(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.shaderKeywords);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_globalIlluminationFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name globalIlluminationFlags");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index globalIlluminationFlags on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.globalIlluminationFlags);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableInstancing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableInstancing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableInstancing on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.enableInstancing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_doubleSidedGI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name doubleSidedGI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index doubleSidedGI on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.doubleSidedGI);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shader(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}

		obj.shader = (Shader)LuaScriptMgr.GetUnityObject(L, 3, typeof(Shader));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}

		obj.color = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}

		obj.mainTexture = (Texture)LuaScriptMgr.GetUnityObject(L, 3, typeof(Texture));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTextureOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
			}
		}

		obj.mainTextureOffset = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTextureScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
			}
		}

		obj.mainTextureScale = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
			}
		}

		obj.renderQueue = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shaderKeywords(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
			}
		}

		obj.shaderKeywords = LuaScriptMgr.GetArrayString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_globalIlluminationFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name globalIlluminationFlags");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index globalIlluminationFlags on a nil value");
			}
		}

		obj.globalIlluminationFlags = (MaterialGlobalIlluminationFlags)LuaScriptMgr.GetNetObject(L, 3, typeof(MaterialGlobalIlluminationFlags));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableInstancing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableInstancing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableInstancing on a nil value");
			}
		}

		obj.enableInstancing = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_doubleSidedGI(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name doubleSidedGI");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index doubleSidedGI on a nil value");
			}
		}

		obj.doubleSidedGI = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasProperty(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			bool o = obj.HasProperty(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			bool o = obj.HasProperty(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.HasProperty");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTag(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			string o = obj.GetTag(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			string arg2 = LuaScriptMgr.GetLuaString(L, 4);
			string o = obj.GetTag(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTag");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetOverrideTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SetOverrideTag(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetShaderPassEnabled(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
		obj.SetShaderPassEnabled(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetShaderPassEnabled(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.GetShaderPassEnabled(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		Material arg0 = (Material)LuaScriptMgr.GetUnityObject(L, 2, typeof(Material));
		Material arg1 = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.Lerp(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPass(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.SetPass(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPassName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string o = obj.GetPassName(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindPass(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int o = obj.FindPass(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyPropertiesFromMaterial(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		Material arg0 = (Material)LuaScriptMgr.GetUnityObject(L, 2, typeof(Material));
		obj.CopyPropertiesFromMaterial(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnableKeyword(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.EnableKeyword(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DisableKeyword(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.DisableKeyword(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsKeywordEnabled(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.IsKeywordEnabled(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(float)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			obj.SetFloat(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(float)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 3);
			obj.SetFloat(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			obj.SetInt(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			obj.SetInt(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Color arg1 = LuaScriptMgr.GetColor(L, 3);
			obj.SetColor(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color arg1 = LuaScriptMgr.GetColor(L, 3);
			obj.SetColor(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector4 arg1 = LuaScriptMgr.GetVector4(L, 3);
			obj.SetVector(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4 arg1 = LuaScriptMgr.GetVector4(L, 3);
			obj.SetVector(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Matrix4x4)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Matrix4x4 arg1 = (Matrix4x4)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetMatrix(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Matrix4x4)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 arg1 = (Matrix4x4)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetMatrix(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Texture)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetTexture(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Texture)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Texture arg1 = (Texture)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetTexture(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBuffer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(ComputeBuffer)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			ComputeBuffer arg1 = (ComputeBuffer)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetBuffer(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(ComputeBuffer)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			ComputeBuffer arg1 = (ComputeBuffer)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetBuffer(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetBuffer");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextureOffset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 3);
			obj.SetTextureOffset(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 3);
			obj.SetTextureOffset(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetTextureOffset");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextureScale(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 3);
			obj.SetTextureScale(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 3);
			obj.SetTextureScale(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetTextureScale");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFloatArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(float[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float[] objs1 = LuaScriptMgr.GetArrayNumber<float>(L, 3);
			obj.SetFloatArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(float[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			float[] objs1 = LuaScriptMgr.GetArrayNumber<float>(L, 3);
			obj.SetFloatArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<float>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<float> arg1 = (List<float>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetFloatArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<float>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<float> arg1 = (List<float>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetFloatArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetFloatArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColorArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color[] objs1 = LuaScriptMgr.GetArrayObject<Color>(L, 3);
			obj.SetColorArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Color[] objs1 = LuaScriptMgr.GetArrayObject<Color>(L, 3);
			obj.SetColorArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<Color>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<Color> arg1 = (List<Color>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetColorArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<Color>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<Color> arg1 = (List<Color>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetColorArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetColorArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVectorArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4[] objs1 = LuaScriptMgr.GetArrayObject<Vector4>(L, 3);
			obj.SetVectorArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector4[] objs1 = LuaScriptMgr.GetArrayObject<Vector4>(L, 3);
			obj.SetVectorArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<Vector4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<Vector4> arg1 = (List<Vector4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetVectorArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<Vector4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<Vector4> arg1 = (List<Vector4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetVectorArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetVectorArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMatrixArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Matrix4x4[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4[] objs1 = LuaScriptMgr.GetArrayObject<Matrix4x4>(L, 3);
			obj.SetMatrixArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Matrix4x4[])))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Matrix4x4[] objs1 = LuaScriptMgr.GetArrayObject<Matrix4x4>(L, 3);
			obj.SetMatrixArray(arg0,objs1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<Matrix4x4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<Matrix4x4> arg1 = (List<Matrix4x4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetMatrixArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<Matrix4x4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<Matrix4x4> arg1 = (List<Matrix4x4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.SetMatrixArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetMatrixArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			float o = obj.GetFloat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float o = obj.GetFloat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			int o = obj.GetInt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int o = obj.GetInt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Color o = obj.GetColor(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color o = obj.GetColor(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector4 o = obj.GetVector(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4 o = obj.GetVector(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Matrix4x4 o = obj.GetMatrix(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 o = obj.GetMatrix(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloatArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float[] o = obj.GetFloatArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			float[] o = obj.GetFloatArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<float>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<float> arg1 = (List<float>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetFloatArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<float>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<float> arg1 = (List<float>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetFloatArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetFloatArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVectorArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4[] o = obj.GetVectorArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector4[] o = obj.GetVectorArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<Vector4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<Vector4> arg1 = (List<Vector4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetVectorArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<Vector4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<Vector4> arg1 = (List<Vector4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetVectorArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetVectorArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColorArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Color[] o = obj.GetColorArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color[] o = obj.GetColorArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<Color>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<Color> arg1 = (List<Color>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetColorArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<Color>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<Color> arg1 = (List<Color>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetColorArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetColorArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMatrixArray(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4[] o = obj.GetMatrixArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Matrix4x4[] o = obj.GetMatrixArray(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(List<Matrix4x4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			List<Matrix4x4> arg1 = (List<Matrix4x4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetMatrixArray(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(List<Matrix4x4>)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			List<Matrix4x4> arg1 = (List<Matrix4x4>)LuaScriptMgr.GetLuaObject(L, 3);
			obj.GetMatrixArray(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetMatrixArray");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Texture o = obj.GetTexture(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Texture o = obj.GetTexture(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextureOffset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector2 o = obj.GetTextureOffset(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector2 o = obj.GetTextureOffset(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTextureOffset");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextureScale(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			Vector2 o = obj.GetTextureScale(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector2 o = obj.GetTextureScale(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTextureScale");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOBlendableColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Color arg0 = LuaScriptMgr.GetColor(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			DG.Tweening.Tweener o = obj.DOBlendableColor(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Color arg0 = LuaScriptMgr.GetColor(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			DG.Tweening.Tweener o = obj.DOBlendableColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.DOBlendableColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOVector(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		Vector4 arg0 = LuaScriptMgr.GetVector4(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		DG.Tweening.Tweener o = obj.DOVector(arg0,arg1,arg2);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOTiling(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			DG.Tweening.Tweener o = obj.DOTiling(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			DG.Tweening.Tweener o = obj.DOTiling(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.DOTiling");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOOffset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			DG.Tweening.Tweener o = obj.DOOffset(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			DG.Tweening.Tweener o = obj.DOOffset(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.DOOffset");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOFloat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		DG.Tweening.Tweener o = obj.DOFloat(arg0,arg1,arg2);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOFade(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			DG.Tweening.Tweener o = obj.DOFade(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			DG.Tweening.Tweener o = obj.DOFade(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.DOFade");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Color arg0 = LuaScriptMgr.GetColor(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			DG.Tweening.Tweener o = obj.DOColor(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = (Material)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material");
			Color arg0 = LuaScriptMgr.GetColor(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			DG.Tweening.Tweener o = obj.DOColor(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.DOColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}


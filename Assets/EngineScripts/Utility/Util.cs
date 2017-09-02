using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.GZip;
using LuaInterface;
using System.Net;

public class Util : UtilCommon{
    public static void PushBufferToLua(LuaFunction func, byte[] buffer) {
        LuaScriptMgr mgr = ioo.gameManager.uluaMgr;
        int oldTop = func.BeginPCall();
        LuaDLL.lua_pushlstring(mgr.lua.L, buffer, buffer.Length);
        if (func.PCall(oldTop, 1)) func.EndPCall(oldTop);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public static Material CreateMat(Material mat)
    {
        Material newMat = GameObject.Instantiate(mat) as Material;
        return newMat;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Material CreateMat(string path)
    {
        Shader shader = ShaderFind(path);
        if (null == shader)
            return null;

        Material mat = new Material(shader);
        return mat;
    }

    /// <summary>
    /// Ѱ��Shader
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Shader ShaderFind(string path)
    {
        ResourceMisc.AssetWrapper aw = ioo.resourceManager.LoadAsset(path, typeof(Shader));

        Shader shader = (Shader)aw.GetAsset();
        if (null == shader)
        {
            Debug.LogError("the shader " + path + " is not exit");
            return null;
        }
        
        return shader;
    }

    /// <summary>
    /// ���ò���������
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="property"></param>
    /// <param name="value"></param>
    public static void SetFloat(Material mat, string property, float value)
    {
        mat.SetFloat(property, value);
    }

    /// <summary>
    /// ���ò���������
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="property"></param>
    /// <param name="value"></param>
    public static void SetInit(Material mat, string property, int value)
    {
        mat.SetInt(property, value);
    }

    /// <summary>
    /// ���ò�������ɫ
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="property"></param>
    /// <param name="color"></param>
    public static void SetColor(Material mat, string property, Color color)
    {
        mat.SetColor(property, color);
    }

    //public static void PosTween(GameObject go, float duration, Vector3 pos, 
    //        int style = 0, int method = 0, LuaFunction finished = null, bool newObj = true)
    //{
    //    UnityAction action = () =>
    //    {
    //        if (finished != null)
    //        {
    //            finished.Call ();
    //        }
    //    };
    //    TweenPos.Tween (go, duration, pos, (TweenMain.Style)style, (TweenMain.Method)method, (finished != null)?action:null, newObj);
    //}

    //public static void ScaleTween(GameObject go, float duration, Vector3 scale, 
    //        int style = 0, int method = 0, LuaFunction finished = null, bool newObj = true)
    //{
    //    UnityAction action = () =>
    //    {
    //        if (finished != null)
    //        {
    //            finished.Call();
    //        }
    //    };
    //    TweenScale.Tween (go, duration, scale, (TweenMain.Style)style, (TweenMain.Method)method, (finished != null)?action:null, newObj);
    //}

    //public static void RotTween(GameObject go, float duration, Quaternion rot,
    //        int style = 0, int method = 0, LuaFunction finished = null, bool newObj = true)
    //{
    //    UnityAction action = () =>
    //    {
    //        if (finished != null)
    //        {
    //            finished.Call();
    //        }
    //    };
    //    TweenRot.Tween (go, duration, rot, (TweenMain.Style)style, (TweenMain.Method)method, (finished != null)?action:null, newObj);
    //}

    //public static void ColorTween(GameObject go, float duration, Color color,
    //    int style = 0, int method = 0, LuaFunction finished = null, bool newObj = true)
    //{
    //    UnityAction action = () =>
    //    {
    //        if (finished != null)
    //        {
    //            finished.Call ();
    //        }
    //    };
    //    TweenColor.Tween (go, duration, color, (TweenMain.Style)style, (TweenMain.Method)method, (finished != null)?action:null, newObj);
    //}

    //public static void CGAlphaTween(GameObject go, float duration, float alpha,
    //    int style = 0, int method = 0, LuaFunction finished = null, bool newObj = true)
    //{
    //    UnityAction action = () =>
    //    {
    //        if (finished != null)
    //        {
    //            finished.Call ();
    //        }
    //    };
    //    TweenCGAlpha.Tween (go, duration, alpha, (TweenMain.Style)style, (TweenMain.Method)method, (finished != null)?action:null, newObj);
    //}

    //public static void AlphaTween(GameObject go, float duration, float alpha,
    //    int style = 0, int method = 0, LuaFunction finished = null, bool newObj = true)
    //{
    //    UnityAction action = () =>
    //    {
    //        if (finished != null)
    //        {
    //            finished.Call ();
    //        }
    //    };
    //    TweenAlpha.Tween (go, duration, alpha, (TweenMain.Style)style, (TweenMain.Method)method, (finished != null)?action:null, newObj);
    //}

    public static string GetLocalIPAddress()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "";
    }

    public static Transform FindTransformByName(Transform transform, string name)
    {
        if (transform.name == name)
            return transform;
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform t = FindTransformByName(transform.GetChild(i), name);
            if (t != null)
                return t;
        }
        return null;
    }

	public static string TEXT(string text)
	{
		if (ioo.gameManager.uluaMgr == null)
			return text;
		else
		{
			LuaFunction f = ioo.gameManager.uluaMgr.GetLuaFunction("TEXT");
			object[] res = f.Call(text);
			return (string)res[0];
		}
	}
    public static Vector2 ScreenPointToLocalPointInRectangle(RectTransform rect, Vector2 screenPoint, Camera cam)
    {
        Vector2 tempWorldPos = new Vector3();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam, out tempWorldPos);
        return tempWorldPos;
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="param"></param>
    public static void RandomSortList<T>(ref List<T> param)
    {
        for (int i = 0; i < param.Count; ++i)
        {
            int rd = UnityEngine.Random.Range(0, param.Count);
            if (rd != i)
            {
                T temp = param[i];
                param[i] = param[rd];
                param[rd] = temp;
            }
        }
    }
}

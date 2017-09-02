/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   ExtendMethod.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/4/5 15:07:24
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public static class ExtendMethod
{

    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T t = go.GetComponent<T>();
        if (null == t)
            t = go.AddComponent<T>();
        return t;
    }
}

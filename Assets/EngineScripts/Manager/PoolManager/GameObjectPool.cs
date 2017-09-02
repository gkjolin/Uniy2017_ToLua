﻿/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   PoolManager.cs
 * 
 * 简    介:    对象池
 * 
 * 创建标识：   Pancake 2017/4/2 11:04:59
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameObjectPool
{
    /// <summary>
    /// 名字
    /// </summary>
    public string name;

    /// <summary>
    /// 路径
    /// </summary>
    public string path;
    /// <summary>
    /// 预制体
    /// </summary>
    private GameObject prefab;

    /// <summary>
    /// 预先生成各个数
    /// </summary>
    [SerializeField]
    private int preAmount = 2;

    /// <summary>
    /// 最大数量
    /// </summary>
    [SerializeField]
    private int maxAmount = 10;

    /// <summary>
    /// 个数
    /// </summary>
    private int count;

    /// <summary>
    /// 存放对象池正被使用的对象
    /// </summary>
    private List<GameObject> useList = new List<GameObject>();

    /// <summary>
    /// 存放对象池中空闲状态下的对象
    /// </summary>
    private List<GameObject> freeList = new List<GameObject>();

    public int Count { get { return useList.Count + freeList.Count; } }

    /// <summary>
    /// 预加载最大个数
    /// </summary>
    public void PreLoad()
    {
        CreateByCount(maxAmount);
    }

    /// <summary>
    /// 指定创建个数
    /// </summary>
    /// <param name="num"></param>
    public void CreateByCount(int num)
    {
        if (num > maxAmount)
            num = maxAmount;
        if (Count >= num)
            return;

        num = num - Count;
        for (int i = 0; i < num; ++i)
            CreateNewInstance();
    }

    /// <summary>
    /// 表示从资源池中获取一个实例
    /// </summary>
    public GameObject GetInstance()
    {
        GameObject ret = null;

        if (freeList.Count == 0)
            CreateNewInstance();

        ret = freeList[0];
        freeList.RemoveAt(0);
        useList.Add(ret);

        ret.SetActive(true);
        return ret;
    }

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="go"></param>
    public void Destory(GameObject go)
    {
        useList.Remove(go);
        go.SetActive(false);
        SetToFree(go);
    }

    public bool Contain(GameObject go)
    {
        if (useList.Contains(go))
            return true;
        return false;
    }

    /// <summary>
    /// 清除缓存
    /// </summary>
    public void Clear()
    {
        useList.Clear();
        freeList.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="go"></param>
    private void SetToFree(GameObject go)
    {
        if (freeList.Count + useList.Count > maxAmount)
            GameObject.Destroy(go);
        else
            freeList.Add(go);
    }

    /// <summary>
    /// 创建新的对象
    /// </summary>
    /// <returns></returns>
    private void CreateNewInstance()
    {
        if (null == prefab)
        {
            ResourceMisc.AssetWrapper aw = ioo.resourceManager.LoadAsset(path, typeof(GameObject));
            prefab = GameObject.Instantiate(aw.GetAsset()) as GameObject;
            prefab.SetActive(false);
            prefab.transform.SetParent(PoolManager._parentTransform);
            freeList.Add(prefab);
        }
        else
        {
            GameObject go = GameObject.Instantiate(prefab) as GameObject;
            go.SetActive(false);
            go.transform.SetParent(PoolManager._parentTransform);
            freeList.Add(go);
        }
    }
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   SceneManager.cs
 * 
 * 简    介:    负责场景逻辑控制，刷新Agent
 * 
 * 创建标识：   Pancake 2017/4/26 9:58:37
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class ScenesManager : MonoBehaviour
{
    public int _sceneID;

    void Awake()
    {
        ioo.gameManager.RegisterUpdate(SMUpdate);
        ioo.gameManager.RegisterFixedUpdate(SMFixedUpdate);
    }

    void Destroy()
    {
        ioo.gameManager.UnregisterUpdate(SMUpdate);
        ioo.gameManager.UnregisterFixedUpdate(SMFixedUpdate);
    }


    private void SMUpdate()
    {

    }

    private void SMFixedUpdate()
    {

    }
}

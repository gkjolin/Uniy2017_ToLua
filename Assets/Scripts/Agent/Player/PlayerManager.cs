/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   PlayerManager.cs
 * 
 * 简    介:    管理玩家
 * 
 * 创建标识：   Pancake 2017/4/27 11:43:50
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// 玩家列表
    /// </summary>
    private List<GamePlayer> _playerList = new List<GamePlayer>();

    /// <summary>
    /// 最大玩家数量
    /// </summary>
    private int _plyerCount = 3;

    public List<GamePlayer> PlayerList { get { return _playerList; } }
    #region Unity Call Back
    void Awake()
    {
        ioo.gameManager.RegisterUpdate(UpdatePreFrame);
        ioo.gameManager.RegisterFixedUpdate(UpdateFixedFrame);
    }

    /// <summary>
    /// 创建玩家
    /// </summary>
    void Start()
    {
        for (int i = 0; i < _plyerCount; ++i )
        {
            GamePlayer player = new GamePlayer();
            player.Init(i);
            _playerList.Add(player);
        }
    }

    void Destroy()
    {
        ioo.gameManager.UnregisterUpdate(UpdatePreFrame);
        ioo.gameManager.UnregisterFixedUpdate(UpdateFixedFrame);
    }
    #endregion

    #region Public Function
    /// <summary>
    /// 重置所有玩家数据
    /// </summary>
    public void Reset()
    {
        for (int i = 0; i < _playerList.Count; ++i )
        {
            _playerList[i].Reset();
        }
    }

    /// <summary>
    /// 清除币数
    /// </summary>
    public void ClearCoin()
    {
        for (int i = 0; i < _playerList.Count; ++i)
        {
            _playerList[i].ClearCoin();
        }
    }

    /// <summary>
    /// 获取玩家数量
    /// </summary>
    /// <returns></returns>
    public int PlayerCount()
    {
        return _playerList.Count;
    }

    /// <summary>
    /// 获取指定玩家
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GamePlayer GetPlayer(int index)
    {
        return _playerList[index];
    }
    #endregion

    #region Private Function
    /// <summary>
    /// 帧更新
    /// </summary>
    private void UpdatePreFrame()
    {
        for (int i = 0; i < _playerList.Count; ++i )
        {
            _playerList[i].UpdatePreFrame();
        }
    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    private void UpdateFixedFrame()
    {
        for (int i = 0; i < _playerList.Count; ++i)
        {
            _playerList[i].UpdateFexedFrame();
        }
    }

    #endregion
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   GameMode.cs
 * 
 * 简    介:    游戏状态控制
 * 
 * 创建标识：   Pancake 2017/4/26 8:29:05
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public partial class GameMode : MonoBehaviour
{
    /// <summary>
    /// 游戏状态
    /// </summary>
    private GameState _state;

    /// <summary>
    /// Key关卡，Value是否解锁
    /// </summary>
    private Dictionary<LevelsScene, bool> _levelsDic = new Dictionary<LevelsScene, bool>();


    public GameState State                          { get { return _state; } }
    public Dictionary<LevelsScene, bool> LevelDic   { get { return _levelsDic; } }

    #region Unity Call Back
    void Awake()
    {
        ioo.gameManager.RegisterUpdate(UpdatePreFrame);
        ioo.gameManager.RegisterFixedUpdate(UpdateFixedFrame);
    }

    void Destroy()
    {
        ioo.gameManager.UnregisterUpdate(UpdatePreFrame);
        ioo.gameManager.UnregisterFixedUpdate(UpdateFixedFrame);
    }
    #endregion
    

    #region Public Function
    public void ModeStart()
    {
        _state = GameState.Start;
        LockAllLevels();

    }


    /// <summary>
    /// 设置游戏状态
    /// </summary>
    /// <param name="state"></param>
    public void RunState(GameState state)
    {
        _state = state;
    }

    /// <summary>
    /// 解锁关卡
    /// </summary>
    /// <param name="level"></param>
    public void SetLevelUnlock(LevelsScene level)
    {
        if (!_levelsDic.ContainsKey(level))
        {
            Debug.Log("The level: " + level.ToString() + " is not exit !");
            return;
        }

        if (!_levelsDic[level])
        {
            _levelsDic[level] = true;
        }
    }
    #endregion

    #region Private Function
    /// <summary>
    /// 锁死所有关卡
    /// </summary>
    private void LockAllLevels()
    {
        _levelsDic.Clear();
        for (LevelsScene level = LevelsScene.DongShaCun; level < LevelsScene.FZHCRLYJZHXin;)
        {
            _levelsDic.Add(level, false);
            level = (LevelsScene)((int)level + 1);
        }
    }

    /// <summary>
    /// 帧更新
    /// </summary>
    private void UpdatePreFrame()
    {
        // 执行玩家输入
        OnPlayerInput();

    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    private void UpdateFixedFrame()
    {

    }
    #endregion
    
}

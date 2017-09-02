/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Player.cs
 * 
 * 简    介:    玩家控制类
 * 
 * 创建标识：   Pancake 2017/4/27 11:04:38
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections;

public class GamePlayer
{
    #region 基础数据
    /// <summary>
    /// 最大生命值
    /// </summary>
    private int _maxHealth = 100;

    /// <summary>
    /// 最大水量
    /// </summary>
    private float _maxWater;

    /// <summary>
    /// 基础攻击力
    /// </summary>
    private int _baseAttack = 1;

    /// <summary>
    /// 续币允许最大时间
    /// </summary>
    private int _continueTime = 10;

    #endregion
    /// <summary>
    /// ID
    /// </summary>
    private int _id;

    /// <summary>
    /// 拥有币数
    /// </summary>
    private int _coin;

    /// <summary>
    /// 得分
    /// </summary>
    private int _score;

    /// <summary>
    /// 生命值
    /// </summary>
    private int _health;

    /// <summary>
    /// 水量
    /// </summary>
    private float _water;

    /// <summary>
    /// 攻击力
    /// </summary>
    private int _attackValue;

    /// <summary>
    /// 当前状态
    /// </summary>
    private PlayerState _state;

    /// <summary>
    /// 水标在屏幕上的坐标
    /// </summary>
    private Vector2 _pos;

    private Vector2 _screenInfo;

    public int Coin             { get { return _coin; } }
    public int Score            { get { return _score; } }
    public int Health           { get { return _health; } }
    public float AttackValue    { get { return _attackValue; } }
    public Vector2 Pos          { get { return _pos; } }

    #region Public Function
    /// <summary>
    /// 初始化数据
    /// </summary>
    public void Init(int id)
    {
        _id             = id;
        _health         = _maxHealth;
        _attackValue    = _baseAttack;
        _coin           = SettingManager.Instance.HasCoin[id];
    }

    /// <summary>
    /// 重置数据
    /// </summary>
    public void Reset()
    {
        Init(_id);
    }

    /// <summary>
    /// 投币
    /// </summary>
    public void AddCoin(int value = 1)
    {
        if (_coin < 99)
            _coin += value;
    }

    /// <summary>
    /// 是否满足游戏条件
    /// </summary>
    public bool CanPlay()
    {
        int rate = SettingManager.Instance.GameRate;
        if (_coin >= rate)
        {
            ChangeState(PlayerState.Waitting);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 进行游戏
    /// </summary>
    public void ChangePlay()
    {
        int rate = SettingManager.Instance.GameRate;
        _coin    -= rate;
        SettingManager.Instance.Save();
    }

    /// <summary>
    /// 改变玩家爱状态
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(PlayerState state)
    {
        if (_state == state)
            return;

        _state = state;
    }

    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        _score += value;
    }
    
    /// <summary>
    /// 改变玩家爱生命值
    /// </summary>
    public void ChangeHealth(int value)
    {
        _health += value;
        if (_health < 0)
            _health = 0;

        if (_health  > _maxHealth)
            _health = _maxHealth;
    }

    /// <summary>
    /// 清除币数
    /// </summary>
    public void ClearCoin()
    {
        _coin = 0;
    }

    /// <summary>
    /// 帧更新
    /// </summary>
    public void UpdatePreFrame()
    {
        _pos = Input.mousePosition;      
    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    public void UpdateFexedFrame()
    {

    }
    #endregion

    #region Private Function
    
    #endregion
}

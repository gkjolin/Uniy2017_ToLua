/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   SkillType.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/4/24 18:16:24
 * 
 * 修改描述：
 * 
 */


using System.Collections.Generic;
using UnityEngine;

public class Define
{
    /// <summary>
    /// 最小赛段
    /// </summary>
    public static int MIN_SEGMENT = 5;
    /// <summary>
    /// 最大赛段
    /// </summary>
    public static int MAX_SEGMENT = 9;

    /// <summary>
    /// 最小速度比例
    /// </summary>
    public static float MIN_SPEED_RATE = 0.95f;
    /// <summary>
    /// 最大速度比例
    /// </summary>
    public static float MAX_SPEED_RATE = 1.05f;

    /// <summary>
    /// 赛道长度
    /// </summary>
    public static float RUNWAY_LENGTH = 500;

    /// <summary>
    /// 每帧时间;
    /// </summary>
    public static float FRAME_TIME = 0.0166666f;

    public static float MIN_ACCELERATION_RATE = 0.05f;
    public static float MAX_ACCELERATION_RATE = 0.10f;

    public static float MIN_NO1_TIME = 19.0f;
    public static float MAX_NO1_TIME = 21.0f;

    public static float MIN_RUNNERS_TIME_DELTA = 0.03f;
    public static float MAX_RUNNERS_TIME_DELTA = 0.07f;

    public static float REPLAY_RATE = 4;

    public static float SLOWDOWN_TIME = 1.2f;
}

public class SegmentData
{
    public float Length;
    public float StartPos;
    public float EndPos;
    /// <summary>
    /// 参考速度用来计算时间的;
    /// </summary>
    public float RefSpeed;

    /// <summary>
    /// 加速或加速后正常行驶的速度;
    /// </summary>
    public float NormalSpeed
    {
        protected set;
        get;
    }


    protected List<float> posList = new List<float>();

    /// <summary>
    /// 先变速，后匀速;
    /// </summary>
    /// <param name="prevSpeed"></param>
    public void LerpPosition(float prevSpeed, ref float lastPos)
    {
        float pos = lastPos;
        float costTime = Length / RefSpeed;

        //随机获取加速时间;
        float accelerationRate = RandomLib.Instance.GetAccelerationRate();

        float accerationTime = costTime * accelerationRate;
        float normalSpeedTime = costTime - accerationTime;

        //计算加速度(用运动公式计算的)
        // 通过 V = V0 + A*T0
        // S = V0*T0 + (1/2)*A*T0*T0 + V*T2
        // 其中A是加速度，V是匀速运动的速率，V0是起始速率，也就是参数prevSpeed
        // S是位移，也就是Length，T0是加速时间，T1是匀速运动时间.
        // 通过上面两个公式 得出 加速度 A = (2*S - 2V0*T1 - 2*V0*T2)/(T1*T1 + 2*T1*T2)
        // 这里不用考虑是加速还是减速，通过prevSpeed可以得出需要加速还是减速;

        float acceleration = 2 * (Length - prevSpeed * accerationTime - prevSpeed * normalSpeedTime) / (Mathf.Pow(accerationTime, 2) + 2 * accerationTime * normalSpeedTime);

        //计算加速后的均匀速速;
        NormalSpeed = prevSpeed + acceleration * accerationTime;

        float theTime = 0;
        while (theTime < accerationTime)
        {
            pos += (prevSpeed + (acceleration * theTime)) * Define.FRAME_TIME;
            posList.Add(pos);
            theTime += Define.FRAME_TIME;
        }

        while (theTime < costTime)
        {
            pos += NormalSpeed * Define.FRAME_TIME;
            posList.Add(pos);
            theTime += Define.FRAME_TIME;
        }

        lastPos = pos;
    }

    public float[] GetPosArray()
    {
        List<float> retList = new List<float>();
        for (int i = 0; i < posList.Count; ++i)
        {
            retList.Add(posList[i]);
        }

        return retList.ToArray();
    }

}

/// <summary>
/// 技能枚举
/// </summary>
public static class SkillID
{
    #region Boss0

    /// <summary>
    /// 火妖自爆
    /// </summary>
    public const int Explode_FM = 1001;

    /// <summary>
    /// 大火妖挥拳
    /// </summary>
    public const int Fist_FM = 1002;

    /// <summary>
    /// 冲撞
    /// </summary>
    public const int Crash = 1003;

    /// <summary>
    /// 砸屏幕
    /// </summary>
    public const int Screen = 10004;

    /// <summary>
    /// 扔炸弹
    /// </summary>
    public const int ThrowBomb = 1005;

    /// <summary>
    /// 贴靠山
    /// </summary>
    public const int Backer = 1006;

    /// <summary>
    /// 设计屏幕
    /// </summary>
    public const int ShootScreen = 1005;


    /// <summary>
    /// 火球术
    /// </summary>
    public const int  FireBall = 1019;
    /// <summary>
    /// 挥拳头
    /// </summary>
    public const int Fist       = 1020;
    /// <summary>
    /// 过热
    /// </summary>
    public const int OverHot    = 1021;
    #endregion

    ///// <summary>
    ///// 待机
    ///// </summary>
    //Idle,
    ///// <summary>
    ///// 分身
    ///// </summary>
    //Cloned,
    ///// <summary>
    ///// 无敌
    ///// </summary>
    //Unbeatable,
    ///// <summary>
    ///// 闪现
    ///// </summary>
    //Flash,
    ///// <summary>
    ///// 劈砍
    ///// </summary>
    //Sabrecut,
}

/// <summary>
/// FSM消息枚举
/// </summary>
public enum FSMMesgType
{
    /// <summary>
    /// 动画播放完毕
    /// </summary>
    AnimationEnd,
}


/// <summary>
/// Tag
/// </summary>
public class GameTage
{
    public const string PatrolPoint = "PatrolPoint";
}

/// <summary>
/// 游戏状态
/// </summary>
public enum GameState
{
    /// <summary>
    /// 开始界面
    /// </summary>
    Start,
    /// <summary>
    /// 待机视频
    /// </summary>
    Movie,
    /// <summary>
    /// 选择
    /// </summary>
    Select,
    /// <summary>
    /// 进行游戏
    /// </summary>
    Play,
    /// <summary>
    /// 是否继续游戏
    /// </summary>
    Continue,
    /// <summary>
    /// 游戏结束
    /// </summary>
    End,
}

/// <summary>
/// 关卡
/// </summary>
public enum LevelsScene
{
    /// <summary>
    /// 东沙村
    /// </summary>
    DongShaCun,
    /// <summary>
    /// 闹鬼森林
    /// </summary>
    NaoGuiSenLin,
    /// <summary>
    /// 安拉胡啊库巴沙漠
    /// </summary>
    ALHAKBShaMo,
    /// <summary>
    /// 沙哈拉雪山
    /// </summary>
    ShaHaLaXueShan,
    /// <summary>
    /// 非正常人类研究中心
    /// </summary>
    FZHCRLYJZHXin,
}

/// <summary>
/// 玩家游戏状态
/// </summary>
public enum PlayerState
{
    /// <summary>
    /// 等待
    /// </summary>
    Waitting,
    /// <summary>
    /// 进行中
    /// </summary>
    Play,
    /// <summary>
    /// 是否续币
    /// </summary>
    Continue,
    /// <summary>
    /// 死亡
    /// </summary>
    Dead,
}
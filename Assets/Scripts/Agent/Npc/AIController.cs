/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   AIController.cs
 * 
 * 简    介:    Ai测试
 * 
 * 创建标识：   Pancake 2017/4/24   10:11:21
 * 
 * 修改描述：
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AIController : AdvanceFSM
{
    /// <summary>
    /// 状态转换条件
    /// </summary>
    public enum Transition
    {
        /// <summary>
        /// 
        /// </summary>
        NullTransition,
        /// <summary>
        /// 发现玩家爱
        /// </summary>
        SawPlayer,
        /// <summary>
        /// 接近玩家
        /// </summary>
        ReachPalyer,
        /// <summary>
        /// 丢失玩家
        /// </summary>
        LostPlayer,
        /// <summary>
        /// 没有生命了
        /// </summary>
        NoHealth
    }

    /// <summary>
    /// 状态对应的行为
    /// </summary>
    public enum FSMActionID
    {
        /// <summary>
        /// 
        /// </summary>
        NullStateID,
        /// <summary>
        /// 巡逻
        /// </summary>
        Patroling,
        /// <summary>
        /// 追逐主角状体
        /// </summary>
        Chasing,
        /// <summary>
        /// 攻击
        /// </summary>
        Attacking,
        /// <summary>
        /// 死亡
        /// </summary>
        Dead
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Initialize()
    {
        elapseTime  = 0;
        shootRate   = 2;
        //初始化玩家角色
        GameObject objPlayer    = GameObject.FindGameObjectWithTag("Player");
        _playerTransfrom        = objPlayer.transform;
        if (_playerTransfrom == null)
        {
            Debug.Log("找不到玩家");
        }
        
        // 注册消息
        RegesterHandle(FSMMesgType.AnimationEnd, ShootBullet);

        ConstructFSM();
    }

    /// <summary>
    /// 帧更新
    /// </summary>
    protected override void FSMUpdate()
    {
        elapseTime += Time.deltaTime;
    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(_playerTransfrom, transform);
        CurrentState.Act(_playerTransfrom, transform);
    }

    /// <summary>
    /// 状态机初始化
    /// </summary>
    private void ConstructFSM()
    {
        //进行路点初始化
        pointList = GameObject.FindGameObjectsWithTag("PatrolPoint");

        Transform[] wayPoints = new Transform[pointList.Length];
        int i = 0;
        foreach (GameObject obj in pointList)
        {
            wayPoints[i] = obj.transform;
            i++;
        }
        //针对每一个行为进行初始化, 针对于每个行为进行状态到行为转变的添加
        //巡逻
        Patrol patrol = new Patrol(wayPoints, this);
        patrol.AddTransition((int)Transition.SawPlayer, (int)FSMActionID.Chasing);
        patrol.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        //追逐
        Chase chase = new Chase(wayPoints, this);
        chase.AddTransition((int)Transition.ReachPalyer, (int)FSMActionID.Attacking);
        chase.AddTransition((int)Transition.LostPlayer, (int)FSMActionID.Patroling);
        chase.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        //攻击
        Attack attack = new Attack(wayPoints, this);
        attack.AddTransition((int)Transition.SawPlayer, (int)FSMActionID.Chasing);
        attack.AddTransition((int)Transition.LostPlayer, (int)FSMActionID.Patroling);
        attack.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        //死亡
        Dead dead = new Dead();
        dead.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);

        //把状态列表进行初始化
        AddFSMState(patrol);
        AddFSMState(chase);
        AddFSMState(attack);
        AddFSMState(dead);

        StartFSM(patrol);
    }

   /// <summary>
   /// 射击
   /// TODO
   /// </summary>
    public void ShootBullet()
    {
        if (elapseTime >= shootRate)
        {
            //定义一个子弹预置体的引用
            //对其进行实例化（建议用对象池）
            //再封装一个子弹的行为脚本
            elapseTime = 0;
            Debug.Log("Shoot!");
        }
    }
}

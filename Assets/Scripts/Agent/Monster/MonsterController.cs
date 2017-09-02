/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   MonsterController.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/5/22 17:40:47
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class MonsterController : AdvanceFSM
{
    /// <summary>
    /// 状态转换条件
    /// </summary>
    public enum Transition
    {
        Idle,
        /// <summary>
        /// 发现玩家
        /// </summary>
        SawPlayer,
        /// <summary>
        /// 接近玩家
        /// </summary>
        ReachPalyer,
        /// <summary>
        /// 没有生命
        /// </summary>
        NoHealth,
    }

    /// <summary>
    /// 状态对应的行为
    /// </summary>
    public enum FSMActionID
    {
        Idle,
        /// <summary>
        /// 移动
        /// </summary>
        Chase,
        /// <summary>
        /// 攻击
        /// </summary>
        Attack,
        /// <summary>
        /// 死亡
        /// </summary>
        Dead,
    }

    protected override void Initialize()
    {

        ConstructFSM();
    }

    protected override void FSMOnDestroy()
    {

    }

    /// <summary>
    /// 帧更新
    /// </summary>
    protected override void FSMUpdate()
    {

    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(_playerTransfrom, transform);
        CurrentState.Act(_playerTransfrom, transform);
    }

    public void InitPO(AgentPO po)
    {
        _health = po.Health;
        _worth = po.Score;
        _moveSpeed = po.Speed;
        _agentID = po.Id;
    }

    private void ConstructFSM()
    {

    }
}

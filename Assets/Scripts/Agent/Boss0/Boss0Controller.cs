/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Boss0Controller.cs
 * 
 * 简    介:    东沙村Boss
 * 
 * 创建标识：   Pancake 2017/4/24 17:38:23
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;


public class Boss0Controller : Boss
{
    /// <summary>
    /// 状态转换条件
    /// </summary>
    public enum Transition
    {
        /// <summary>
        /// 嘲讽
        /// </summary>
        Provoke,
        /// <summary>
        /// 不释放任何技能和嘲讽动作
        /// </summary>
        NoSkill,
        /// <summary>
        /// 使用过热技能
        /// </summary>
        Hot,
        /// <summary>
        /// 使用挥拳技能
        /// </summary>
        Fist,
        /// <summary>
        /// 使用火球技能
        /// </summary>
        Fire,
        /// <summary>
        /// 没血
        /// </summary>
        NoHealth,
    }

    /// <summary>
    /// 状态对应的行为
    /// </summary>
    public enum FSMActionID
    {

        /// <summary>
        /// 嘲讽
        /// </summary>
        Provoke,
        /// <summary>
        /// 移动
        /// </summary>
        Move,
        /// <summary>
        /// 过热
        /// </summary>
        OverHot,
        /// <summary>
        /// 挥拳
        /// </summary>
        Fist,
        /// <summary>
        /// 火球术
        /// </summary>
        FireBall,
        /// <summary>
        /// 死亡
        /// </summary>
        Dead,
    }

    protected override void BossInitialize()
    {
        _health = 10;

        ConstructFSM();
    }

    #region Public Function
    /// <summary>
    /// 提供外部接口，初始化Boss数据
    /// </summary>
    /// <param name="po"></param>
    public override void InitPO(AgentPO po)
    {
        _health = po.Health;
        _worth = po.Score;
        _moveSpeed = po.Speed;
        _agentID = po.Id;
        _moveOrRate = po.MoveOrProRate;
        _coolDic.Clear();
        for (int i = 0; i < po.Skills.Length; ++i)
        {
            int skillID = po.Skills[i];
            SkillsPO skill = SkillsData.Instance.GetSkillsPO(skillID);
            if (!_coolDic.ContainsKey(skill))
            {
                _coolDic.Add(skill, skill.CoolTime);
            }
        }
    }

    #endregion
   

    protected override void BossOnDesroy()
    {
      
    }


    /// <summary>
    /// 帧更新
    /// </summary>
    protected override void UpdatePreFrame()
    {
      
    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    protected override void UpdateFixedFrame()
    {
        CurrentState.Reason(_playerTransfrom, transform);
        CurrentState.Act(_playerTransfrom, transform);
    }

    private void ConstructFSM()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag(GameTage.PatrolPoint);
        Transform[] trans = new Transform[points.Length];

        for (int i = 0; i < points.Length; ++i)
            trans[i] = points[i].transform;


        Boss0Move move = new Boss0Move(this, trans);
        move.AddTransition((int)Transition.Fire, (int)FSMActionID.FireBall);
        move.AddTransition((int)Transition.Fist, (int)FSMActionID.Fist);
        move.AddTransition((int)Transition.Hot, (int)FSMActionID.OverHot);
        move.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        //move.AddTransition((int)Transition.Provoke, (int)FSMActionID.Provoke);

        Boss0Provoke provoke = new Boss0Provoke(this);
        provoke.AddTransition((int)Transition.NoSkill, (int)FSMActionID.Move);
        provoke.AddTransition((int)Transition.Fire, (int)FSMActionID.FireBall);
        provoke.AddTransition((int)Transition.Fist, (int)FSMActionID.Fist);
        provoke.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        provoke.AddTransition((int)Transition.Hot, (int)FSMActionID.OverHot);

        Boss0Dead dead = new Boss0Dead(this);
        dead.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);

        Boss0FireBall fireBall = new Boss0FireBall(this);
        fireBall.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        fireBall.AddTransition((int)Transition.NoSkill, (int)FSMActionID.Move);
        fireBall.AddTransition((int)Transition.Provoke, (int)FSMActionID.Provoke);

        Boss0Fist fist = new Boss0Fist(this);
        fist.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        fist.AddTransition((int)Transition.NoSkill, (int)FSMActionID.Move);
        fist.AddTransition((int)Transition.Provoke, (int)FSMActionID.Provoke);

        Boss0OverHot overHot = new Boss0OverHot(this);
        overHot.AddTransition((int)Transition.NoHealth, (int)FSMActionID.Dead);
        overHot.AddTransition((int)Transition.NoSkill, (int)FSMActionID.Move);
        overHot.AddTransition((int)Transition.Provoke, (int)FSMActionID.Provoke);

        AddFSMState(move);
        AddFSMState(provoke);
        AddFSMState(dead);
        AddFSMState(fireBall);
        AddFSMState(fist);
        AddFSMState(overHot);

        StartFSM(move);
    }

}

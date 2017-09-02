/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Boss1Controller.cs
 * 
 * 简    介:    闹鬼森林Boss
 * 
 * 创建标识：   Pancake 2017/4/28 9:32:43
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class Boss1Controller : Boss
{
    /// <summary>
    /// 状态转换条件
    /// </summary>
    public enum Transition
    {

        /// <summary>
        /// 不释放任何技能和嘲讽动作
        /// </summary>
        NoSkill,
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
        /// 移动
        /// </summary>
        Move,
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

    }

}

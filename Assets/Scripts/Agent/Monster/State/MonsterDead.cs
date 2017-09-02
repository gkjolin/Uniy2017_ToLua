/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   MonsterDead.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/5/22 17:57:46
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class MonsterDead : FSMState
{
    public MonsterDead(AdvanceFSM afsm)
    {

        fsm      = afsm;
        animator = afsm.GetAnimator;
        actionID = (int)MonsterController.FSMActionID.Dead;
    }


    public override void Reason(Transform player, Transform npc)
    {
        throw new System.NotImplementedException();
    }


    public override void Act(Transform player, Transform npc)
    {
        throw new System.NotImplementedException();
    }
	
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   MonsterDead.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/5/22 17:53:26
 * 
 * 修改描述：
 * 
 */

using UnityEngine;
using System.Collections;

public class MonsterIdle : FSMState
{
    public MonsterIdle(AdvanceFSM afsm)
    {

        fsm      = afsm;
        animator = afsm.GetAnimator;
        actionID = (int)MonsterController.FSMActionID.Idle;
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

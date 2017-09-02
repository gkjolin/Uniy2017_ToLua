/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Boss0Dead.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/4/25 14:53:49
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class Boss0Dead : FSMState
{

    public Boss0Dead(AdvanceFSM afsm)
    {

        fsm      = afsm;
        animator = afsm.GetAnimator;
        actionID = (int)Boss0Controller.FSMActionID.Dead;
    }


    public override void Reason(Transform player, Transform npc)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Die") && info.normalizedTime >= 1)
        {
            fsm.TriggerHandle(FSMMesgType.AnimationEnd);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (!info.IsName("Die"))
        {
            animator.SetInteger("State", 4);
        }
    }
}

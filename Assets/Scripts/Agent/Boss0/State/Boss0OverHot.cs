/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Boss0OverHot.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/4/25 14:51:45
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class Boss0OverHot : FSMState
{

    public Boss0OverHot(AdvanceFSM afsm)
    {

        fsm      = afsm;
        animator = afsm.GetAnimator;
        actionID = (int)Boss0Controller.FSMActionID.OverHot;
    }

    public override void Reason(Transform player, Transform npc)
    {
        if (fsm.Health <= 0)
        {
            fsm.PerformTransition((int)Boss0Controller.Transition.NoHealth);
            return;
        }

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("OverHot") && info.normalizedTime >= 1)
        {
            fsm.TriggerHandle(FSMMesgType.AnimationEnd);
            int rand = Random.Range(0, 100);
            if (rand < 50)
                fsm.PerformTransition((int)Boss0Controller.Transition.NoSkill);
            else
                fsm.PerformTransition((int)Boss0Controller.Transition.Provoke);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (!info.IsName("OverHot"))
        {
            animator.SetInteger("State", 1);
        }
    }
}

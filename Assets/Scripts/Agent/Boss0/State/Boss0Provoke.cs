/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Boss0Provoke.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/4/25 14:26:14
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class Boss0Provoke : FSMState
{
    public Boss0Provoke(AdvanceFSM afsm)
    {
        fsm         = afsm;
        animator    = afsm.GetAnimator;
        actionID    = (int)Boss0Controller.FSMActionID.Provoke;
    }

    public override void Reason(Transform player, Transform npc)
    {
        if (fsm.Health <= 0)
        {
            fsm.PerformTransition((int)Boss0Controller.Transition.NoHealth);
            return;
        }

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Provoke") && info.normalizedTime >= 1)
        {
            fsm.TriggerHandle(FSMMesgType.AnimationEnd);

            if (fsm.CanPlayNext && fsm.CurrSkillPO != null)
            {
                fsm.CanPlayNext = false;
                switch (fsm.CurrSkillPO.Id)
                {
                    case SkillID.FireBall:
                        fsm.PerformTransition((int)Boss0Controller.Transition.Fire);
                        break;
                    case SkillID.Fist:
                        fsm.PerformTransition((int)Boss0Controller.Transition.Fist);
                        break;
                    case SkillID.OverHot:
                        fsm.PerformTransition((int)Boss0Controller.Transition.Hot);
                        break;
                }
            }else
                fsm.PerformTransition((int)Boss0Controller.Transition.Provoke);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (!info.IsName("Provoke"))
        {
            animator.SetInteger("State", 1);
        }
    }
}

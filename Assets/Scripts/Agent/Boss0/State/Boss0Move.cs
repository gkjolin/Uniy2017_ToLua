/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Boss0Move.cs
 * 
 * 简    介:    
 * 
 * 创建标识：   Pancake 2017/4/25 14:49:50
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections.Generic;

public class Boss0Move : FSMState
{
    public Boss0Move(AdvanceFSM afsm, Transform[] pints)
    {

        fsm         = afsm;
        wayPoints   = pints;
        animator    = afsm.GetAnimator;
        actionID    = (int)Boss0Controller.FSMActionID.Move;

        FindNextPoint();
    }

    public override void Reason(Transform player, Transform npc)
    {
        //AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        //if (info.IsName("Move") && info.normalizedTime >= 1)
        //{
        //    fsm.TriggerHandle(FSMMesgType.AnimationEnd);
        //}
        if (fsm.Health <= 0)
        {
            fsm.PerformTransition((int)Boss0Controller.Transition.NoHealth);
            return;
        }

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
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        curSpeed        = 1;
        curRotSpeed     = 10;
        arriveDistance  = 0.5f;

        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (!info.IsName("Idle"))
        {
            animator.SetInteger("State", 1);
        }

        if (Vector3.Distance(npc.position, destPos) < arriveDistance)
        {
            FindNextPoint();
        }

        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        npc.position += npc.forward * Time.deltaTime * curSpeed;
    }
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Attack.cs
 * 
 * 简    介:    攻击
 * 
 * 创建标识：   Pancake 2017/4/24   09:51:41
 * 
 * 修改描述：
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Attack : FSMState
{
    public Attack(Transform[] wp, AdvanceFSM afsm)
    {
        fsm         = afsm;

        wayPoints   = wp;
        actionID = (int)AIController.FSMActionID.Attacking;
        curRotSpeed = 12;
        curSpeed    = 100;

        FindNextPoint();//指定攻击对象
    }

    public override void Reason(Transform player, Transform npc)
    {
        float dist = Vector3.Distance(npc.position, player.position);
        // 发现玩家
        if (dist >= attackDistance && dist < chaseDistance)
        {
            fsm.PerformTransition((int)AIController.Transition.SawPlayer);
        }
        // 丢失玩家
        else if (dist >= chaseDistance)
        {
            fsm.PerformTransition((int)AIController.Transition.LostPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        destPos = player.position;

        npc.transform.LookAt(destPos);
        npc.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ////旋转方向
        //Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        //npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        //播放动画
        //开枪
        fsm.TriggerHandle(FSMMesgType.AnimationEnd);
        Animation anim = npc.GetComponent<Animation>();
        anim.CrossFade("Shoot");
    }
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Chase.cs
 * 
 * 简    介:    追逐
 * 
 * 创建标识：   Pancake 2017/4/24   09:31:56
 * 
 * 修改描述：
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Chase : FSMState
{
    public Chase(Transform[] wp, AdvanceFSM afsm)
    {
        fsm         = afsm;

        wayPoints   = wp;
        actionID = (int)AIController.FSMActionID.Chasing;
        curRotSpeed = 6;
        curSpeed    = 160;

        FindNextPoint();//追逐的目标
    }

    public override void Reason(Transform player, Transform npc)
    {
        destPos = player.position;
        float dist = Vector3.Distance(npc.position,destPos);
        // 转变到攻击状态
        if (dist <= attackDistance) 
        {
            fsm.PerformTransition((int)AIController.Transition.ReachPalyer);
        }
        // 转变到巡逻状态
        else if(dist>=chaseDistance)
        {
            fsm.PerformTransition((int)AIController.Transition.LostPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        destPos = player.position;

        npc.transform.LookAt(destPos);
        npc.GetComponent<Rigidbody>().velocity = npc.transform.forward * 2;
        ////旋转方向
        //Quaternion targetRotation = Quaternion.LookRotation(destPos-npc.position);
        //npc.rotation = Quaternion.Slerp(npc.rotation,targetRotation,Time.deltaTime*curRotSpeed);

        ////移动
        //CharacterController controller=npc.GetComponent<CharacterController>();
        //controller.SimpleMove(npc.transform.forward*Time.deltaTime*curSpeed);

        //播放动画
        Animation anim = npc.GetComponent<Animation>();
        anim.CrossFade("Run");

    }
}

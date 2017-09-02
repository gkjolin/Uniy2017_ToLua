/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Patrol.cs
 * 
 * 简    介:    巡逻
 * 
 * 创建标识：   Pancake 2017/4/24   09:18:26
 * 
 * 修改描述：
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Patrol : FSMState
{
    /// <summary>
    /// 初始化
    /// </summary>
    public Patrol(Transform[] wp, AdvanceFSM afsm)
    {
        fsm = afsm;

        wayPoints   = wp;
        actionID    = (int)AIController.FSMActionID.Patroling;
        curRotSpeed = 6;
        curSpeed    = 80;

        destPos = wayPoints[0].transform.position;
    }

    public override void Reason(Transform player, Transform npc)
    {
        // 转换为追逐状态
        if (Vector3.Distance(npc.position, player.position) <= chaseDistance)
        {
            fsm.PerformTransition((int)AIController.Transition.SawPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        // 到到达了巡逻点
        if (Vector3.Distance(npc.position, destPos) <= arriveDistance)
        {
            FindNextPoint();
        }

        npc.transform.LookAt(destPos);
        npc.GetComponent<Rigidbody>().velocity = npc.transform.forward * 2;

        ////确定我当前角色的方向
        //Quaternion targetRotation   = Quaternion.LookRotation(destPos - npc.position);
        //npc.rotation                = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        ////让角色移动
        //CharacterController controller = npc.GetComponent<CharacterController>();
        //controller.SimpleMove(npc.forward * Time.deltaTime * curSpeed);

        //播放动画

        Animation anim = npc.GetComponent<Animation>();
        anim.CrossFade("Walk");
    }
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   Dead.cs
 * 
 * 简    介:    死亡
 * 
 * 创建标识：   Pancake 2017/4/24   09:31:22
 * 
 * 修改描述：
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Dead : FSMState
{
    public Dead()
    {
        actionID = (int)AIController.FSMActionID.Dead;
    }

    public override void Reason(Transform player, Transform npc)
    {
           
    }

    public override void Act(Transform player, Transform npc)
    {
        Animation anim = npc.GetComponent<Animation>();
        anim.CrossFade("Dead");
    }
}

/**
* Copyright (广州纷享游艺设备有限公司-研发视频组) 2012,广州纷享游艺设备有限公司
* All rights reserved.
* 
* 文件名称：IOManager.cs
* 简    述：获取模拟器操作信息
* 创建标识：meij  2015/10/28
* 修改标识：meij  2015/11/10
* 修改描述：采用1个COM端口进行协议收发。
*/

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class IOManager : MonoBehaviour
{
    private SerialIOHost serialIoHost;
    private IOEvent ie;
    private IOEvent[] ioEvent;                       //协议信息数组   每帧最多包含MAX_PLAYER_NUMBER个协议数,
    private int ioCount;

    private byte[] byteHost = new byte[14];

    void Awake()
    {
        ioo.gameManager.RegisterUpdate(UpdateInputEvent);
        ioo.gameManager.RegisterUpdate(UpdateIOEvent);
    }

    void Start()
    {
        Init(3);
    }

    void Destroy()
    {
        ioo.gameManager.UnregisterUpdate(UpdateInputEvent);
        ioo.gameManager.UnregisterUpdate(UpdateIOEvent);
    }

    // 每帧中每条协议对应一个角色信息)
    #region ----------------------获取当前帧中，对应Player的协议信息-----------------------------------
    public  byte GetPlayerID(int i)
    {
        return ioEvent[i].ID;
    }

    public bool GetIsOutTicket(int i)
    {
        return ioEvent[i].IsOutTicket;
    }

    public bool GetIsCoin(int i)
    {
        return ioEvent[i].IsCoin;
    }

    public bool GetIsStart(int i)
    {
        return ioEvent[i].IsStart;
    }

    public bool GetIsPush1(int i)
    {
        return ioEvent[i].IsPush1;
    }

    public bool GetIsPush2(int i)
    {
        return ioEvent[i].IsPush2;
    }

    public bool GetIsLeft (int i)
    {
        return ioEvent[i].IsLeft;
    }

    public bool GetIsRight (int i)
    {
        return ioEvent[i].IsRight;
    }

    //重置指定角色操作数据
    public void ResetEvent(int i, bool isRacing = false)
    {
        ioEvent[i].IsCoin       = false;
        ioEvent[i].IsOutTicket  = false;
        ioEvent[i].IsPush1      = false;
        ioEvent[i].IsPush2      = false;
        ioEvent[i].IsStart      = false;
        if (!isRacing)
        {
            ioEvent[i].IsRight = false;
            ioEvent[i].IsLeft = false;
        }
       
    }
    #endregion

    #region ----------------设置下发协议信息-----------------------------

    #endregion ---------------------------------------------
    public SerialIOHost GetSerialIoHost(int i)
    {
        return serialIoHost;
    }

    /// <summary>
    /// 应用程序退出操作
    /// </summary>
    public void Close()
    {
        if (serialIoHost != null)
        {
            serialIoHost.Close();
        }    
    }

    public void ResetIO()
    {
        if (null != serialIoHost)
        {
            serialIoHost.Close();
            serialIoHost = null;
            serialIoHost = new SerialIOHost();
        }
    }

    //初始化操作，打开端口，初始化ioEvent数组
    public void Init(int portCount)
    {
        ioCount          = portCount;
        ioEvent          = new IOEvent[portCount];

        serialIoHost = new SerialIOHost();
        for (byte i = 0; i < ioCount; i++)
        {
            ioEvent[i]    = new IOEvent();
        }
             
        //if (!serialIoHost.Setup(14, 8, 10))
        //{
        //    Debug.Log("SerialIO setup failed!!");
        //}
        //else
        //{
        //    serialIoHost.OnReceiveFailed += () => { Debug.Log("Read Failed !!!"); };
        //    serialIoHost.OnReceiveSucceed += ReadDatas;
        //}
    }

    private void ReadDatas()
    {
        int num = 0;
        for (byte i = 0; i < ioCount; i++)
        {
            byte data = serialIoHost.Read(num);
            ioEvent[i].ID = data;
            data = serialIoHost.Read(num + 1);

            ioEvent[i].IsCoin       = (data & 0x80) != 0;
            ioEvent[i].IsOutTicket  = (data & 0x40) != 0;
            ioEvent[i].IsPush1      = (data & 0x20) != 0;
            ioEvent[i].IsPush2      = (data & 0x10) != 0;
            ioEvent[i].IsStart      = (data & 0x8) != 0;
            ioEvent[i].IsRight      = (data & 0x4) != 0;
            ioEvent[i].IsLeft       = (data & 0x2) != 0;
            num += 4;
        }
    }

    /// <summary>
    /// 每帧分别读取一次协议队列中的协议，并存入协议信息类对象数组ioEvent
    /// </summary>
    public void UpdateIOEvent()
    {
        if(serialIoHost != null && serialIoHost.HadDevice())
        {
            serialIoHost.UpdateIOHost();
         
            //向下位机发协议
            int num = 0;
            for (byte i = 0; i < ioCount;i++ )
            {
                serialIoHost.Write(num, i);

                num += 2;
            }
        }            
     } 

    /// <summary>
    /// 键盘控制
    /// </summary>
    public void UpdateInputEvent()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ioEvent[0].IsCoin = true;
            IOLuaHelper.Instance.TriggerListener(EnumIOEvent.onCoin);
        }
        
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ioEvent[0].IsStart = true;
            IOLuaHelper.Instance.TriggerListener(EnumIOEvent.onSure);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ioEvent[0].IsLeft = true;
            IOLuaHelper.Instance.TriggerListener(EnumIOEvent.onLeft);
        }else if (Input.GetKeyUp(KeyCode.A))
        {
            ioEvent[0].IsLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ioEvent[0].IsRight = true;
            IOLuaHelper.Instance.TriggerListener(EnumIOEvent.onRight);
        }else if (Input.GetKeyUp(KeyCode.D))
        {
            ioEvent[0].IsRight = false;
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            ioEvent[0].IsPush1 = true;
            IOLuaHelper.Instance.TriggerListener(EnumIOEvent.onButtonA);
        }
        else if (Input.GetKeyUp(KeyCode.PageUp))
        {
            ioEvent[0].IsPush1 = false;
        }

        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            ioEvent[0].IsPush2 = true;
            IOLuaHelper.Instance.TriggerListener(EnumIOEvent.onButtonB);
        }else if (Input.GetKeyUp(KeyCode.PageUp))
        {
            ioEvent[0].IsPush2 = false;
        }
    }
}


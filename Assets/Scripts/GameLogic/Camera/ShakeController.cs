﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ShakeController : MonoBehaviour {

    public int actionCount;
    private bool  startPlay;
    private float speedMount;
    private float waveMount;
    private float shakeStartTime;
    private ShakeAction currentShake;
    private Dictionary<int, ShakeAction> shakeDic;
    private Transform parent;
    private Vector3 original; 

	// Use this for initialization
	void Start () 
    {
        parent = gameObject.transform.parent;
        shakeDic = new Dictionary<int, ShakeAction>();
        for (int index = 1; index <= actionCount; ++index)
        {
            string goName = "Action" + index.ToString();
            ShakeAction go = transform.Find(goName).GetComponent<ShakeAction>();
            shakeDic.Add(go.shakeTypeName, go);
        }

        startPlay = false;
        original = Camera.main.transform.position;
        addEvent();
	}

    void OnDestroy()
    {
        removeEvent();
    }

    void LateUpdate()
    {
        if (startPlay)
        {
            float passTime = (Time.realtimeSinceStartup - shakeStartTime) * (speedMount / 10);
            parent.position = parent.position + new Vector3(currentShake.xPosCurve.Evaluate(passTime), currentShake.yPosCurve.Evaluate(passTime), currentShake.zPosCurve.Evaluate(passTime)) * (waveMount / 10);
            parent.eulerAngles = parent.eulerAngles + new Vector3(currentShake.xRotateCurve.Evaluate(passTime), currentShake.yRotateCurve.Evaluate(passTime), currentShake.zRotateCurve.Evaluate(passTime)) * 360 * (waveMount / 10);
            if (passTime > currentShake.length * (speedMount / 10))
            {
                startPlay = false;
                parent.DOMove(original,0.1f);
            }
        }
    }

    public void OnEventPlay(int type)
    {
        // 暂定处理 当前动作在进行中时则不接受其他的请求
        if (startPlay)
        {
            return;
        }

        float speedPlus     = 0.0f;
        float waveMountPlus = 0.0f;
        if (type == 1)
        {
            speedPlus     = 14.0f;
            waveMountPlus = 1.0f;
        }
        else if (type == 2)
        {
            speedPlus     = 17.0f;
            waveMountPlus = 2.0f;
        }
        else if (type == 3)
        {
            speedPlus     = 30.0f;
            waveMountPlus = 1.0f;
        }

        if (shakeDic.ContainsKey (type))
        {
			speedMount      = speedPlus;
			waveMount       = waveMountPlus;
            currentShake    = shakeDic[type];
			shakeStartTime  = Time.realtimeSinceStartup;
			startPlay       = true;	
		}
    }

    void OnGUI()
    {

        //if (GUI.Button(new Rect(115, 130, 80, 50), "Load"))
        //{
        //    OnEventPlay(1, 5.0f, 2.0f);
        //}
    }


    /// <summary>
    /// 添加逻辑监听
    /// </summary>
    protected virtual void addEvent()
    {
        //EventDispatcher.AddEventListener<int>(GameEventDef.EVNET_PLAY_SHAKE, OnEventPlay);
    }

    /// <summary>
    /// 移除逻辑事件监听
    /// </summary>
    protected virtual void removeEvent()
    {
        //EventDispatcher.RemoveEventListener<int>(GameEventDef.EVNET_PLAY_SHAKE, OnEventPlay);
    }
}

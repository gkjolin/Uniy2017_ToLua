/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   CameraManager.cs
 * 
 * 简    介:    相机管理类：多人镜头， 相机震动
 * 
 * 创建标识：   Pancake 2017/4/27 15:45:17
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour
{
    /// <summary>
    /// 主相机
    /// </summary>
    private Camera _mainCamera;

    /// <summary>
    /// 相机左右饶Y轴选择的允许最大值
    /// </summary>
    private float _leftRotation = -5;
    private float _rightRotation = 5;

    private float _curRotation;

    private float _rotationSpeed = 10;

    /// <summary>
    /// 左转
    /// </summary>
    private bool _left;

    /// <summary>
    /// 右转
    /// </summary>
    private bool _right;


    /// <summary>
    /// 检测半径
    /// </summary>
    private float _checkRadius = 300;


    public bool Left  { set { _left = value; } }
    public bool Right { set { _right = value; } }
    #region Unity Call Back
    void Awake()
    {
        ioo.gameManager.RegisterUpdate(UpdatePreFrame);
        ioo.gameManager.RegisterFixedUpdate(UpdateFixedFrame);
    }

    void Destroy()
    {
        ioo.gameManager.UnregisterUpdate(UpdatePreFrame);
        ioo.gameManager.UnregisterFixedUpdate(UpdateFixedFrame);
    }
    #endregion

    #region Public Function
    
    #endregion

    #region Private Function
  
    /// <summary>
    /// 帧更新
    /// </summary>
    private void UpdatePreFrame()
    {
        if (!HasMainCamera())
            return;

        CheckeRotationDir();

        // 相机左转
        if (_left && !_right)
        {
            if (_curRotation > 360 + _leftRotation || _curRotation <= _rightRotation)
            {
                _curRotation = _mainCamera.transform.localEulerAngles.y;
                _curRotation -= Time.deltaTime * _rotationSpeed;
                if (_curRotation < 360 + _leftRotation && _curRotation > _rightRotation)
                    _curRotation = 360 + _leftRotation;
                _mainCamera.transform.localEulerAngles = new Vector3(_mainCamera.transform.localEulerAngles.x, _curRotation, _mainCamera.transform.localEulerAngles.z);
            }
        }

        // 相机右转
        if (!_left && _right)
        {
            if (_curRotation < _rightRotation || _curRotation >= 360 + _leftRotation)
            {
                _curRotation = _mainCamera.transform.localEulerAngles.y;
                _curRotation += Time.deltaTime * _rotationSpeed;
                if (_curRotation > _rightRotation && _curRotation < 360 + _leftRotation)
                    _curRotation = _rightRotation;
                _mainCamera.transform.localEulerAngles = new Vector3(_mainCamera.transform.localEulerAngles.x, _curRotation, _mainCamera.transform.localEulerAngles.z);
            }
           
        }

        if (!_left && !_right)
        {
            if (_curRotation >= 360 + _leftRotation)
            {
                _curRotation = _mainCamera.transform.localEulerAngles.y;
                _curRotation += Time.deltaTime * _rotationSpeed;
                if (_curRotation > 360)
                    _curRotation = 360;
            }else if (_curRotation <= 5)
            {
                _curRotation = _mainCamera.transform.localEulerAngles.y;
                _curRotation -= Time.deltaTime * _rotationSpeed;
                if (_curRotation < 0)
                    _curRotation = 0;
            }
            _mainCamera.transform.localEulerAngles = new Vector3(_mainCamera.transform.localEulerAngles.x, _curRotation, _mainCamera.transform.localEulerAngles.z);
        }
    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    private void UpdateFixedFrame()
    {
        if (!HasMainCamera())
            return;


    }

    /// <summary>
    /// 是否有主相机
    /// </summary>
    /// <returns></returns>
    private bool HasMainCamera()
    {
        if (_mainCamera == null)
        {
            _curRotation = 0;
            _mainCamera  = Camera.main;
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// 检测相机选择方向
    /// </summary>
    private void CheckeRotationDir()
    {
        bool[] leftList  = new bool[ioo.playerManager.PlayerList.Count];
        bool[] rightList = new bool[ioo.playerManager.PlayerList.Count];
        for (int i = 0; i < ioo.playerManager.PlayerList.Count; ++i)
        {
            Vector3 pos = ioo.playerManager.PlayerList[i].Pos;
            if (pos.x - _checkRadius <= 0)
            {
                ioo.cameraManager.Left = true;
                leftList[i] = true;
            }
            else
            {
                leftList[i] = false;
            }

            if (pos.x + _checkRadius >= Screen.width)
            {
                ioo.cameraManager.Right = true;
                rightList[i] = true;
            }
            else
            {
                rightList[i] = false;
            }
        }

        _left = false;
        for (int i = 0; i < leftList.Length; ++i)
        {
            if (leftList[i])
            {
                _left = true;
                break;
            }
        }

        _right = false;
        for (int i = 0; i < rightList.Length; ++i)
        {
            if (rightList[i])
            {
                _right = true;
                break;
            }
        }
    }


    //void OnGUI()
    //{
    //    GUI.Label(new Rect(200, 200, 200, 200), _left + "  " + _right);
    //}
    #endregion
}

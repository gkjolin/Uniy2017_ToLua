/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   FSMBase.cs
 * 
 * 简    介:    状态机管理类的基类
 * 
 * 创建标识：   Pancake 2017/4/3 16:18:26
 * 
 * 修改描述：
 * 
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnumAgentType
{
    /// <summary>
    /// 英雄
    /// </summary>
    Hero = 0,
    /// <summary>
    /// 怪物老大
    /// </summary>
    Boss,
    /// <summary>
    /// boo外的怪物
    /// </summary>
    Monster,
    /// <summary>
    /// 掉落物品
    /// </summary>
    Drop,
    /// <summary>
    /// 被召唤物
    /// </summary>
    Call,
    /// <summary>
    /// 分身
    /// </summary>
    Clone,
}

public class FSMBase : MonoBehaviour
{
    /// <summary>
    /// 血量
    /// </summary>
    protected int _health;

    /// <summary>
    /// 存在时间
    /// </summary>
    protected float _lifeTime;

    /// <summary>
    /// 价值（杀死该单位，收益）
    /// </summary>
    protected int _worth;

    /// <summary>
    /// 移动速度
    /// </summary>
    protected float _moveSpeed;

    /// <summary>
    /// 单位类型
    /// </summary>
    protected EnumAgentType _agentType;

    ///// <summary>
    ///// 技能组件
    ///// </summary>
    //protected SkillComponent _skillComponent;

    /// <summary>
    /// 技能冷却表
    /// </summary>
    protected Dictionary<SkillsPO, float> _coolDic = new Dictionary<SkillsPO, float>();

    //---
    /// <summary>
    /// 可以播放技能
    /// </summary>
    protected bool _canPlayNext;

    /// <summary>
    /// 技能播放完毕
    /// </summary>
    protected bool _animationEnd;

    /// <summary>
    /// 连续播放技能的时间间隔
    /// </summary>
    protected float _interval;
    //---


    /// <summary>
    /// 释放技能队列
    /// </summary>
    protected Queue<SkillsPO> _skillQueue = new Queue<SkillsPO>();

    /// <summary>
    /// 
    /// </summary>
    protected SkillsPO _skillPO;
   
    /// <summary>
    /// 所有者
    /// </summary>
    protected FSMBase _parentFSM;

    /// <summary>
    /// 继承真身攻击力百分比
    /// </summary>
    protected float _inheritPercent;

    /// <summary>
    /// 分身额外受到的伤害
    /// </summary>
    protected float _extraHurt;

    /// <summary>
    /// 移动或嘲讽全职
    /// </summary>
    protected float[] _moveOrRate;

    protected Animation _animation;
    protected Animator _animator;

    /// <summary>
    /// 唯一标识
    /// </summary>
    protected int _guid;

    /// <summary>
    /// agent id
    /// </summary>
    protected int _agentID;

    public int Health                   { get { return _health; }           set { _health           = value; } }
    public float LiefeTime              { get { return _lifeTime; }         set { _lifeTime         = value; } }
    public EnumAgentType AgentType      { get { return _agentType; }        set { _agentType        = value; } }
    public float InheritPercent         { get { return _inheritPercent; }   set { _inheritPercent   = value; } }
    public float ExtraHurt              { get { return _extraHurt; }        set { _extraHurt        = value; } }
    public int GUID                     { get { return _guid; }             set { _guid             = value; } }
    public FSMBase ParentFSM            { get { return _parentFSM; }        set { _parentFSM = value; } }
    public Queue<SkillsPO> SkillQueue   { get { return _skillQueue; } }
    public SkillsPO CurrSkillPO         { get { return _skillPO; } set { _skillPO = value; } }
    public bool CanPlayNext             { get { return _canPlayNext; }      set { _canPlayNext = value; } }
    public bool AnimationEnd            { get { return _animationEnd; }     set { _animationEnd = value; } }
    public Animator GetAnimator         { get { return _animator; }         set { _animator = value; } }
    public Animation GetAnimation       { get { return _animation; }        set { _animation = value; } }
    public int Worth                    { get { return _worth; }            set { _worth = value; } }
    public float MoveSpeed              { get { return _moveSpeed; }        set { _moveSpeed = value; } }
    public int AgentID                  { get { return _agentID; }          set { _agentID = value; } }
    public float[] MoveOrRate           { get { return _moveOrRate; }       set { _moveOrRate = value; } }
    //public SkillComponent SkillComponent { get { return _skillComponent; } }

    /// <summary>
    /// 玩家
    /// </summary>
    protected Transform _playerTransfrom;

    /// <summary>
    /// 巡逻点
    /// </summary>
    protected GameObject[] pointList;

    /// <summary>
    /// 目标点
    /// </summary>
    protected Vector3 destPos;

    protected float shootRate;

    /// <summary>
    /// 射击间隔时间
    /// </summary>
    protected float elapseTime;

    /// <summary>
    /// 初始化   
    /// </summary>
    protected virtual void Initialize() { }
    /// <summary>
    /// 初始化数值  MonsterPO 后面可改，将玩家属性也陪到这里面来，统一整合为AgentPO
    /// </summary>
    public virtual void InitPO(AgentPO po) { }
    /// <summary>
    /// 更新
    /// </summary>
    protected virtual void FSMUpdate() { }

    /// <summary>
    /// 固定更新
    /// </summary>
    protected virtual void FSMFixedUpdate() { }
    /// <summary>
    /// 销毁
    /// </summary>
    protected virtual void FSMOnDestroy() { }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        FSMUpdate();
    }

    void FixedUpdate()
    {
        FSMFixedUpdate();
    }

    void OnDestroy()
    {
        FSMOnDestroy();
    }
}

/*
 * Copyright (广州纷享游艺设备有限公司-研发视频组) 
 * 
 * 文件名称：   AudioManager.cs
 * 
 * 简    介:    音效管理，音效资源的创建和管理，但不负责音效的具体功能操作          TODO: 功能还要进一步完善
 * 
 * 创建标识：   Pancake 2017/4/2 10:12:28
 * 
 * 修改描述：   
 * 
 */

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// 用于缓存AudioClip以及Asset
    /// </summary>
    private class AudioCache
    {
        // 未使用的音效缓存列表
        private List<AudioClip> _clipList;
        /// <summary>
        /// 允许拥有音效的最大数量
        /// </summary>
        private int _maxCount;

        /// <summary>
        ///  音效资源
        /// </summary>
        private UnityEngine.Object _asset;
        public UnityEngine.Object Asset { set { _asset = value; } }

        public AudioCache()
        {
            _maxCount = 4;
            _clipList = new List<AudioClip>();
        }

        /// <summary>
        /// 将暂不使用的音效回收
        /// </summary>
        /// <param name="clip"></param>
        public void AddClip(AudioClip clip)
        {
            if (_clipList.Count >= _maxCount)
            {
                GameObject.Destroy(clip);
                return;
            }
            _clipList.Add(clip);
        }

        /// <summary>
        /// 获取一个音效
        /// </summary>
        /// <returns></returns>
        public AudioClip GetClip()
        {
            if (_clipList.Count > 0)
            {
                AudioClip clip = _clipList[0];
                _clipList.RemoveAt(0);
                return clip;
            }
            else
                return CreateClip();
        }

        /// <summary>
        /// 清理内存
        /// </summary>
        public void ClearMemory()
        {
            GC.Collect();
            Resources.UnloadAsset(_asset);
        }

        /// <summary>
        /// 创建一个音效
        /// </summary>
        /// <returns></returns>
        private AudioClip CreateClip()
        {
            AudioClip clip = (AudioClip)GameObject.Instantiate(_asset);
            return clip;
        }
    }

    /// <summary>
    /// 所有音效根组件
    /// </summary>
    private GameObject _audioParent;

    /// <summary>
    /// 允许最大AudioChannel数量
    /// </summary>
    private int _maxChannel = 20;

    /// <summary>
    /// 配置文件
    /// </summary>
    private Dictionary<string, string> configDic = new Dictionary<string, string>();
    /// <summary>
    /// 缓存音效，正在使用
    /// </summary>
    private List<AudioChannel> useList = new List<AudioChannel>();
    /// <summary>
    /// 缓存音效，不使用
    /// </summary>
    private List<AudioChannel> freeList = new List<AudioChannel>();

    private List<AudioChannel> toFreeList = new List<AudioChannel>();

    private Dictionary<string, AudioCache> ClipCacheDic = new Dictionary<string, AudioCache>();

    void Awake()
    {
        _audioParent = new GameObject("AudioParent");
        _audioParent.AddComponent<AudioListener>();
        DontDestroyOnLoad(_audioParent);
        Init();
    }

    #region 提供外部调用方法 无需玩家调用
    /// <summary>
    /// 由AudioChannel自动调用
    /// </summary>
    /// <param name="channel"></param>
    public void ToFree(AudioChannel channel)
    {
        // 防止同一帧里多次调用停止播放同一音效
        if (toFreeList.Contains(channel))
            return;
        toFreeList.Add(channel);
    }

    /// <summary>
    /// 切换场景时，有场景管理器自动调用
    /// </summary>
    public void Clear()
    {
        ClipCacheDic.Clear();
    }
    #region 背景音乐
    /// <summary>
    /// 播放背景音效
    /// </summary>
    /// <param name="name"></param>
    public void PlayBackMusic(string name, bool loop = true)
    {
        AudioChannel item = GetAudioItem(name);
        AudioClip clip = LoadAudicClip(name);
        item.Init(name, clip, false);
        item.SetMusic(loop);
        item.Play();
    }

    /// <summary>
    /// 停止播放背景音效
    /// </summary>
    public void StopBackMusic(string name)
    {
        for (int i = 0; i < useList.Count; ++i )
        {
            if (name.Equals(useList[i].Name))
            {
                AudioChannel item = useList[i];
                item.Stop();
            }
        }
    }
    #endregion

    #region 音效
    /// <summary>
    /// 在指定位置上播放音效
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pos"></param>
    /// <param name="spatial"></param>
    public void PlaySoundOnPoint(string name, Vector3 pos)
    {
        AudioChannel item = GetAudioItem(name);
        if (name.Equals(item.Name))
        {
            item.Init(name, item.Clip, pos, true);
            item.SetSound();
            item.Play();
        }else
        {
            AudioClip clip = LoadAudicClip(name);
            item.Init(name, clip, pos, true);
            item.SetSound();
            item.Play();
        }
    }

   /// <summary>
   /// 在指定对象上播放音效
   /// </summary>
   /// <param name="name">音效名</param>
   /// <param name="go">指定对象</param>
   /// <param name="spatial">是否是3D音效</param>
    public void PlaySoundOnObj(string name, GameObject go)
    {
        AudioChannel item = GetAudioItem(name);
        if (name.Equals(item.Name))
        {
            item.Init(name, item.Clip, go, true);
            item.SetSound();
            item.Play();
        }
        else
        {
            AudioClip clip = LoadAudicClip(name);
            item.Init(name, clip, go, true);
            item.SetSound();
            item.Play();
        }
    }

    /// <summary>
    /// 无需指定位置音效
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound2D(string name)
    {
        AudioChannel item = GetAudioItem(name);
        if (name.Equals(item.Name))
        {
            item.Init(name, item.Clip);
            item.SetSound();
            item.Play();
        }
        else
        {
            AudioClip clip = LoadAudicClip(name);
            item.Init(name, clip);
            item.SetSound();
            item.Play();
        }

    }
    #endregion

    #region 人物语音
    public void PlayPersonSound(string name)
    {
        int language = SettingManager.Instance.GameLanguage;
        string extend = language == 0 ? "_cn" : "en";
        name += extend;
        PlaySound2D(name);
    }
    #endregion


    /// <summary>
    /// 停止所有音效
    /// </summary>
    public void StopAll()
    {
        foreach(AudioChannel channel in useList)
            channel.Stop();
    }

    #endregion
    private void Init()
    {
        Prepare();
        LoadAudioConfig();
    }

    private void Prepare()
    {
        for (int i = 0; i < 10; ++i )
        {
            AudioChannel item  = CreateAudioItem();
            freeList.Add(item);
        }
    }

    /// <summary>
    /// 加载配置文件
    /// </summary>
    private void LoadAudioConfig()
    {
        configDic.Clear();
        if (!File.Exists(Const.GetLocalFileUrl(Const.Audio_Coinfig_Path)))
        {
            Debug.LogError("缺少音效配置文件");
            return;
        }

        string[] lines = File.ReadAllLines(Const.GetLocalFileUrl(Const.Audio_Coinfig_Path));
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue   = line.Split(',');
            configDic.Add(keyvalue[0], keyvalue[1]);
        }
    }


    /// <summary>
    /// 载入一个音频
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private AudioClip LoadAudicClip(string name)
    {
        if (!ClipIsExit(name))
        {
            Debug.LogError("The audio name: " + name + " is not exit!");
            return null;
        }

        AudioClip clip = null;

        if (ClipCacheDic.ContainsKey(name) && ClipCacheDic[name] != null)
        {
            AudioCache cache = ClipCacheDic[name];
            clip = cache.GetClip();
        }

        if (clip != null)
            return clip;          

        ResourceMisc.AssetWrapper aw = ioo.resourceManager.LoadAsset(configDic[name], typeof(AudioClip));
        if (null == aw)
        {
            Debug.LogError("The AudioClip name: " + name + " is not exit, please check the assetbundle");
            return null;
        }
        clip = (AudioClip)aw.GetAsset();

        AudioCache temp = new AudioCache();
        ClipCacheDic.Add(name, temp);
        temp.Asset = aw.GetAsset();
        clip = temp.GetClip();

        return clip;
    }

    /// <summary>
    /// 指定音效是否存在于配置文件
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool ClipIsExit(string name)
    {
        if (configDic.ContainsKey(name))
            return true;
        return false;
    }

    /// <summary>
    /// 获取一个AudioChannel
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private AudioChannel GetAudioItem(string name)
    {
        AudioChannel item = null;
        if (freeList.Count > 0)
            item = freeList[0];

        if (null != item)
        {
            freeList.Remove(item);
            useList.Add(item);
        }else
            item = CreateAudioItem();

        item.gameObject.SetActive(true);

        return item;
    }

    /// <summary>
    /// 创建AudioChannel
    /// </summary>
    /// <returns></returns>
    private AudioChannel CreateAudioItem()
    {
        GameObject obj = new GameObject("AudioChannel");
        obj.transform.SetParent(_audioParent.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(false);
        AudioChannel item = obj.GetOrAddComponent<AudioChannel>();
        return item;
    }

    void Update()
    {
        for (int i = 0; i < toFreeList.Count; ++i )
        {
            AudioChannel channel = toFreeList[i];

            // 回收AudioClip
            Dictionary<string, AudioCache>.Enumerator er = ClipCacheDic.GetEnumerator();
            while (er.MoveNext())
            {
                if (er.Current.Key.Equals(channel.Name))
                {
                    AudioCache cache = er.Current.Value;
                    cache.AddClip(channel.Clip);
                    channel.Reset();
                }
            }

            // 回收AudioChannel
            freeList.Add(channel);
            useList.Remove(channel);

            if (useList.Count + freeList.Count > _maxChannel && freeList.Count > 0)
            {
                GameObject obj = freeList[0].gameObject;
                freeList.RemoveAt(0);
                GameObject.Destroy(obj);
            }
        }

        toFreeList.Clear();
    }

    ///// <summary>
    ///// 使用范例
    ///// </summary>
    //void OnGUI()
    //{
    //    GUIStyle style = new GUIStyle();
    //    style.fontSize = 40;

    //    GUI.Label(new Rect(100, 350, 100, 100), "音效使用范例");

    //    GUI.Label(new Rect(100, 400, 100, 100), useList.Count + "  " + freeList.Count, style);
    //    //if (GUI.Button(new Rect(100, 100, 100, 100), "PlayMusic"))
    //    //{
    //    //    ioo.audioManager.PlayBackMusic("standby_sound");
    //    //}

    //    //if (GUI.Button(new Rect(100, 200, 100, 100), "StopMusic"))
    //    //{
    //    //    ioo.audioManager.StopBackMusic("standby_sound");
    //    //}

    //    //if (GUI.Button(new Rect(100, 300, 100, 100), "PlaySound"))
    //    //{
    //    //    ioo.audioManager.PlaySound2D("insert_coin_sound");
    //    //}
    //}
}

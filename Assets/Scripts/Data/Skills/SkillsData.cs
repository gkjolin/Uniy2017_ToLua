/**
* 	Copyright (广州纷享游艺设备有限公司-研发视频组) 2015 Need co.,Ltd
*	All rights reserved

*    文件名称:    SkillsData.cs
*    创建标志:    
*    简    介:    技能ID
*/
using System;
using System.Collections.Generic; 
using LitJson; 
    public partial class SkillsData 
    {
        protected static SkillsData instance;
        protected Dictionary<int,SkillsPO> m_dictionary;

        public static SkillsData Instance
        {
            get{
                if(instance == null)
                {
                    instance = new SkillsData();
                }
                return instance;
            }
        }

        protected SkillsData()
        {
            m_dictionary = new Dictionary<int,SkillsPO>();
        }

        public SkillsPO GetSkillsPO(int key)
        {
            if(m_dictionary.ContainsKey(key) == false)
            {
                return null;
            }
            return m_dictionary[key];
        }

        static public void LoadHandler(LoadedData data)
        {
            JsonData jsonData = JsonMapper.ToObject(data.Value.ToString());
            if (!jsonData.IsArray)
            {
                return;
            }
            for (int index = 0; index < jsonData.Count; index++)
            {
                JsonData element = jsonData[index];
                SkillsPO po = new SkillsPO(element);
                SkillsData.Instance.m_dictionary.Add(po.Id, po);
            }
        }
    }

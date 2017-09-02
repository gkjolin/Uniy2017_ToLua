/**
* 	Copyright (广州纷享游艺设备有限公司-研发视频组) 2015 Need co.,Ltd
*	All rights reserved

*    文件名称:    AgentData.cs
*    创建标志:    
*    简    介:    怪物ID
*/
using System;
using System.Collections.Generic; 
using LitJson; 
    public partial class AgentData 
    {
        protected static AgentData instance;
        protected Dictionary<int,AgentPO> m_dictionary;

        public static AgentData Instance
        {
            get{
                if(instance == null)
                {
                    instance = new AgentData();
                }
                return instance;
            }
        }

        protected AgentData()
        {
            m_dictionary = new Dictionary<int,AgentPO>();
        }

        public AgentPO GetAgentPO(int key)
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
                AgentPO po = new AgentPO(element);
                AgentData.Instance.m_dictionary.Add(po.Id, po);
            }
        }
    }

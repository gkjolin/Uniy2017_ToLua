/**
*    Copyright (广州纷享游艺设备有限公司-研发视频组) 2015 Need co.,Ltd
*    All rights reserved

*    文件名称:    SkillsPO.cs
*    创建标识:    
*    简    介:    技能ID
*/
using System;
using System.Collections.Generic; 
using System.Text;
using LitJson; 
    public partial class SkillsPO 
    {
        protected int m_Id;
        protected int m_Index;
        protected string m_SkillName;
        protected string m_Desc;
        protected int m_SkillType;
        protected float m_CoolTime;
        protected float[] m_HurtValue;
        protected int[] m_CallID;
        protected int[] m_CallCount;
        protected int m_BuffID;

        public SkillsPO(JsonData jsonNode)
        {
            m_Id = (int)jsonNode["Id"];
            m_Index = (int)jsonNode["Index"];
            m_SkillName = jsonNode["SkillName"].ToString() == "NULL" ? "" : jsonNode["SkillName"].ToString();
            m_Desc = jsonNode["Desc"].ToString() == "NULL" ? "" : jsonNode["Desc"].ToString();
            m_SkillType = (int)jsonNode["SkillType"];
            m_CoolTime = (float)(double)jsonNode["CoolTime"];
            {
                JsonData array = jsonNode["HurtValue"];
                m_HurtValue = new float[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_HurtValue[index] = (float)(double)array[index];
                }
            }
            {
                JsonData array = jsonNode["CallID"];
                m_CallID = new int[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_CallID[index] = (int)array[index];
                }
            }
            {
                JsonData array = jsonNode["CallCount"];
                m_CallCount = new int[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_CallCount[index] = (int)array[index];
                }
            }
            m_BuffID = (int)jsonNode["BuffID"];
        }

        public int Id
        {
            get
            {
                return m_Id;
            }
        }

        public int Index
        {
            get
            {
                return m_Index;
            }
        }

        public string SkillName
        {
            get
            {
                return m_SkillName;
            }
        }

        public string Desc
        {
            get
            {
                return m_Desc;
            }
        }

        public int SkillType
        {
            get
            {
                return m_SkillType;
            }
        }

        public float CoolTime
        {
            get
            {
                return m_CoolTime;
            }
        }

        public float[] HurtValue
        {
            get
            {
                return m_HurtValue;
            }
        }

        public int[] CallID
        {
            get
            {
                return m_CallID;
            }
        }

        public int[] CallCount
        {
            get
            {
                return m_CallCount;
            }
        }

        public int BuffID
        {
            get
            {
                return m_BuffID;
            }
        }

    }


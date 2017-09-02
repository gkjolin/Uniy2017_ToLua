/**
*    Copyright (广州纷享游艺设备有限公司-研发视频组) 2015 Need co.,Ltd
*    All rights reserved

*    文件名称:    AgentPO.cs
*    创建标识:    
*    简    介:    怪物ID
*/
using System;
using System.Collections.Generic; 
using System.Text;
using LitJson; 
    public partial class AgentPO 
    {
        protected int m_Id;
        protected int m_Index;
        protected string m_Name;
        protected string m_Desc;
        protected int m_Type;
        protected float m_Speed;
        protected float[] m_MoveOrProRate;
        protected int m_Score;
        protected int m_Health;
        protected int[] m_Skills;
        protected string[] m_Effect;
        protected string[] m_HitEffect;
        protected string[] m_DieEffet;

        public AgentPO(JsonData jsonNode)
        {
            m_Id = (int)jsonNode["Id"];
            m_Index = (int)jsonNode["Index"];
            m_Name = jsonNode["Name"].ToString() == "NULL" ? "" : jsonNode["Name"].ToString();
            m_Desc = jsonNode["Desc"].ToString() == "NULL" ? "" : jsonNode["Desc"].ToString();
            m_Type = (int)jsonNode["Type"];
            m_Speed = (float)(double)jsonNode["Speed"];
            {
                JsonData array = jsonNode["MoveOrProRate"];
                m_MoveOrProRate = new float[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_MoveOrProRate[index] = (float)(double)array[index];
                }
            }
            m_Score = (int)jsonNode["Score"];
            m_Health = (int)jsonNode["Health"];
            {
                JsonData array = jsonNode["Skills"];
                m_Skills = new int[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_Skills[index] = (int)array[index];
                }
            }
            {
                JsonData array = jsonNode["Effect"];
                m_Effect = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_Effect[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["HitEffect"];
                m_HitEffect = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_HitEffect[index] = array[index].ToString();
                }
            }
            {
                JsonData array = jsonNode["DieEffet"];
                m_DieEffet = new string[array.Count];
                for (int index = 0; index < array.Count; index++)
                {
                    m_DieEffet[index] = array[index].ToString();
                }
            }
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

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public string Desc
        {
            get
            {
                return m_Desc;
            }
        }

        public int Type
        {
            get
            {
                return m_Type;
            }
        }

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        public float[] MoveOrProRate
        {
            get
            {
                return m_MoveOrProRate;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        public int Health
        {
            get
            {
                return m_Health;
            }
        }

        public int[] Skills
        {
            get
            {
                return m_Skills;
            }
        }

        public string[] Effect
        {
            get
            {
                return m_Effect;
            }
        }

        public string[] HitEffect
        {
            get
            {
                return m_HitEffect;
            }
        }

        public string[] DieEffet
        {
            get
            {
                return m_DieEffet;
            }
        }

    }


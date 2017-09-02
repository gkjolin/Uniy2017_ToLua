﻿using UnityEngine;
using System.Collections;
using System.IO;

public class LoadedData {
    public LoadedData(object value, string filePath, string originalUrl)
    {
        this.Value = value;
        this.FilePath = filePath;
        this.OriginalUrl = originalUrl;
    }
    /// <summary>
    /// 需要下载的文件完整地址;
    /// </summary>
    public string FilePath
    {
        get;
        private set;
    }
    /// <summary>
    /// 请求下载的文件原始地址;
    /// </summary>
    public string OriginalUrl
    {
        get;
        private set;
    }
    public object Value
    {
        get;
        private set;
    }
    private string _fileName = string.Empty;

    public string FileName
    {
        get
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                _fileName = Path.GetFileNameWithoutExtension(this.FilePath);
            }
            return _fileName;
        }
    }
    
}
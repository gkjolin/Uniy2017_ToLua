using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ResourceMisc
{

    //---------------------------------------
    // bundle ref wrapper
    public class BundleWrapper
    {
        string _path;
        AssetBundle _bundle;
        Dictionary<string, int> _refAssets = new Dictionary<string, int>();

        public BundleWrapper(string path, AssetBundle bundle)
        {
            //if (path.Contains("-effects-"))
            //{
            //    Debug.Log("Load AssetBundle:" + path);
            //}
            _path = path;
            _bundle = bundle;
            _refAssets.Clear();
        }

        public void AddRefAsset(string assetKey)
        {
            if (!_refAssets.ContainsKey(assetKey))
            {
                _refAssets.Add(assetKey, 1);
            }
            else
            {
                _refAssets[assetKey] += 1;
            }
        }

        public void DecRefAsset(string assetKey)
        {
            if (_refAssets.ContainsKey(assetKey))
            {
                _refAssets[assetKey] -= 1;
                if(_refAssets[assetKey] == 0)
                    _refAssets.Remove(assetKey);
            }
        }

        public int GetRefAssetCount()
        {
            return _refAssets.Count;
        }

        public AssetBundle GetBundle()
        {
            return _bundle;
        }

        public string GetPath()
        {
            return _path;
        }
    }
    //---------------------------------------
    // asset ref wrapper
    public class AssetWrapper
    {
        int _ref_count;

        Object _asset;
        string _path;
        System.Type _assetType;
        string _bundle_name;

        //����Դ������������bundle������;
        string [] m_dps;
        
        bool _is_scene;



        public AssetWrapper(Object asset, string path, System.Type assetType, string bundle_name, bool is_scene)
        {
            if(asset != null)
            {
                GameObject temp = asset as GameObject;
                if (temp != null)
                {
                    //ProjectileBase.excuteShader(temp);
                    ResourceManager.excuteShader(temp);
                }
            }

            _ref_count = 1;

            _asset = asset;
            _path = path;
            _assetType = assetType;
            _bundle_name = bundle_name;
            _is_scene = is_scene;
        }

        //��¼Asset���ڵ���Դbundle���ƣ�������Դ���ͷ� Lorry 2015/9/25
        public void SetDps(string[] parDps)
        {
            m_dps = parDps;
        }
        public string[] GetDps()
        {
            return m_dps;
        }

        public void AddRef()
        {
            ++_ref_count;
        }

        public void Release()
        {
            if (_ref_count > 0)
                --_ref_count;
        }

        public int GetRefCount()
        {
            return _ref_count;
        }

        public Object GetAsset()
        {
            return _asset;
        }

        public string GetAssetPath()
        {
            return _path;
        }

        public string GetAssetType()
        {
            return _assetType.ToString();
        }

        public string GetBundleName()
        {
            return _bundle_name;
        }

        public bool IsScene()
        {
            return _is_scene;
        }
    }

}
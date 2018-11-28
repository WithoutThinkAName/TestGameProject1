using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// Resources文件夹资源加载工厂
/// 代理模式修改版
/// 避免重复加载测试
/// </summary>
public class ResourcesAssetProxyFactory:IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> mSoundClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();
   


    public GameObject LoadSoldier(string name)
    {
        if (mSoldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldiers[name]);
        } else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
            mSoldiers.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnemys.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnemys[name]);
        } else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EnemyPath + name) as GameObject;
            mEnemys.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeapons.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeapons[name]);
        } else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.WeaponPath + name) as GameObject;
            mWeapons.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadEffect(string name)
    {
        if (mEffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffects[name]);
        } else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
            mEffects.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
        {
            return mAudioClips[name];
        } else
        {
            AudioClip audio = mAssetFactory.LoadAudioClip(name);
            mAudioClips.Add(name, audio);
            return audio;
        }
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
        {
            return mSprites[name];
        } else
        {
            Sprite sprite = mAssetFactory.LoadSprite(name);
            mSprites.Add(name, sprite);
            return sprite;
        }
    }

   
    public Dictionary<UIPanelType, string> ParseUIPanelTypeJson()
    {
        return mAssetFactory.ParseUIPanelTypeJson();
    }

    public AudioClip LoadSoundClip(string name)
    {
        if (mSoundClips.ContainsKey(name))
        {
            return mSoundClips[name];
        }
        else
        {
            AudioClip audio = mAssetFactory.LoadSoundClip(name);
            mSoundClips.Add(name, audio);
            return audio;
        }
    }
}

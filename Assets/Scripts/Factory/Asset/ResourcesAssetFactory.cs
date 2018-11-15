using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// Resources文件夹资源加载工厂
/// </summary>
public class ResourcesAssetFactory : IAssetFactory
{
    //资源路径
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";

    /// <summary>
    /// 声音加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
    }
    /// <summary>
    /// 特效加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }
    /// <summary>
    /// 敌人游戏物体加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }
    /// <summary>
    /// 士兵游戏物体加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }
    /// <summary>
    /// 图片资源加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath+name,typeof(Sprite))as Sprite;
    }
    /// <summary>
    /// 武器游戏物体加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }
    /// <summary>
    /// 游戏物体加载并克隆
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o==null)
        {
            Debug.Log("无法加载路径：" + path);
            return null;
        }
        return GameObject.Instantiate(o) as GameObject;

    }
    /// <summary>
    /// 物体对象加载
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o==null)
        {
            Debug.Log("无法加载路径：" + path);
            return null;
        }
        return o;
    }

}


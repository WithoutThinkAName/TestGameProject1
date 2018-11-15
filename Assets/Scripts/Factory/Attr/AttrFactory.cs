using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 属性工厂
/// </summary>
public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mcharacterBaseAttrDict;//人物属性字典
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict;//武器属性字典

    /// <summary>
    /// 初始化
    /// </summary>
    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }
    /// <summary>
    /// 人物角色默认共有属性初始化设置
    /// </summary>
    private void InitCharacterBaseAttr()
    {
        mcharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
        //士兵
        mcharacterBaseAttrDict.Add(typeof(SoldierRookie), new CharacterBaseAttr("新兵", 80, 2, "RookieIcon", "Soldier2", 0));
        mcharacterBaseAttrDict.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士", 90, 3, "SergeantIcon", "Soldier3", 0));
        mcharacterBaseAttrDict.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉", 100, 4, "CaptainIcon", "Soldier1", 0));
        //敌人
        mcharacterBaseAttrDict.Add(typeof(EnemyElf), new CharacterBaseAttr("精灵", 100, 3, "ElfIcon", "Enemy1", 0.2f));
        mcharacterBaseAttrDict.Add(typeof(EnemyOgre), new CharacterBaseAttr("怪物", 120, 2, "OgreIcon", "Enemy2", 0.3f));
        mcharacterBaseAttrDict.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 200, 1, "TrollIcon", "Enemy3", 0.4f));
     }
    /// <summary>
    /// 武器默认共有属性初始化设置
    /// </summary>
    private void InitWeaponBaseAttr()
    {
        mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();

        mWeaponBaseAttrDict.Add(WeaponType.Gun, new WeaponBaseAttr("手枪", 20, 5, "WeaponGun"));
        mWeaponBaseAttrDict.Add(WeaponType.Rifle, new WeaponBaseAttr("长枪", 30, 5, "WeaponRifle"));
        mWeaponBaseAttrDict.Add(WeaponType.Rocket, new WeaponBaseAttr("火箭", 40, 5, "WeaponRocket"));
        
    }
    /// <summary>
    /// 获取人物默认属性
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (mcharacterBaseAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据[" + t + "]类型获得人物属性");
            return null;
        }
        return mcharacterBaseAttrDict[t];
    }
    /// <summary>
    /// 获取武器默认属性
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType t)
    {
        //Debug.Log(t);
        //Debug.Log(mWeaponBaseAttrDict.Count);
        if (mWeaponBaseAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据[" + t + "]类型获得武器属性");
            return null;
        }
        return mWeaponBaseAttrDict[t];
    }
}


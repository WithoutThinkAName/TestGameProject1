using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 工厂总管理类
/// </summary>
public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;//资源工厂
    private static ICharacterFactory mSoldierFactory = null;//士兵人物工厂
    private static ICharacterFactory mEnemyFactory = null;//敌人人物工厂
    private static IWeaponFactory mWeaponFactory = null;//武器工厂
    private static IAttrFactory mAttrFactory = null;//属性工厂

    /// <summary>
    /// 初始化并获取属性工厂
    /// </summary>
    public static IAttrFactory attrFactory
    {
        get
        {
            if (mAttrFactory==null)
            {
                mAttrFactory = new AttrFactory();                
            }
            return mAttrFactory;
        }
    }
    /// <summary>
    /// 初始化并获取资源工厂
    /// </summary>
    public static IAssetFactory assetFactory
    {
        get
        {
            if (mAssetFactory==null)
            {
                //mAssetFactory = new ResourcesAssetFactory();
                mAssetFactory = new ResourcesAssetProxyFactory();
            }
            return mAssetFactory;
        }
    }
    /// <summary>
    /// 初始化并获取士兵工厂
    /// </summary>
    public static ICharacterFactory soldierFactory
    {
        get
        {
            if (mSoldierFactory==null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }
    /// <summary>
    /// 初始化并获取敌人工厂
    /// </summary>
    public static ICharacterFactory enemyFactory
    {
        get
        {
            if (mEnemyFactory==null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }
    /// <summary>
    /// 初始化并获取武器工厂
    /// </summary>
    public static IWeaponFactory weaponFactory
    {
        get
        {
            if (mWeaponFactory==null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }
}


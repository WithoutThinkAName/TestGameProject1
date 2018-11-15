using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 武器基础属性类
/// </summary>
public class WeaponBaseAttr
{
    protected string mName;//武器名称
    protected int mAtk;//武器攻击力
    protected float mAtkRange;//武器攻击范围
    protected string mAssetName;//资源名称

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="atk">攻击力</param>
    /// <param name="atkRange">攻击范围</param>
    /// <param name="assetName">资源名称</param>
    public WeaponBaseAttr(string name,int atk,float atkRange,string assetName)
    {
        mName = name;
        mAtk = atk;
        mAtkRange = atkRange;
        mAssetName = assetName;
    }
    /// <summary>
    /// 获取武器名称
    /// </summary>
    public string name { get { return mName; } }
    /// <summary>
    /// 获取武器攻击力
    /// </summary>
    public int atk { get { return mAtk; } }
    /// <summary>
    /// 获取武器攻击范围
    /// </summary>
    public float atkRange { get { return mAtkRange; } }
    /// <summary>
    /// 获取资源名称
    /// </summary>
    public string assetName { get { return mAssetName; } }
}


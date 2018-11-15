using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 默认人物角色公用共有基础属性类
/// </summary>
public class CharacterBaseAttr
{
    protected string mName;//名称
    protected int mMaxHP;//默认最大HP
    protected float mMoveSpeed;//默认移动速度
    protected string mIconSprite;//默认图标
    protected string mPrefabName;//预制体名称
    protected float mCritRate;//0-1暴击率
    /// <summary>
    /// 初始化人物属性构造
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="maxHp">默认最大HP</param>
    /// <param name="moveSpeed">默认移动速度</param>
    /// <param name="IconSprite">默认图标</param>
    /// <param name="prefabName">预制体名称</param>
    /// <param name="critRate">暴击率</param>
    public CharacterBaseAttr(string name,int maxHp,float moveSpeed,string IconSprite,string prefabName,float critRate)
    {
        mName = name;
        mMaxHP = maxHp;
        mMoveSpeed = moveSpeed;
        mIconSprite = IconSprite;
        mPrefabName = prefabName;
        mCritRate = critRate;
    }
    /// <summary>
    /// 获取名称
    /// </summary>
    public string name { get { return mName; } }
    /// <summary>
    /// 获取生命值
    /// </summary>
    public int maxHp { get { return mMaxHP; } }
    /// <summary>
    /// 获取移动速度
    /// </summary>
    public float moveSpeed { get { return mMoveSpeed; } }
    /// <summary>
    /// 获取图标
    /// </summary>
    public string iconSprite { get { return mIconSprite; } }
    /// <summary>
    /// 获取预制体名称
    /// </summary>
    public string prefabName { get { return mPrefabName; } }
    /// <summary>
    /// 获取暴击率
    /// </summary>
    public float critRate { get { return mCritRate; } }

}
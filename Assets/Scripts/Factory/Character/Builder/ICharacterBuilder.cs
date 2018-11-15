using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 人物建造者基础类
/// </summary>
public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;//人物角色对象
    protected Type mT;//人物类型
    protected WeaponType mWeaponType;//武器类型
    protected Vector3 mSpawnPosition;//人物生成位置
    protected int mLv;//人物等级

    protected string mPerfabName = "";//游戏物体路径名称
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="character">人物角色对象</param>
    /// <param name="t">人物类型</param>
    /// <param name="weaponType">武器类型</param>
    /// <param name="spawnPosition">生产位置</param>
    /// <param name="lv">等级</param>
    public ICharacterBuilder(ICharacter character, Type t,WeaponType weaponType,Vector3 spawnPosition,int lv)
    {
        mCharacter = character;
        mT = t;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPosition;
        mLv = lv;

    }
    /// <summary>
    /// 人物角色创建流程
    /// </summary>
    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract void AddIncharacterSystem();
    public abstract ICharacter GetResult();
}


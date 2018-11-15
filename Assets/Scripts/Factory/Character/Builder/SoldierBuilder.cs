using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵建造者类
/// </summary>
public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }
    /// <summary>
    /// 加载士兵人物属性
    /// </summary>
    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mT);
        mPerfabName = baseAttr.prefabName;
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv,baseAttr);
        mCharacter.attr = attr;
    }
    /// <summary>
    /// 创建士兵人物游戏物体
    /// </summary>
    public override void AddGameObject()
    {
        //创建实例物体
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(mPerfabName);
        characterGO.transform.position = mSpawnPosition;

        characterGO.AddComponent<SoldierOnClick>().soldier = mCharacter as ISoldier;

        characterGO.AddComponent<CharacterHPSlider>();

        mCharacter.gameObject = characterGO;
    }
    /// <summary>
    /// 将士兵人物游戏物体加入人物系统管理
    /// </summary>
    public override void AddIncharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);        
    }
    /// <summary>
    /// 创建士兵武器游戏对象
    /// </summary>
    public override void AddWeapon()
    {
        //创建武器物体
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }
    /// <summary>
    /// 返还建造完毕的士兵对象
    /// </summary>
    /// <returns></returns>
    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人建造者类
/// </summary>
public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }
    /// <summary>
    /// 加载敌人人物属性
    /// </summary>
    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mT);
        mPerfabName = baseAttr.prefabName;
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), mLv, baseAttr);
        mCharacter.attr = attr;
    }
    /// <summary>
    /// 创建敌人人物游戏物体
    /// </summary>
    public override void AddGameObject()
    {
        //创建实例物体
        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(mPerfabName);
        characterGO.transform.position = mSpawnPosition;

        characterGO.AddComponent<CharacterHPSlider>();

        mCharacter.gameObject = characterGO;
    }
    /// <summary>
    /// 将敌人人物游戏物体加入人物系统管理
    /// </summary>
    public override void AddIncharacterSystem()
    {
        GameMode1Facade.Instance.AddEnemy(mCharacter as IEnemy);
    }
    /// <summary>
    /// 创建敌人武器
    /// </summary>
    public override void AddWeapon()
    {
        //创建武器游戏物体
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }
    /// <summary>
    /// 返还建造完毕的敌人人物
    /// </summary>
    /// <returns></returns>
    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}


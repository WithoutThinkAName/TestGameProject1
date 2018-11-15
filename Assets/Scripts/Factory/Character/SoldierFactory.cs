using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵工厂
/// </summary>
public class SoldierFactory : ICharacterFactory
{
    /// <summary>
    /// 通过建造者创建一个士兵对象
    /// </summary>
    /// <typeparam name="T">士兵类型</typeparam>
    /// <param name="weaponType">武器类型</param>
    /// <param name="spawnPosition">生产位置</param>
    /// <param name="lv">等级</param>
    /// <returns></returns>
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        ICharacterBuilder builder = new SoldierBuilder(character, typeof(T), weaponType, spawnPosition, lv);

        return CharacterBuilderDirector.Construct(builder);
        
        
    }
}


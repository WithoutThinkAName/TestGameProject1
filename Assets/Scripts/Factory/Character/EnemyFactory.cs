using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人工厂
/// </summary>
public class EnemyFactory : ICharacterFactory
{
    /// <summary>
    /// 通过建造者创建一个敌人对象
    /// </summary>
    /// <typeparam name="T">敌人类型</typeparam>
    /// <param name="weaponType">武器类型</param>
    /// <param name="spawnPosition">生产位置</param>
    /// <param name="lv">等级</param>
    /// <returns></returns>
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        ICharacterBuilder builder = new EnemyBuilder(character, typeof(T), weaponType, spawnPosition, lv);

        return CharacterBuilderDirector.Construct(builder);
        
    }
}


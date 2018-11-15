using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 人物角色工厂接口
/// </summary>
public interface ICharacterFactory
{
    ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)where T:ICharacter,new();
}


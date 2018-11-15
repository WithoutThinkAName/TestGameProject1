using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 属性工厂接口
/// </summary>
public interface IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(Type t);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType t);
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 武器工厂接口
/// </summary>
public interface IWeaponFactory
{
    IWeapon CreateWeapon(WeaponType weaponType);
}


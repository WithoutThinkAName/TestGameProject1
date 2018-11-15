using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 武器工厂
/// </summary>
public class WeaponFactory : IWeaponFactory
{
    /// <summary>
    /// 创建武器对象
    /// </summary>
    /// <param name="weaponType">武器类型</param>
    /// <returns>返还武器对象</returns>
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        WeaponBaseAttr baseAttr = FactoryManager.attrFactory.GetWeaponBaseAttr(weaponType);
        
        GameObject weaponGO = FactoryManager.assetFactory.LoadWeapon(baseAttr.assetName);

        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(baseAttr, weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(baseAttr, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(baseAttr, weaponGO);
                break;
            default:
                break;
        }

        return weapon;
    }
}


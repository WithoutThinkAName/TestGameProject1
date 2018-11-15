using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 能量需求的计算与外部获取
/// </summary>
public class SoldierEnergyCostStrategy : IEnergyCountStrategy
{
    /// <summary>
    /// 计算并获取当前兵营升级需要的能量
    /// </summary>
    /// <param name="st">士兵类型</param>
    /// <param name="lv">当前等级</param>
    /// <returns></returns>
    public override int GetCampUpgradeCount(SoldierType st,int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Captain:
                energy = 65;
                break;
            case SoldierType.Sergeant:
                energy = 70;
                break;
            default:
                break;
        }
        energy += (lv - 1) * 2;
        if (energy > 100) energy = 100;
        return energy;
    }
    /// <summary>
    /// 计算并获取当前士兵训练所需能量
    /// </summary>
    /// <param name="st">士兵类型</param>
    /// <param name="lv">士兵等级</param>
    /// <returns></returns>
    public override int GetSoldierTrainCost(SoldierType st,int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Captain:
                energy = 15;
                break;
            case SoldierType.Sergeant:
                energy = 20;
                break;
            default:
                break;
        }
        energy += (lv - 1) * 2;
        return energy;
    }
    /// <summary>
    /// 计算并获取当前武器升级需要能量
    /// </summary>
    /// <param name="wt"></param>
    /// <returns></returns>
    public override int GetWeaponUpgradeCost(WeaponType wt)
    {
        int energy = 0;
        switch (wt)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
            default:
                break;
        }
        return energy;
    }
}


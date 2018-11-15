using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 动态获取当前消耗
/// </summary>
public abstract class IEnergyCountStrategy
{
    public abstract int GetCampUpgradeCount(SoldierType st,int lv);
    public abstract int GetWeaponUpgradeCost(WeaponType wt);
    public abstract int GetSoldierTrainCost(SoldierType st,int lv);
}


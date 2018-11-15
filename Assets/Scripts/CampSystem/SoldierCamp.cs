using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵兵营类
/// </summary>
public class SoldierCamp:ICamp
{
    private const int MAX_LV = 4;//兵营可升级最大等级
    private int mLv = 1;//兵营当前等级
    private WeaponType mWeaponType = WeaponType.Gun;//当前武器

    /// <summary>
    /// 士兵兵营初始化构造
    /// </summary>
    /// <param name="gameObject">兵营游戏对象</param>
    /// <param name="name">兵营名称</param>
    /// <param name="icon">兵营显示图标</param>
    /// <param name="soldierType">生产士兵类型</param>
    /// <param name="position">生成点</param>
    /// <param name="trainTime">单个士兵训练时间</param>
    /// <param name="weaponType">武器类型</param>
    /// <param name="lv">士兵等级</param>
    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position,float trainTime,WeaponType weaponType=WeaponType.Gun,int lv=1) : base(gameObject, name, icon, soldierType, position, trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();

        UpdateEnergyCost();
    }
    /// <summary>
    /// 获取当前兵营升级能量
    /// </summary>
    public override int energyCostCampUpgrade
    {
        get
        {
            if (mLv==MAX_LV)
            {
                return -1;
            }
            else
            {
                return mEnergyCostCampUpgrade;
            }
        }
    }
    /// <summary>
    /// 获取当前士兵训练能量
    /// </summary>
    public override int energyCostTrain
    {
        get
        {
            return mEnergyCostTrain;
        }
    }
    /// <summary>
    /// 获取当前武器升级能量
    /// </summary>
    public override int energyCostWeaponUpgrade
    {
        get
        {
            if (mWeaponType+1==WeaponType.Max)
            {
                return -1;
            }
            else
            {
                return mEnergyCostWeaponUpgrade;
            }
        }
    }
    /// <summary>
    /// 获取当前等级
    /// </summary>
    public override int lv { get { return mLv; } }
    /// <summary>
    /// 获取当前武器类型
    /// </summary>
    public override WeaponType weaponType { get { return mWeaponType; } }
    /// <summary>
    /// 点击兵营游戏物体显示兵营信息UI面板
    /// </summary>
    public override void ShowCampInfo()
    {
        mCampOnClick.ShowCampInfo();
    }
    /// <summary>
    /// 训练士兵命令添加
    /// </summary>
    public override void Train()
    {
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType,mWeaponType,mPosition,mLv);
        mCommands.Add(cmd);
    }
    /// <summary>
    /// 升级兵营并重新计算升级能量
    /// </summary>
    public override void UpgradeCamp()
    {
        mLv++;
        UpdateEnergyCost();
    }
    /// <summary>
    /// 升级武器并重新计算升级能量
    /// </summary>
    public override void UpgradeWeapon()
    {
        mWeaponType = mWeaponType + 1;
        UpdateEnergyCost();
    }
    /// <summary>
    /// 重新计算所有能量消耗值
    /// </summary>
    protected override void UpdateEnergyCost()
    {
        mEnergyCostCampUpgrade = mEnergyCostStrategy.GetCampUpgradeCount(mSoldierType,mLv);
        mEnergyCostWeaponUpgrade = mEnergyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, mLv);

    }
}


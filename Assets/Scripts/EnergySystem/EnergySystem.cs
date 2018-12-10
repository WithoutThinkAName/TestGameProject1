using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 能量系统类
/// </summary>
public class EnergySystem : IGameSystem
{
    private const int Max_Energy=100;//能量最大值

    private float mNowEnergy= Max_Energy;//当前能量值
    private float mRecoverSpeed = 3;//能量恢复速率

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();       
    }
    /// <summary>
    /// 每帧执行，能量计算
    /// </summary>
    public override void Update()
    {
        base.Update();

        mMode1Facade.UpgradeEnergySlider((int)mNowEnergy, Max_Energy);

        if (mNowEnergy >= Max_Energy) return;

        mNowEnergy += mRecoverSpeed * Time.deltaTime;

        mNowEnergy = Mathf.Min(mNowEnergy, Max_Energy);

        mMode1Facade.UpgradeEnergySlider((int)mNowEnergy, Max_Energy);
    }
    /// <summary>
    /// 消耗能量
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool TakeEnergy(int value)
    {
        if (mNowEnergy>=value)
        {
            mNowEnergy -= value;
            return true;
        }
        return false;
    }
    /// <summary>
    /// 能量返还
    /// 如：
    /// 训练取消
    /// </summary>
    /// <param name="value"></param>
    public void RecycleEnergy(int value)
    {
        mNowEnergy += value;
        mNowEnergy = Mathf.Min(mNowEnergy, Max_Energy);
    }
}


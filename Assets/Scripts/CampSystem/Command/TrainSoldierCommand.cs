using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 创建士兵命令实现类
/// </summary>
public class TrainSoldierCommand : ITrainCommand
{
    private SoldierType mSoldierType; //士兵类型
    private WeaponType mWeaponType; //武器类型
    private Vector3 mPosition; //创建位置
    private int mLv; //士兵等级

    /// <summary>
    /// 创建士兵命令构造方法
    /// </summary>
    /// <param name="st">士兵类型</param>
    /// <param name="wt">武器类型</param>
    /// <param name="pos">创建生成位置</param>
    /// <param name="lv">等级值</param>
    public TrainSoldierCommand(SoldierType st,WeaponType wt,Vector3 pos,int lv)
    {
        mSoldierType = st;
        mWeaponType = wt;
        mPosition = pos;
        mLv = lv;
    }

    /// <summary>
    /// 根据数据调用工厂类创建士兵实体
    /// </summary>
    public override void Execute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreateCharacter<SoldierRookie>(mWeaponType, mPosition, mLv);
                break;
            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mPosition, mLv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mPosition, mLv);
                break;
            default:
                Debug.LogError("Error:找不到士兵类型["+ mSoldierType + "]");
                break;
        }
    }
}


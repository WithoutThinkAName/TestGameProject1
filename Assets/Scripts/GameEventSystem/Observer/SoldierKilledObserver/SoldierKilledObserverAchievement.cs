using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者：士兵死亡
/// </summary>
public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem mArchSystem;//成就系统

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="archSystem"></param>
    public SoldierKilledObserverAchievement(AchievementSystem archSystem)
    {
        mArchSystem = archSystem;
    }
    /// <summary>
    /// 观察者数据更新
    /// </summary>
    public override void OBUpdate()
    {
        mArchSystem.AddSoldierKillledCount();
    }

    public override void SetSubject(IGameEventSubject sub)
    {
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者：成就敌人击杀数
/// </summary>
public class EnemyKlledObserverAchievement : IGameEventObserver
{    
    private AchievementSystem mArchSystem;//成就系统

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="archSystem"></param>
    public EnemyKlledObserverAchievement(AchievementSystem archSystem)
    {
        mArchSystem = archSystem;
    }
    /// <summary>
    /// 观察者数据更新
    /// </summary>
    public override void OBUpdate()
    {
        mArchSystem.AddEnemyKillledCount();
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        
    }
}


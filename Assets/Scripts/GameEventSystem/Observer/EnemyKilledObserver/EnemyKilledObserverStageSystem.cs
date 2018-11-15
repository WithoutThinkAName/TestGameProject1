using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者：关卡敌人击杀数
/// </summary>
public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;//敌人击杀数主题
    private StageSystem mStageSystem;//关卡系统

    /// <summary>
    /// 初始化关卡系统
    /// </summary>
    /// <param name="ss"></param>
    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }

    /// <summary>
    /// 观察者数据更新
    /// </summary>
    public override void OBUpdate()
    {
        mStageSystem.countOfEnemyKilled = mSubject.killedCount;
    }
    /// <summary>
    /// 设置观察者观察主题：击杀数
    /// </summary>
    /// <param name="sub"></param>
    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;
    }
}


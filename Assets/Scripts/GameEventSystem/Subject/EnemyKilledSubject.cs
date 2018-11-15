using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察主题：敌人击杀数
/// </summary>
public class EnemyKilledSubject:IGameEventSubject
{
    private int mKilledCount = 0;//敌人击杀数
    /// <summary>
    /// 获取当前敌人击杀数
    /// </summary>
    public int killedCount { get { return mKilledCount; } }

    /// <summary>
    /// 更新该主题观察者击杀数据
    /// </summary>
    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}


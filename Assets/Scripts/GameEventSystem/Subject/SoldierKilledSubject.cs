using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察主题：士兵死亡数
/// </summary>
public class SoldierKilledSubject:IGameEventSubject
{
    private int mKilledCount = 0;//士兵死亡数
    /// <summary>
    /// 获取士兵死亡数
    /// </summary>
    public int killedCount { get { return mKilledCount; } }
    /// <summary>
    /// 更新该主题观察者士兵死亡数信息
    /// </summary>
    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}


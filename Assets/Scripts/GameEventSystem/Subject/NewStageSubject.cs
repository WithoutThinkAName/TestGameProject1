using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察主题：新关卡
/// </summary>
public class NewStageSubject:IGameEventSubject
{
    private int mStageCount = 1;//关卡数
    /// <summary>
    /// 获取关卡数
    /// </summary>
    public int stageCount { get { return mStageCount; } }

    /// <summary>
    /// 更新该主题观察者关卡数数据
    /// </summary>
    public override void Notify()
    {
        mStageCount++;
        base.Notify();
    }
}


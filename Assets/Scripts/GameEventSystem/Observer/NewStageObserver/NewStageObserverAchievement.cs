using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者：进入新关卡
/// </summary>
public class NewStageObserverAchievement : IGameEventObserver
{
    public NewStageSubject mSubject;//进入新关卡主题
    private AchievementSystem mArchSystem;//成就系统

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="archSystem"></param>
    public NewStageObserverAchievement(AchievementSystem archSystem)
    {
        mArchSystem = archSystem;
    }
    /// <summary>
    /// 观察者数据更新
    /// </summary>
    public override void OBUpdate()
    {
        mArchSystem.SetMaxStageLv(mSubject.stageCount);

    }
    /// <summary>
    /// 设置观察者主题：新关卡
    /// </summary>
    /// <param name="sub"></param>
    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;
    }
}


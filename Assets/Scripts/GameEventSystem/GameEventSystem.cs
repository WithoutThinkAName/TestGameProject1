using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 事件类型
/// </summary>
public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
    NewStage
}

/// <summary>
/// 游戏事件系统
/// </summary>
public class GameEventSystem : IGameSystem
{
    //游戏事件列表
    private Dictionary<GameEventType, IGameEventSubject> mGamneEvents = new Dictionary<GameEventType, IGameEventSubject>();

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();        
    }
    
    /// <summary>
    /// 为列表中事件主题注册观察者
    /// </summary>
    /// <param name="et"></param>
    /// <param name="observer"></param>
    public void RegisterObserver(GameEventType et,IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEventSub(et);
        if (sub == null) return;
        sub.RegisterObserver(observer);
        observer.SetSubject(sub);
        
    }
    /// <summary>
    /// 为列表中主题移除观察者
    /// </summary>
    /// <param name="et"></param>
    /// <param name="observer"></param>
    public void RemoveObserver(GameEventType et, IGameEventObserver observer)
    {

        IGameEventSubject sub = GetGameEventSub(et);
        if (sub == null) return;
        sub.RemoveObserver(observer);
        observer.SetSubject(null);
    } 
    /// <summary>
    /// 列表中根据事件类型查询观察主题
    /// </summary>
    /// <param name="et"></param>
    /// <returns></returns>
    private IGameEventSubject GetGameEventSub(GameEventType et)
    {
        if (mGamneEvents.ContainsKey(et) == false)
        {
            switch (et)
            {
                case GameEventType.EnemyKilled:
                    mGamneEvents.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                    mGamneEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.NewStage:
                    mGamneEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                default:
                    Debug.LogError("未找到主题类[" + et + "]");
                    return null;
            }
        }
        return mGamneEvents[et];
    }
    /// <summary>
    /// 更新观察主题数据
    /// </summary>
    /// <param name="et"></param>
    public void NotifySubject(GameEventType et)
    {
        IGameEventSubject sub = GetGameEventSub(et);
        if (sub == null) return;
        sub.Notify();
    }
}


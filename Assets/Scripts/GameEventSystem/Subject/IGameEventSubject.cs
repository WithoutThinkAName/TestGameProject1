using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者主题基础类
/// </summary>
public abstract class IGameEventSubject
{
    //该主题下的观察者列表
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();

    /// <summary>
    /// 注册新的观察者
    /// </summary>
    /// <param name="ob"></param>
    public void RegisterObserver(IGameEventObserver ob)
    {
        mObservers.Add(ob);
    }
    /// <summary>
    /// 移除现有观察者
    /// </summary>
    /// <param name="ob"></param>
    public void RemoveObserver(IGameEventObserver ob)
    {
        mObservers.Remove(ob);
    }
    /// <summary>
    /// 对该主题的观察者更新数据
    /// </summary>
    public virtual void Notify()
    {
        foreach (IGameEventObserver ob in mObservers)
        {
            ob.OBUpdate();
        }
    }


}


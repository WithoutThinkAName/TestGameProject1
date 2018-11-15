using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全部游戏系统基本类
/// </summary>
public abstract class IGameSystem
{
    protected GameFacade mFacade;//全系统中介者
    /// <summary>
    /// 系统初始化方法
    /// </summary>
    public virtual void Init()
    {
        mFacade = GameFacade.Instance;//中介者初始化
    }
    /// <summary>
    /// 系统每帧运行方法
    /// </summary>
    public virtual void Update() { }
    /// <summary>
    /// 系统释放方法
    /// </summary>
    public virtual void Release() { }
}

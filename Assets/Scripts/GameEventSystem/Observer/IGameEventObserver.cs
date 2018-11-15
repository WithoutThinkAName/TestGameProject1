using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察者基础类
/// </summary>
public abstract class IGameEventObserver
{
    /// <summary>
    /// 观察者数据更新
    /// </summary>
    public abstract void OBUpdate();
    /// <summary>
    /// 观察者，观察主题设置
    /// </summary>
    /// <param name="sub"></param>
    public abstract void SetSubject(IGameEventSubject sub);

}


using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Sergeant士兵类
/// </summary>
public class SoldierSergeant : ISoldier
{
    /// <summary>
    /// 显示特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffect("SergeantDeadEffect");
    }
    /// <summary>
    /// 显示音效
    /// </summary>
    protected override void PlaySound()
    {
        DoPlaySound("SergeantDead");
    }
}


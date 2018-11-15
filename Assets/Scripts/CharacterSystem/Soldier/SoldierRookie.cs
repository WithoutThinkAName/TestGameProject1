using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Rookie士兵类
/// </summary>
public class SoldierRookie : ISoldier
{
    /// <summary>
    /// 显示特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffect("RookieDeadEffect");
    }
    /// <summary>
    /// 显示音效
    /// </summary>
    protected override void PlaySound()
    {
        DoPlaySound("RookieDead");
    }
}


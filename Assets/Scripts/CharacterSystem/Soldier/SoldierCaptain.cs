using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Captain士兵类
/// </summary>
public class SoldierCaptain : ISoldier
{
    /// <summary>
    /// 显示特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }
    /// <summary>
    /// 显示音效
    /// </summary>
    protected override void PlaySound()
    {
        DoPlaySound("CaptainDead");
    }
}


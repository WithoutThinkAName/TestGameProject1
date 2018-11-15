using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Troll敌人类
/// </summary>
public class EnemyTroll : IEnemy
{
    /// <summary>
    /// 显示特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}


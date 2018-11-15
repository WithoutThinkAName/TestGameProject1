using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Ogre敌人类
/// </summary>
public class EnemyOgre : IEnemy
{
    /// <summary>
    /// 显示特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}


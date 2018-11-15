using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Elf敌人类
/// </summary>
public class EnemyElf : IEnemy
{
    /// <summary>
    ///显示特效
    /// </summary>
    protected override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}


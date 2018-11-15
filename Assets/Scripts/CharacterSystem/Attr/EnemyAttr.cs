using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 敌人属性
/// </summary>
public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr) : base(strategy, lv, baseAttr)
    {
    }
}


using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 士兵属性
/// </summary>
public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr) : base(strategy, lv, baseAttr)
    {
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//访问者模式测试
public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);

}


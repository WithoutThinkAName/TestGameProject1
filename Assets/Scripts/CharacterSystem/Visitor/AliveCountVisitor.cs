using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 访问者：场景中人物存活数量
/// </summary>
public class AliveCountVisitor : ICharacterVisitor
{
    public int enemyCount { get;private set; }//敌人存活数量
    public int soldierCount { get; private set; }//士兵存活数量

    /// <summary>
    /// 重置数量
    /// </summary>
    public void Reset()
    {
        enemyCount = 0;
        soldierCount = 0;
    }
    /// <summary>
    /// 访问敌人
    /// </summary>
    /// <param name="enemy"></param>
    public override void VisitEnemy(IEnemy enemy)
    {
        if (enemy.isKilled==false)
        {
            enemyCount += 1;
        }        
    }
    /// <summary>
    /// 访问士兵
    /// </summary>
    /// <param name="soldier"></param>
    public override void VisitSoldier(ISoldier soldier)
    {
        if (soldier.isKilled==false)
        {
            soldierCount += 1;
        }       
    }
}


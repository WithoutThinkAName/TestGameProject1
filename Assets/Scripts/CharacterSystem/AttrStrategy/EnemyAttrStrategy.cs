using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 敌人属性计算策略
/// </summary>
public class EnemyAttrStrategy : IAttrStrategy
{
   /// <summary>
   /// 敌人暴击伤害计算
   /// </summary>
   /// <param name="critRate">暴击率</param>
   /// <returns>伤害值</returns>
    public int GetCritDmg(float critRate)
    {
        if (UnityEngine.Random.Range(0,1f)<critRate)
        {
            return (int)(10 * UnityEngine.Random.Range(0.5f, 1f));
        }
        return 0;
    }
    /// <summary>
    /// 敌人减伤计算：敌人不升级
    /// </summary>
    /// <param name="lv"></param>
    /// <returns>减伤值</returns>
    public int GetDmgDescValue(int lv)
    {
        return 0;
    }
    /// <summary>
    /// 敌人等级上升提供的额外生命值：敌人不升级
    /// </summary>
    /// <param name="lv">等级</param>
    /// <returns>额外生命值</returns>
    public int GetExtraHPValue(int lv)
    {
        return 0;
    }
}


using System;
using System.Collections.Generic;
using System.Text;


public class SoldierAttrStrategy : IAttrStrategy
{
    /// <summary>
    /// 士兵暴击伤害计算（士兵不存在暴击）
    /// </summary>
    /// <param name="critRate">暴击率</param>
    /// <returns>暴击伤害</returns>
    public int GetCritDmg(float critRate)
    {
        return 0;
    }
    /// <summary>
    /// 士兵减伤计算，根据等级
    /// </summary>
    /// <param name="lv">等级</param>
    /// <returns>减伤值</returns>
    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }
    /// <summary>
    /// 士兵额外生命值加成：根据等级
    /// </summary>
    /// <param name="lv">等级</param>
    /// <returns>额外生命值</returns>
    public int GetExtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}

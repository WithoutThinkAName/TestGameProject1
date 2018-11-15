using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 当前实际人物属性计算策略
/// </summary>
public interface IAttrStrategy
{
    int GetExtraHPValue(int lv);
    int GetDmgDescValue(int lv);
    int GetCritDmg(float critRate);
}


   
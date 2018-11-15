using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 人物属性类
/// </summary>
public  class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;//公用共有的基础属性
    protected IAttrStrategy mStrategy;//人物属性值计算策略

    protected int mCurrentHP;//当前实际人物生命值
    private int mCurrentMaxHP;//当前实际人物最大生命值
    //策略模式：等级属性加成，暴击率问题
    protected int mLv;//当前实际等级
    
    protected int mDmgDescValue;//当前实际减伤数值
    /// <summary>
    /// 初始化人物属性构造
    /// 根据人物默认基础属性与当前等级，计算当前人物的实际属性值
    /// </summary>
    /// <param name="strategy">人物属性计算策略</param>
    /// <param name="lv">等级</param>
    /// <param name="baseAttr">人物默认基础属性</param>
    public ICharacterAttr(IAttrStrategy strategy,int lv,CharacterBaseAttr baseAttr)
    {       
        mLv = lv;
        mBaseAttr = baseAttr;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = baseAttr.maxHp + mStrategy.GetExtraHPValue(mLv);
        mCurrentMaxHP = mCurrentHP;
    }
    /// <summary>
    /// 获取暴击伤害值
    /// </summary>
    public int critValue
    {
        get
        {
            return mStrategy.GetCritDmg(mBaseAttr.critRate);
        }
    }
    /// <summary>
    /// 外部获取当前HP
    /// </summary>
    public int currentHP { get { return mCurrentHP; } }
    /// <summary>
    /// 外部获取当前最大HP
    /// </summary>
    public int maxHP { get { return mCurrentMaxHP; } }

    /// <summary>
    /// 被击中后，根据减伤计算收到的伤害值，最小强制伤害：5
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
       
        mCurrentHP -= damage;
    }
}


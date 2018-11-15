using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人状态转换类型
/// </summary>
public enum EnemyTransition
{
    NullTransition = 0,
    LostSoldier,
    CanAttack
}
/// <summary>
/// 敌人状态ID
/// </summary>
public enum EnemyStateID
{
    NullState,
    Chase,
    Attack
}

/// <summary>
/// 敌人状态类
/// </summary>
public abstract class IEnemyState
{
    //敌人状态转换字典
    protected Dictionary<EnemyTransition, EnemyStateID> mMaps = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;//状态ID
    protected ICharacter mCharacter;//人物
    protected EnemyFSMSystem mFSM;//有限状态机

    /// <summary>
    /// 敌人状态初始化
    /// </summary>
    /// <param name="fsm">有限状态机</param>
    /// <param name="c">敌人人物</param>
    public IEnemyState(EnemyFSMSystem fsm, ICharacter c)
    {
        mFSM = fsm;
        mCharacter = c;
    }

    /// <summary>
    /// 获取状态ID
    /// </summary>
    public EnemyStateID stateID { get { return mStateID; } }
    /// <summary>
    /// 添加状态转换
    /// </summary>
    /// <param name="trans">状态转换类型</param>
    /// <param name="id">目标转换状态</param>
    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.Log("不能为空");
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.Log("id不能为空");
        }
        if (mMaps.ContainsKey(trans))
        {
            Debug.Log("已经添加过");
        }
        mMaps.Add(trans, id);
    }
    /// <summary>
    /// 移除已经存在的方法转换类型
    /// </summary>
    /// <param name="trans">转换类型</param>
    public void DeleteTransition(EnemyTransition trans)
    {
        if (mMaps.ContainsKey(trans) == false)
        {
            Debug.Log("删除错误：条件[" + trans + "]不存在");
        }
        mMaps.Remove(trans);
    }
    /// <summary>
    /// 获取转换类型的状态ID
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public EnemyStateID GetOutState(EnemyTransition trans)
    {
        if (mMaps.ContainsKey(trans) == false)
        {
            Debug.Log("无法取得[" + trans + "]的ID");
            return EnemyStateID.NullState;
        }
        else
        {
            return mMaps[trans];
        }
    }
    //状态切换时要做的事（可以不做）
    public virtual void DoBeForeEntering() { }
    public virtual void DoBeforeLeaving() { }

    //每帧要做的事（必须重写）
    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}

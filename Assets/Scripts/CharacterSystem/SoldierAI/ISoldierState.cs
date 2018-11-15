using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵状态切换类型
/// </summary>
public enum SoldierTransition
{
    NullTransition=0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}
/// <summary>
/// 士兵状态ID
/// </summary>
public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}

/// <summary>
/// 士兵状态类
/// </summary>
public abstract class ISoldierState
{
    //士兵状态转换字典
    protected Dictionary<SoldierTransition, SoldierStateID> mMaps = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;//状态ID
    protected ICharacter mCharacter;//人物
    protected SoldierFSMSystem mFSM;//有限状态机
    /// <summary>
    /// 初始化士兵构造
    /// </summary>
    /// <param name="fsm">有限状态机</param>
    /// <param name="c">士兵人物</param>
    public ISoldierState(SoldierFSMSystem fsm,ICharacter c)
    {
        mFSM = fsm;
        mCharacter = c;
    }
    /// <summary>
    /// 获取状态ID
    /// </summary>
    public SoldierStateID stateID { get { return mStateID; } }
	/// <summary>
    /// 添加状态转换类型
    /// </summary>
    /// <param name="trans">状态转换类型</param>
    /// <param name="id">目标状态</param>
    public void AddTransition(SoldierTransition trans,SoldierStateID id)
    {
        if (trans==SoldierTransition.NullTransition)
        {
            Debug.Log("不能为空");
        }
        if (id==SoldierStateID.NullState)
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
    /// 移除状态转换
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(SoldierTransition trans)
    {
        if (mMaps.ContainsKey(trans)==false)
        {
            Debug.Log("删除错误：条件[" + trans + "]不存在");
        }
        mMaps.Remove(trans);
    }
    /// <summary>
    /// 获取状态转换类型中的状态ID
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public SoldierStateID GetOutState(SoldierTransition trans)
    {
        if (mMaps.ContainsKey(trans)==false)
        {
            Debug.Log("无法取得["+trans+"]的ID");
            return SoldierStateID.NullState;
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

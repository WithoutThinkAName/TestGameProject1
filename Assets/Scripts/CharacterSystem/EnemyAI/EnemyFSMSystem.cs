using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人有限状态机
/// </summary>
public class EnemyFSMSystem
{
    //敌人状态列表
    private List<IEnemyState> mStates = new List<IEnemyState>();

    private IEnemyState mCurrentState;//当前状态
    /// <summary>
    /// 获取当前状态
    /// </summary>
    public IEnemyState currentState { get { return mCurrentState; } }
    /// <summary>
    /// 添加状态：批量
    /// </summary>
    /// <param name="states"></param>
    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states)
        {
            AddState(s);
        }
    }
    /// <summary>
    /// 添加状态：单个
    /// </summary>
    /// <param name="state"></param>
    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("添加的状态为空");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeForeEntering();
            return;
        }

        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("添加状态[" + s + "]已存在");
            }           
        }
        mStates.Add(state);
    }
    /// <summary>
    /// 移除状态：单个
    /// </summary>
    /// <param name="stateID"></param>
    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态为空");
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的状态[" + stateID + "]不存在列表中");
    }
    /// <summary>
    /// 状态间切换，达成条件切换至另一个状态
    /// </summary>
    /// <param name="trans">状态转换类型</param>
    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("执行的转换条件为空：" + trans);
        }
        EnemyStateID nextStateID = mCurrentState.GetOutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("没有对应的转换状态：" + trans);
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeForeEntering();
                return;
            }
        }
    }
}


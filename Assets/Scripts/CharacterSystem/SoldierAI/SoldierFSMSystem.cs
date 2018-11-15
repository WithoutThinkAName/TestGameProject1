using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵优先状态机
/// </summary>
public class SoldierFSMSystem
{
    //状态列表
    private List<ISoldierState> mStates = new List<ISoldierState>();

    private ISoldierState mCurrentState;//当前状态
    /// <summary>
    /// 获取当前状态
    /// </summary>
    public ISoldierState currentState { get { return mCurrentState; } }
    /// <summary>
    /// 添加状态:批量
    /// </summary>
    /// <param name="states"></param>
    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }
    /// <summary>
    /// 添加状态：单个
    /// </summary>
    /// <param name="state"></param>
    public void AddState(ISoldierState state)
    {
        //Debug.Log(state);
        if (state==null)
        {
            Debug.LogError("添加的状态为空");
            return;
        }
        if(mStates.Count==0)
        {
            mStates.Add(state);
            mCurrentState = state;
            return;
        }

        foreach (ISoldierState s in mStates)
        {
            if (s.stateID==state.stateID)
            {
                Debug.LogError("添加状态[" + s + "]已存在");
            }
        }
        mStates.Add(state);
    }
    /// <summary>
    /// 移除状态
    /// </summary>
    /// <param name="stateID"></param>
    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID==SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态为空");
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID==stateID)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("要删除的状态[" + stateID + "]不存在列表中");
    }
    /// <summary>
    /// 状态切换的执行部分
    /// </summary>
    /// <param name="trans"></param>
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans==SoldierTransition.NullTransition)
        {
            Debug.LogError("执行的转换条件为空：" + trans);
        }
        SoldierStateID nextStateID = mCurrentState.GetOutState(trans);
        if (nextStateID==SoldierStateID.NullState)
        {
            Debug.LogError("没有对应的转换状态：" + trans);
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID==nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeForeEntering();
                return;
            }
        }
    }
}


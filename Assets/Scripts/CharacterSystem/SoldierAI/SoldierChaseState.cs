using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵追逐状态类
/// </summary>
public class SoldierChaseState : ISoldierState
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="c"></param>
    public SoldierChaseState(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c)
    {
        mStateID = SoldierStateID.Chase;
    }
    /// <summary>
    /// 每帧执行
    /// </summary>
    /// <param name="targets"></param>
    public override void Act(List<ICharacter> targets)
    {
        if (targets!=null&&targets.Count>0)
        {
            mCharacter.MoveToTarget(mCharacter.GetNearestTarget(targets).position);
        }
    }
    /// <summary>
    /// 状态切换判定
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets)
    {
        if (targets==null||targets.Count==0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(mCharacter.GetNearestTarget(targets).position, mCharacter.position);
        if (distance<=mCharacter.atkRange)
        {
            mFSM.PerformTransition(SoldierTransition.CanAttack);
        }
    }
}


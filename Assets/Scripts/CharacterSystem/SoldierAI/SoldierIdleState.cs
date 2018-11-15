using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵待机状态
/// </summary>
public class SoldierIdleState : ISoldierState
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="c"></param>
    public SoldierIdleState(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c)
    {
        mStateID = SoldierStateID.Idle;
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    /// <param name="targets"></param>
    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }
    
    /// <summary>
    /// 状态切换判定
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets)
    {
        if (targets!=null&&targets.Count>0)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}


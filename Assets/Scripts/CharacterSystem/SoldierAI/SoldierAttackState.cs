using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 士兵攻击状态
/// </summary>
public class SoldierAttackState : ISoldierState
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="c"></param>
    public SoldierAttackState(SoldierFSMSystem fsm,ICharacter c) : base(fsm,c)
    {
        mStateID = SoldierStateID.Attack;
        mAtkTimer = mAtkTime;
    }

    private float mAtkTime = 1;//攻击间隔
    private float mAtkTimer = 1;//间隔计时器

    /// <summary>
    /// 每帧运行
    /// </summary>
    /// <param name="targets"></param>
    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        mAtkTimer += Time.deltaTime;
        if (mAtkTimer>=mAtkTime)
        {
            mCharacter.Attack(mCharacter.GetNearestTarget(targets));
            mAtkTimer = 0;
        }
    }
    /// <summary>
    /// 转换判定
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets)
    {
        if (targets==null||targets.Count==0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(mCharacter.position, mCharacter.GetNearestTarget(targets).position);
        if (distance>mCharacter.atkRange)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
    /// <summary>
    /// 进入状态优先执行项
    /// </summary>
    public override void DoBeForeEntering()
    {
        mCharacter.StopMove();        
    }
}


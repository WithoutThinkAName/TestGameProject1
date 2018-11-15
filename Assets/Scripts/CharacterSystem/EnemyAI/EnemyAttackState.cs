using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人攻击状态类
/// </summary>
public class EnemyAttackState : IEnemyState
{
    /// <summary>
    /// 初始化攻击状态构造
    /// </summary>
    /// <param name="fsm">有限状态机</param>
    /// <param name="c">敌人人物</param>
    public EnemyAttackState(EnemyFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = EnemyStateID.Attack;
    }

    private float mAtkTime = 1;//攻击间隔
    private float mAtkTimer = 1;//攻击计时器
    /// <summary>
    /// 状态每帧执行
    /// </summary>
    /// <param name="targets">当前存活士兵</param>
    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        mAtkTimer += Time.deltaTime;
        if (mAtkTimer >= mAtkTime)
        {
            mCharacter.Attack(mCharacter.GetNearestTarget(targets));
            mAtkTimer = 0;
        }
    }
    /// <summary>
    /// 敌人状态切换判断
    /// </summary>
    /// <param name="targets">当前存活的士兵</param>
    public override void Reason(List<ICharacter> targets)
    {
        
        if (targets==null||targets.Count==0)
        {
            mFSM.PerformTransition(EnemyTransition.LostSoldier);
            return;
        }
        float distance = Vector3.Distance(mCharacter.position, mCharacter.GetNearestTarget(targets).position);
        if (distance > mCharacter.atkRange)
        {
            mFSM.PerformTransition(EnemyTransition.LostSoldier);
        }
    }
    /// <summary>
    /// 进入当前状态时有限执行项
    /// </summary>
    public override void DoBeForeEntering()
    {
        mCharacter.StopMove();
    }
}


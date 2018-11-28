using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 敌人追逐状态类
/// </summary>
public class EnemyChaseState : IEnemyState
{
    /// <summary>
    /// 初始化敌人追逐状态
    /// </summary>
    /// <param name="fsm">有限状态机</param>
    /// <param name="c">敌人人物</param>
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = EnemyStateID.Chase;
    }
    /// <summary>
    /// 目标抵达位置
    /// </summary>
    private Vector3 mTargetPosition;
    /// <summary>
    /// 进入追逐状态时优先执行项
    /// </summary>
    public override void DoBeForeEntering()
    {
        mTargetPosition = GameStageFacade.Instance.GetEnemyTargetosition();
    }
    /// <summary>
    /// 状态每帧执行内容
    /// </summary>
    /// <param name="targets">当前存活士兵</param>
    public override void Act(List<ICharacter> targets)
    {
        if (targets!=null&&targets.Count>0)
        {
            mCharacter.MoveToTarget(mCharacter.GetNearestTarget(targets).position);
        }
        else
        {
            mCharacter.MoveToTarget(mTargetPosition);

            float distance = Vector3.Distance(mTargetPosition, mCharacter.position);
            if (distance <= 1)
            {
                mCharacter.ReachTargetPoint();
            }
        }
    }
    /// <summary>
    /// 状态切换判断
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null&&targets.Count>0)
        {
            float distance = Vector3.Distance(mCharacter.GetNearestTarget(targets).position, mCharacter.position);
            if (distance <= mCharacter.atkRange)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}


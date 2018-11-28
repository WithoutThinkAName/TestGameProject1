using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 士兵类型
/// </summary>
public enum SoldierType
{
    Rookie=0,    
    Sergeant=1,
    Captain = 2
}

/// <summary>
/// 士兵人物基础类
/// </summary>
public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSystem mFSMSystem;//有限状态机

    /// <summary>
    /// 初始化士兵
    /// </summary>
    public ISoldier()
    {
        MakeFSM();
    }
    /// <summary>
    /// 每帧执行有限状态机，死亡不执行
    /// </summary>
    /// <param name="targets">当前存活的敌人</param>
    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsKilled) return;
        //Debug.Log(position);
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);
    }
    /// <summary>
    /// 创建士兵的有限状态机
    /// </summary>
    private void MakeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();
        //待机
        SoldierIdleState idleState = new SoldierIdleState(mFSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);
        //追逐
        SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);
        //攻击
        SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mFSMSystem.AddState
            (
                idleState,
                chaseState,
                attackState
            );
    }
    /// <summary>
    /// 士兵被攻击伤害计算，死亡判定，被攻击特效显示
    /// </summary>
    /// <param name="damage">攻击伤害</param>
    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);

        if (mAttr.currentHP<=0)
        {
            mIsKilled = true;
            PlaySound();
            PlayEffect();
            Killed();
        }
    }
    /// <summary>
    /// 音效
    /// </summary>
    protected abstract void PlaySound();
    /// <summary>
    /// 特效
    /// </summary>
    protected abstract void PlayEffect();

    /// <summary>
    /// 士兵死亡
    /// </summary>
    public override void Killed()
    {
        base.Killed();
        GameStageFacade.Instance.NotifySubject(GameEventType.SoldierKilled);
    }
    /// <summary>
    /// 访问者
    /// </summary>
    /// <param name="visitor">访问者</param>
    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitSoldier(this);
    }
}

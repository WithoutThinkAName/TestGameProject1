using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人类型
/// </summary>
public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}
/// <summary>
/// 敌人人物基础类
/// </summary>
public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;//敌人有限状态机
    
    /// <summary>
    /// 初始化敌人
    /// </summary>
    public IEnemy()
    {
        MakeFSM();
    }
    /// <summary>
    /// 每帧执行有限状态机，死亡不执行
    /// </summary>
    /// <param name="targets">当前存活的士兵</param>
    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsKilled) return;
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);
    }
    /// <summary>
    /// 创建敌人的有限状态机
    /// </summary>
    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();
        //追逐状态
        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);
        //攻击状态
        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mFSMSystem.AddState
            (
                chaseState,
                attackState
            );        
    }
    /// <summary>
    /// 敌人被攻击伤害计算，死亡判定，被攻击特效显示
    /// </summary>
    /// <param name="damage">攻击伤害</param>
    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);
        PlayEffect();     
        if (mAttr.currentHP<=0)
        {
            mIsKilled = true;
            Killed();
        }
    }
    /// <summary>
    /// 显示特效
    /// </summary>
    protected abstract void PlayEffect();
    /// <summary>
    /// 人物死亡后执行方法
    /// </summary>
    public override void Killed()
    {
        base.Killed();
        //Debug.Log("EnemyBeKilled");
        GameStageFacade.Instance.NotifySubject(GameEventType.EnemyKilled);
    }
    /// <summary>
    /// 敌人抵达目标位置方法
    /// </summary>
    public override void ReachTargetPoint()
    {
        mIsKilled = true;
        mCanDestoryImmediately = true;
        GameStageFacade.Instance.ReduceHeart();
    }

    /// <summary>
    /// 访问者
    /// </summary>
    /// <param name="visitor">访问者</param>
    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AchievementSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;//累计杀敌数
    private int mSoldierKilledCount = 0;//累计士兵死亡数
    private int mMaxStageLv = 1;//抵达的最大关卡

    /// <summary>
    /// 初始化成就系统
    /// 注册观察者（杀敌数，士兵死亡数，关卡数）
    /// </summary>
    public override void Init()
    {
        base.Init();
        mMode1Facade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKlledObserverAchievement(this));
        mMode1Facade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverAchievement(this));
        mMode1Facade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievement(this));
    }

    /// <summary>
    /// 敌人击杀数增加
    /// </summary>
    /// <param name="number">敌人击杀数量</param>
    public void AddEnemyKillledCount(int number=1)
    {
        mEnemyKilledCount += number;
        //Debug.Log("EnemyKillledCount:" + mEnemyKilledCount);
    }
    /// <summary>
    /// 士兵死亡数增加
    /// </summary>
    /// <param name="number">士兵死亡数量</param>
    public void AddSoldierKillledCount(int number = 1)
    {
        mSoldierKilledCount += number;
        //Debug.Log("SoldierKillledCount:" + mSoldierKilledCount);
    }
    /// <summary>
    /// 最大到达关卡数设置
    /// 与历史最大值比价，取最大值
    /// </summary>
    /// <param name="stage">当前到达关卡数</param>
    public void SetMaxStageLv(int stage)
    {
        if (stage>mMaxStageLv)
        {
            mMaxStageLv = stage;
            //Debug.Log("MaxStageLv:" + mMaxStageLv);
        }
    }
    /// <summary>
    /// 按当前数据创建备忘录
    /// </summary>
    /// <returns></returns>
    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStageLv;
        return memento;
    }
    /// <summary>
    /// 按现有备忘录设置数据
    /// </summary>
    /// <param name="memento"></param>
    public void SetMemento(AchievementMemento memento)
    {
        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStageLv = memento.maxStageLv;
    }

}


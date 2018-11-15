using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 关卡系统
/// </summary>
public class StageSystem : IGameSystem
{
    private int mLv = 1;//关卡数
    private List<Vector3> mPosList;//敌人生成点列表
    private IStageHandler mRootHandler;//关卡处理器
    private Vector3 mTargetPositon;//敌人目标到达点
    private int mCountOfEnemyKilled = 0;//敌人击杀数

    /// <summary>
    /// 获取敌人击杀数
    /// </summary>
    public int countOfEnemyKilled { set { mCountOfEnemyKilled = value; } }
    /// <summary>
    /// 获取敌人目标到达点
    /// </summary>
    public Vector3 targetPosition { get { return mTargetPositon; } }
    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
        InitPosition();
        InitStageChain();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);
    }
    /// <summary>
    /// 初始化敌人生成点列表
    /// </summary>
    private void InitPosition()
    {
        mPosList = new List<Vector3>();
        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Position" + i);
            if (go!=null)
            {
                mPosList.Add(go.transform.position);
                go.SetActive(false);
                i++;
            }
            else
            {
                break;
            }
        }
    }
    /// <summary>
    /// 从生成点列表随机选取敌人实际生成点
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPos()
    {
        return mPosList[UnityEngine.Random.Range(0, mPosList.Count)];
    }
    /// <summary>
    /// 初始化关卡处理责任链
    /// </summary>
    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Gun, 3, GetRandomPos());
        NormalStageHandler handler2 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rifle, 3, GetRandomPos());
        NormalStageHandler handler3 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rocket, 3, GetRandomPos());
        NormalStageHandler handler4 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Gun, 4, GetRandomPos());
        NormalStageHandler handler5 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rifle, 4, GetRandomPos());
        NormalStageHandler handler6 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rocket, 4, GetRandomPos());
        NormalStageHandler handler7 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Gun, 5, GetRandomPos());
        NormalStageHandler handler8 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rifle, 5, GetRandomPos());
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rocket, 5, GetRandomPos());


        handler1.SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9);

        mRootHandler = handler1;

        GameObject tar = GameObject.Find("TargetPosition");
        //tar.SetActive(true);
        mTargetPositon = tar.transform.position;

    }
    /// <summary>
    /// 进入新关卡执行方法
    /// </summary>
    public void EnterNextStage()
    { 
        mLv++;
        //Debug.Log("新关卡" + mLv);
        mFacade.NotifySubject(GameEventType.NewStage);
        mFacade.UpgradeStageLv(mLv);
    }
    /// <summary>
    /// 游戏通关结束提示
    /// </summary>
    public void StageClear()
    {
        mFacade.ShowGameOverUI("恭喜通关！");
    }
}


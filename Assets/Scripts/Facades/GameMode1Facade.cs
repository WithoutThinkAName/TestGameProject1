using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;


/// <summary>
/// 游戏中介者
/// </summary>
public class GameMode1Facade
{
    private static GameMode1Facade _instance = new GameMode1Facade();//单例模式
    private bool mIsGaneOver = false;//游戏结束判断
    /// <summary>
    /// 获取中介者单例
    /// </summary>
    public static GameMode1Facade Instance { get { return _instance; } }
    /// <summary>
    /// 获取游戏结束状态
    /// </summary>
    public bool isGameOver { get { return mIsGaneOver; } }

    /// <summary>
    /// 私有构造
    /// </summary>
    private GameMode1Facade() { }

   
    private CampSystem mCampSystem;//兵营系统
    private CharacterSystem mCharacterSystem;//人物角色系统
    private EnergySystem mEnergySystem;//能量系统
    private GameEventSystem mGameEventSystem;//游戏事件系统
    private StageSystem mStageSystem;//关卡系统
    private HeartSystem mHeartSystem;//关卡生命值系统（心）
    private ScreenSystem mScreenSystem;//屏幕系统

    

    /// <summary>
    /// 初始化
    /// </summary>
    public void InitStage()
    {
        
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();
        mHeartSystem = new HeartSystem();
        mScreenSystem = new ScreenSystem();

       
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();
        mHeartSystem.Init();
        mScreenSystem.Init();
        
     
        
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public void UpdateStage()
    {
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();
        mHeartSystem.Update();
        mScreenSystem.Update();

    }
    /// <summary>
    /// 释放
    /// </summary>
    public void ReleaseStage()
    {
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();
        mHeartSystem.Release();
        mScreenSystem.Release();

        
    }
    /// <summary>
    /// 获取敌人目标到达位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetEnemyTargetosition()
    {
        return mStageSystem.targetPosition;
    }
    /// <summary>
    /// 根据类型查询兵营对象
    /// </summary>
    /// <param name="soldierType"></param>
    /// <returns></returns>
    public SoldierCamp FindSoldierCampByCampType(SoldierType soldierType)
    {
        return mCampSystem.FindSoldierCampByCampType(soldierType);
    }
    /// <summary>
    /// 显示士兵兵营UI信息
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfo(ICamp camp)
    {
        GameMainFacade.Instance.UIManagerSystem.ShowCampInfo(camp);
    }
    /// <summary>
    /// 人物系统添加士兵对象
    /// </summary>
    /// <param name="soldier"></param>
    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }
    /// <summary>
    /// 人物系统添加敌人对象
    /// </summary>
    /// <param name="enemy"></param>
    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }
    /// <summary>
    /// 运行访问者
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSystem.RunVisitor(visitor);
    }

    /// <summary>
    /// 能量消耗
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool TakeEnergy(int value)
    {
        return mEnergySystem.TakeEnergy(value);
    }
    /// <summary>
    /// 能量返还
    /// </summary>
    /// <param name="value"></param>
    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }

    /// <summary>
    /// 更新能量条数据
    /// </summary>
    /// <param name="nowEnergy"></param>
    /// <param name="maxEnergy"></param>
    public void UpgradeEnergySlider(int nowEnergy, int maxEnergy)
    {
        GameMainFacade.Instance.UIManagerSystem.UpdateEnergySlider(nowEnergy, maxEnergy);
    }
    /// <summary>
    /// 更新当前关卡数
    /// </summary>
    /// <param name="lv"></param>
    public void UpgradeStageLv(int lv)
    {
        GameMainFacade.Instance.UIManagerSystem.UpdateStageLv(lv);
    }
    /// <summary>
    /// 关卡生命值减少
    /// </summary>
    public void ReduceHeart()
    {
        mHeartSystem.ReduceHeart();
    }

    /// <summary>
    /// 更新关卡生命值
    /// </summary>
    /// <param name="heartCount"></param>
    public void UpdateHeartCount(int heartCount)
    {
        GameMainFacade.Instance.UIManagerSystem.UpdateHeartCount(heartCount);
    }
    /// <summary>
    /// 根据事件类型，注册观察者
    /// </summary>
    /// <param name="et"></param>
    /// <param name="observer"></param>
    public void RegisterObserver(GameEventType et, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(et, observer);
    }
    /// <summary>
    /// 根据事件类型，移除观察者
    /// </summary>
    /// <param name="et"></param>
    /// <param name="observer"></param>
    public void RemoveObserver(GameEventType et, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(et, observer);
    }
    /// <summary>
    /// 更新指定类型的游戏事件数据
    /// </summary>
    /// <param name="et"></param>
    public void NotifySubject(GameEventType et)
    {
        mGameEventSystem.NotifySubject(et);
    }
    
   
    /// <summary>
    /// 关卡状态设置
    /// </summary>
    /// <param name="isGameover"></param>
    public void SetIsGameOver(bool isGameover)
    {
        mIsGaneOver = isGameover;
    }
   
}

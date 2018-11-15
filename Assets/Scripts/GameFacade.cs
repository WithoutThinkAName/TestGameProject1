using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 对外：外观模式
/// 对内：中介者模式
/// </summary>
public class GameFacade
{
    private static GameFacade _instance = new GameFacade();//单例模式
    private bool mIsGaneOver = false;//游戏结束判断
    /// <summary>
    /// 获取中介者单例
    /// </summary>
    public static GameFacade Instance { get { return _instance; } }
    /// <summary>
    /// 获取游戏结束状态
    /// </summary>
    public bool isGameOver { get { return mIsGaneOver; } }

    /// <summary>
    /// 私有构造
    /// </summary>
    private GameFacade() { }

    private AchievementSystem mAchievementSystem;//成就系统
    private CampSystem mCampSystem;//兵营系统
    private CharacterSystem mCharacterSystem;//人物角色系统
    private EnergySystem mEnergySystem;//能量系统
    private GameEventSystem mGameEventSystem;//游戏事件系统
    private StageSystem mStageSystem;//关卡系统
    private HeartSystem mHeartSystem;//关卡生命值系统（心）

    private CampInfoUI mCampInfoUI;//兵营UI面板
    private GamePauseUI mGamePauseUI;//游戏暂停UI面板
    private GameStateInfoUI mGameStateInfoUI;//游戏状态信息UI面板
    private SoldierInfoUI mSoldierInfoUI;//士兵信息UI面板

    /// <summary>
    /// 初始化
    /// 载入备忘录数据并设置
    /// </summary>
    public void Init()
    {
        mAchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();
        mHeartSystem = new HeartSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mAchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();
        mHeartSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();

        LoadMemento();
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public void Update()
    {
        mAchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();
        mHeartSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }
    /// <summary>
    /// 释放
    /// 根据当前数据生成备忘录并存储
    /// </summary>
    public void Release()
    {
        mAchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();
        mHeartSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();

        CreateMemento();
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
    /// 显示兵营信息UI
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfo(ICamp camp)
    {
        mSoldierInfoUI.HideSoldierInfo();
        mCampInfoUI.ShowCampInfo(camp);
    }
    /// <summary>
    /// 显示士兵信息UI
    /// </summary>
    /// <param name="soldier"></param>
    public void ShowSoldierInfo(ISoldier soldier)
    {
        mSoldierInfoUI.ShowSoldierInfo(soldier);
    }
    /// <summary>
    /// 显示游戏暂停UI
    /// </summary>
    public void ShowGamePauseUI()
    {
        mGamePauseUI.ShowGamePauseUI();
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
    /// 显示提示信息
    /// </summary>
    /// <param name="msg"></param>
    public void ShowMsg(string msg)
    {
        mGameStateInfoUI.ShowMsg(msg);
    }
    /// <summary>
    /// 更新能量条数据
    /// </summary>
    /// <param name="nowEnergy"></param>
    /// <param name="maxEnergy"></param>
    public void UpgradeEnergySlider(int nowEnergy, int maxEnergy)
    {
        mGameStateInfoUI.UpdateEnergySlider(nowEnergy, maxEnergy);
    }
    /// <summary>
    /// 更新当前关卡数
    /// </summary>
    /// <param name="lv"></param>
    public void UpgradeStageLv(int lv)
    {
        mGameStateInfoUI.UpdateStageLv(lv);
    }
    /// <summary>
    /// 关卡生命值减少
    /// </summary>
    public void ReduceHeart()
    {
        mHeartSystem.ReduceHeart();
    }
    /// <summary>
    /// 显示游戏结束UI
    /// </summary>
    /// <param name="gameOverInfo"></param>
    public void ShowGameOverUI(string gameOverInfo)
    {
        mGameStateInfoUI.ShowGameOverUI(gameOverInfo);
    }
    /// <summary>
    /// 更新关卡生命值
    /// </summary>
    /// <param name="heartCount"></param>
    public void UpdateHeartCount(int heartCount)
    {
        mGameStateInfoUI.UpdateHeartCount(heartCount);
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
    /// 读取并设置备忘录
    /// </summary>
    public void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }
    /// <summary>
    /// 创建并存储备忘录
    /// </summary>
    public void CreateMemento()
    {
        AchievementMemento memento= mAchievementSystem.CreateMemento();
        memento.SaveData();
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
    /// 关卡状态设置
    /// </summary>
    /// <param name="isGameover"></param>
    public void SetIsGameOver(bool isGameover)
    {
        mIsGaneOver = isGameover;
    }
}

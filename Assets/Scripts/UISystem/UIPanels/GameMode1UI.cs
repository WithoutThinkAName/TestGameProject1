using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏状态UI界面
/// </summary>
public class GameMode1UI : IBaseUI
{
    private Text HeartLab;//心数量文本
    private Text mSoldierCount;//存活士兵数量文本
    private Text mEnemyCount;//存活敌人数量文本
    private Text mCurrentStage;//当前关卡等级文本
    private Button mPauseBtn;//暂停游戏按钮
    
    private Slider mEnergySlider;//能量条
    private Text mEnergyText;//能量信息文本
    private Button mCampRookie;//新手兵营信息显示按钮
    private Button mCampSergeant;//中士兵营信息显示按钮
    private Button mCampCaptain;//上尉兵营信息显示按钮
    
    public GameMode1Facade Mode1Facade { get { return mMode1Facade; } }
    
    private AliveCountVisitor mAliveCountVisitor=new AliveCountVisitor();//访问者：当前人物存活数量

    //将原兵营UI合并
    private ICamp mCamp;//兵营对象

    private Image mCampIcon;//兵营图标
    private Text mCampName;//兵营名称
    private Text mCampLevel;//兵营等级
    private Text mWeaponLevel;//武器等级
    private Button mCampUpgradeBtn;//兵营升级按钮
    private Button mWeaponUpgradeBtn;//武器升级按钮
    private Button mTrainBtn;//训练士兵按钮
    private Text mTrainBtnText;//训练士兵按钮文本框
    private Button mCancelTrainBtn;//取消一个训练士兵按钮
    private Text mAliveCount;//士兵存活数文本框
    private Text mTrainingCount;//训练中的士兵数量文本框
    private Text mTrainTime;//当前士兵剩余训练时间文本框

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
        
        GameObject heart1 = UnityTool.FindChildByName(mUIRoot, "Heart1");

        HeartLab= UITools.FindChild<Text>(mUIRoot, "HeartLab");
        mSoldierCount = UITools.FindChild<Text>(mUIRoot, "AliveSoldier");
        mEnemyCount = UITools.FindChild<Text>(mUIRoot, "AliveEnemy");
        mCurrentStage = UITools.FindChild<Text>(mUIRoot, "CurrentStage");
        mPauseBtn = UITools.FindChild<Button>(mUIRoot, "PauseBtn");
        mEnergySlider = UITools.FindChild<Slider>(mUIRoot, "EnergySlider");
        mEnergyText = UITools.FindChild<Text>(mUIRoot, "EnergyLab");
        mCampRookie = UITools.FindChild<Button>(mUIRoot, "Camp_Rookie");
        mCampSergeant = UITools.FindChild<Button>(mUIRoot, "Camp_Sergeant");
        mCampCaptain = UITools.FindChild<Button>(mUIRoot, "Camp_Captain");
        

        mPauseBtn.onClick.AddListener(PauseBtnOcClick);
        mCampRookie.onClick.AddListener(delegate { mMode1Facade.FindSoldierCampByCampType(SoldierType.Rookie).ShowCampInfo(); });
        mCampSergeant.onClick.AddListener(delegate { mMode1Facade.FindSoldierCampByCampType(SoldierType.Sergeant).ShowCampInfo(); });
        mCampCaptain.onClick.AddListener(delegate { mMode1Facade.FindSoldierCampByCampType(SoldierType.Captain).ShowCampInfo(); });


        mCampIcon = UITools.FindChild<Image>(mUIRoot, "CampIcon");
        mCampName = UITools.FindChild<Text>(mUIRoot, "CampLab");
        mCampLevel = UITools.FindChild<Text>(mUIRoot, "CampLvLab2");
        mWeaponLevel = UITools.FindChild<Text>(mUIRoot, "WeaponLvLab2");
        mCampUpgradeBtn = UITools.FindChild<Button>(mUIRoot, "CampUpgradeBtn");
        mWeaponUpgradeBtn = UITools.FindChild<Button>(mUIRoot, "WeaponUpgradeBtn");
        mTrainBtn = UITools.FindChild<Button>(mUIRoot, "TrainBtn");
        mTrainBtnText = UITools.FindChild<Text>(mUIRoot, "TrainLab");
        mCancelTrainBtn = UITools.FindChild<Button>(mUIRoot, "CancelTrainBtn");
        mAliveCount = UITools.FindChild<Text>(mUIRoot, "AliveCountLab2");
        mTrainingCount = UITools.FindChild<Text>(mUIRoot, "TrainingCountLab2");
        mTrainTime = UITools.FindChild<Text>(mUIRoot, "TrainTimeLab2");

        mTrainBtn.onClick.AddListener(OnTrainClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainClick);
        mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);


        //开始默认显示一个兵营信息
        mMode1Facade.FindSoldierCampByCampType(SoldierType.Rookie).ShowCampInfo();
    }
    /// <summary>
    /// 每帧运行
    /// 提示信息显示处理
    /// </summary>
    public override void Update()
    {
        base.Update();
        UpdateAlive();
        if (mCamp != null)
        {
            ShowTrainingInfo();
        }
    }
   
    /// <summary>
    /// 刷新能量条数据
    /// </summary>
    /// <param name="nowEnergy">现有能量</param>
    /// <param name="maxEnergy">最大能量</param>
    public void UpdateEnergySlider(int nowEnergy,int maxEnergy)
    {
        mEnergySlider.value = (float)nowEnergy / maxEnergy;
        mEnergyText.text = string.Format("({0}/{1})", nowEnergy, maxEnergy);
    }
    /// <summary>
    /// 刷新当前存活士兵和敌人数量
    /// </summary>
    public void UpdateAlive()
    {
        mAliveCountVisitor.Reset();
        mMode1Facade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.soldierCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.enemyCount.ToString();
    }
    /// <summary>
    /// 更新当前关卡数
    /// </summary>
    /// <param name="lv"></param>
    public void UpdateStageLv(int lv)
    {
        mCurrentStage.text = lv.ToString();
    }
    /// <summary>
    /// 更新关卡心数
    /// </summary>
    /// <param name="heartCount"></param>
    public void UpdateHeartCount(int heartCount)
    {
        HeartLab.text = heartCount.ToString();
    }
   
    /// <summary>
    /// 暂停按钮点击事件
    /// </summary>
    private void PauseBtnOcClick()
    {
        Time.timeScale = 0;
        mUIManager.PushPanel(UIPanelType.GamePauseUI);
    }


    /// <summary>
    /// 显示兵营信息
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfo(ICamp camp)
    {
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponLevel(camp.weaponType);
        mTrainBtnText.text = string.Format("训练\n{0}能量", mCamp.energyCostTrain);
        ShowTrainingInfo();
    }
    /// <summary>
    /// 显示士兵训练信息
    /// </summary>
    private void ShowTrainingInfo()
    {
        mTrainingCount.text = mCamp.trainCount.ToString();
        mTrainTime.text = mCamp.trainRemainingTime.ToString("0.00");
        if (mCamp.trainCount == 0)
        {
            mCancelTrainBtn.interactable = false;
        }
        else
        {
            mCancelTrainBtn.interactable = true;
        }
    }
    /// <summary>
    /// 显示武器信息
    /// </summary>
    /// <param name="weaponType"></param>
    void ShowWeaponLevel(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 训练士兵按钮事件
    /// </summary>
    public void OnTrainClick()
    {
        //判断能量
        int energy = mCamp.energyCostTrain;
        if (mMode1Facade.TakeEnergy(energy))
        {
            mCamp.Train();
        }
        else
        {
            mMainfacade.ShowMessageUI("能量不足，需要" + energy + "点能量训练新士兵");
        }
    }
    /// <summary>
    /// 取消士兵训练按钮事件
    /// </summary>
    public void OnCancelTrainClick()
    {
        //回收能量
        mMode1Facade.RecycleEnergy(mCamp.energyCostTrain);
        //取消训练
        mCamp.CancelATrainCommand();
    }
    /// <summary>
    /// 兵营升级按钮事件
    /// </summary>
    private void OnCampUpgradeClick()
    {
        int energy = mCamp.energyCostCampUpgrade;
        if (energy < 0)
        {
            mMainfacade.ShowMessageUI("无法升级兵营，等级最大");
            return;
        }
        if (mMode1Facade.TakeEnergy(energy))
        {
            mCamp.UpgradeCamp();
            ShowCampInfo(mCamp);
        }
        else
        {
            mMainfacade.ShowMessageUI("能量不足，需要" + energy + "点能量升级兵营");
        }
    }
    /// <summary>
    /// 武器升级按钮事件
    /// </summary>
    private void OnWeaponUpgradeClick()
    {
        int energy = mCamp.energyCostWeaponUpgrade;
        if (energy < 0)
        {
            mMainfacade.ShowMessageUI("无法升级武器，等级最大");
            return;
        }
        if (mMode1Facade.TakeEnergy(energy))
        {
            mCamp.UpgradeWeapon();
            ShowCampInfo(mCamp);
        }
        else
        {
            mMainfacade.ShowMessageUI("能量不足，需要" + energy + "点能量升级武器");
        }
    }
}


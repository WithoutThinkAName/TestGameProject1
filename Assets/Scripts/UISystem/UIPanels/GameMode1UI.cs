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

    
    private AliveCountVisitor mAliveCountVisitor=new AliveCountVisitor();//访问者：当前人物存活数量

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
    }
    /// <summary>
    /// 每帧运行
    /// 提示信息显示处理
    /// </summary>
    public override void Update()
    {
        base.Update();
        UpdateAlive();
        
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
    
}


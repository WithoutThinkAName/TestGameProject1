using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 士兵信息UI界面
/// </summary>
public class SoldierInfoUI:IBaseUI
{
    private Image mSoldierIcon;//士兵图标
    private Text mSoldierNameLab;//士兵名称文本
    private Text mHPLab;//士兵血量文本
    private Slider mHPSlider;//士兵血量条UI
    private Text mLv;//士兵等级
    private Text mAtk;//士兵攻击力
    private Text mAtkRange;//士兵攻击距离
    private Text mMoveSpeed;//士兵移动速度

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mUIRoot = UnityTool.FindChildByName(canvas, "SoldierInfo");

        mSoldierIcon = UITools.FindChild<Image>(mUIRoot, "SoldierIcon");
        mSoldierNameLab = UITools.FindChild<Text>(mUIRoot, "SoldierNameLab");
        mHPLab = UITools.FindChild<Text>(mUIRoot, "HPLab2");
        mHPSlider = UITools.FindChild<Slider>(mUIRoot, "HPSlider");
        mLv = UITools.FindChild<Text>(mUIRoot, "LevelLab2");
        mAtk = UITools.FindChild<Text>(mUIRoot, "ATKLab2");
        mAtkRange = UITools.FindChild<Text>(mUIRoot, "ATKRangeLab2");
        mMoveSpeed = UITools.FindChild<Text>(mUIRoot, "MoveSpeedLab2");

        Hide();
    }
    /// <summary>
    /// 显示士兵信息UI
    /// </summary>
    /// <param name="soldier"></param>
    public void ShowSoldierInfo(ISoldier soldier)
    {
        Show();
        
    }
    /// <summary>
    /// 隐藏士兵信息UI
    /// </summary>
    public void HideSoldierInfo()
    {
        Hide();
    }
}


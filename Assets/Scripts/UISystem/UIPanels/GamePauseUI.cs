using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏暂停UI界面
/// </summary>
public class GamePauseUI:IBaseUI
{
    private Text mCurrentLevel;//当前关卡等级
    private Button mContinueBtn;//继续游戏按钮
    private Button mBackMenuBtn;//返回主菜单按钮

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
        

        mCurrentLevel = UITools.FindChild<Text>(mUIRoot, "CurrentLvLab2");
        mContinueBtn = UITools.FindChild<Button>(mUIRoot, "ContinueBtn");
        mBackMenuBtn = UITools.FindChild<Button>(mUIRoot, "BackMenuBtn");

        Hide();

        mContinueBtn.onClick.AddListener(ContinueBtnOnClick);
        mBackMenuBtn.onClick.AddListener(GameOverBackMainMenu);

    }
    /// <summary>
    /// 显示暂停游戏UI界面
    /// </summary>
    public void ShowGamePauseUI()
    {
        Show();
    }
    /// <summary>
    /// 继续游戏按钮事件
    /// </summary>
    public void ContinueBtnOnClick()
    {
        Time.timeScale = 1;
        Hide();
    }
    /// <summary>
    /// 返回主菜单按钮事件
    /// </summary>
    public void GameOverBackMainMenu()
    {
        GameStageFacade.Instance.SetIsGameOver(true);
    }

}


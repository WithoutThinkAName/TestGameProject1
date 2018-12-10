using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI:IBaseUI
{
    private Text mGameOverLab;//游戏结束提示信息文本
    private Button mBackMenuBtn;//返回主菜单按钮

    public override void Init()
    {
        base.Init();

        mGameOverLab = UITools.FindChild<Text>(mUIRoot, "GameOverLab");
        mBackMenuBtn = UITools.FindChild<Button>(mUIRoot, "GameOverBtn");


        mBackMenuBtn.onClick.AddListener(GameOverBackMainMenu);




    }

    /// <summary>
    /// 游戏结束返回主菜单按钮点击事件
    /// </summary>
    public void GameOverBackMainMenu()
    {
        GameMode1Facade.Instance.SetIsGameOver(true);
    }
}


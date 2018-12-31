using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuMode1UI:IBaseUI
{
    private Button mGameStartBtn;
    private Button mReturnMainMenuBtn;


    public override void Init()
    {
        base.Init();

        mGameStartBtn = UITools.FindChild<Button>(mUIRoot, "StartButton_Mode1");
        mReturnMainMenuBtn = UITools.FindChild<Button>(mUIRoot, "CloseButton_Mode1");

        mGameStartBtn.onClick.AddListener(GameStartBtnOnClick);
        mReturnMainMenuBtn.onClick.AddListener(ReturnMainMenuBtnOnClick);

        
    }

    public override void OnEnter()
    {
        base.OnEnter();
        EnterAnim();
    }

    private void EnterAnim()
    {
        mGameStartBtn.enabled = true;
        mReturnMainMenuBtn.enabled = true;

        thisPanel.localPosition = new Vector3(0, -mScreenY/2, 0);

        thisPanel.DOMoveY(mScreenY/2, mAnimSpeed);
    }

    public override void OnExit()
    {
        HideAnim();
    }

    private void HideAnim()
    {
        mGameStartBtn.enabled = false;
        mReturnMainMenuBtn.enabled = false;

        thisPanel.DOMoveY(-mScreenY/2, mAnimSpeed).OnComplete(() => base.OnExit());
    }
    /// <summary>
    /// 游戏模式一开始按钮点击事件
    /// </summary>
    private void GameStartBtnOnClick()
    {
        mMainfacade.EnterMode1State();
    }
    /// <summary>
    /// 游戏模式一返回主菜单按钮点击事件
    /// </summary>
    private void ReturnMainMenuBtnOnClick()
    {
        mUIManager.PopPanel();
    }
}


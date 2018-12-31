using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginBackgroundUI:IBaseUI
{
    private Button mSingleGamebtn;
    private Button mLgoinBtn;
    private Button mRegistrationBtn;
    private Button mQuitBtn;

    public override void Init()
    {
        base.Init();

        mSingleGamebtn = UITools.FindChild<Button>(mUIRoot, "SingleModeBtn");
        mLgoinBtn = UITools.FindChild<Button>(mUIRoot, "LoginBtn");
        mRegistrationBtn = UITools.FindChild<Button>(mUIRoot, "RegistrationBtn");
        mQuitBtn = UITools.FindChild<Button>(mUIRoot, "QuitBtn");

        mSingleGamebtn.onClick.AddListener(SingleModeBtnOnClick);
        mLgoinBtn.onClick.AddListener(LoginBtnOnClick);
        mRegistrationBtn.onClick.AddListener(RegistrationBtnOnClick);
        mQuitBtn.onClick.AddListener(mQuitBtnOnClick);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        mUIRoot.SetActive(true);
    }
    /// <summary>
    /// UI暂定响应
    /// </summary>
    public override void OnPause()
    {
        base.OnPause();
        mSingleGamebtn.enabled = false;
        mLgoinBtn.enabled = false;
        mRegistrationBtn.enabled = false;
        mQuitBtn.enabled = false;
    }
    /// <summary>
    /// UI恢复响应
    /// </summary>
    public override void OnResume()
    {
        base.OnResume();
        mSingleGamebtn.enabled = true;
        mLgoinBtn.enabled = true;
        mRegistrationBtn.enabled = true;
        mQuitBtn.enabled = true;
    }
   
    private void SingleModeBtnOnClick()
    {
        PlayClickSound();
        mMainfacade.NoNetWorkMode();
    }

    /// <summary>
    /// 登录按钮点击事件
    /// </summary>
    private void LoginBtnOnClick()
    {
        PlayClickSound();
        mUIManager.PushPanel(UIPanelType.LoginUI);
    }
    /// <summary>
    /// 注册按钮点击事件
    /// </summary>
    private void RegistrationBtnOnClick()
    {
        PlayClickSound();
        mUIManager.PushPanel(UIPanelType.RegistrationUI);
    }
    /// <summary>
    /// 退出按钮点击事件
    /// </summary>
    private void mQuitBtnOnClick()
    {
        PlayClickSound();
        mMainfacade.QuitGame();
    }

}


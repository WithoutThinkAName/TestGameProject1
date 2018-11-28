using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginBackgroundUI:IBaseUI
{
    private Button mLgoinBtn;
    private Button mRegistrationBtn;
    private Button mQuitBtn;

    public override void Init()
    {
        base.Init();

        mLgoinBtn = UITools.FindChild<Button>(mUIRoot, "LoginBtn");
        mRegistrationBtn = UITools.FindChild<Button>(mUIRoot, "RegistrationBtn");
        mQuitBtn = UITools.FindChild<Button>(mUIRoot, "QuitBtn");

        mLgoinBtn.onClick.AddListener(LoginBtnOnClick);
        mRegistrationBtn.onClick.AddListener(RegistrationBtnOnClick);
        mQuitBtn.onClick.AddListener(mQuitBtnOnClick);
    }

    public override void OnEnter()
    {
        base.OnEnter();

        mUIRoot.SetActive(true);
    }

    public override void OnPause()
    {
        base.OnPause();
        mLgoinBtn.enabled = false;
        mRegistrationBtn.enabled = false;
        mQuitBtn.enabled = false;
    }

    public override void OnResume()
    {
        base.OnResume();
        mLgoinBtn.enabled = true;
        mRegistrationBtn.enabled = true;
        mQuitBtn.enabled = true;
    }

    public override void OnExit()
    {
        base.OnExit();

        mUIRoot.SetActive(false);
    }

    private void LoginBtnOnClick()
    {
        PlayClickSound();
        mUIManager.PushPanel(UIPanelType.LoginUI);
    }

    private void RegistrationBtnOnClick()
    {
        PlayClickSound();
        mUIManager.PushPanel(UIPanelType.RegistrationUI);
    }

    private void mQuitBtnOnClick()
    {
        PlayClickSound();
    }

}


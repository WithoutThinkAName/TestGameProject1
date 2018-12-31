using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuUI:IBaseUI
{
    private Transform mPlayerinfo;
    private Transform mButton_Mode1;
    private Transform mButton_Mode2;
    private Transform mButton_Mode3;
    private Transform mButton_Mode4;
    private Transform mButton_Mode5;
    private Transform mButton_Mode6;

    private Text mUserNameLab;
    private Button mMode1Btn;
    private Button mMode2Btn;
    private Button mMode3Btn;
    private Button mMode4Btn;
    private Button mMode5Btn;
    private Button mMode6Btn;
    private Button mQuit;
    
    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();

        mPlayerinfo = UITools.FindChild<Transform>(mUIRoot, "PlayerInfoUI");
        mButton_Mode1 = UITools.FindChild<Transform>(mUIRoot, "Button_Mode1");
        mButton_Mode2 = UITools.FindChild<Transform>(mUIRoot, "Button_Mode2");
        mButton_Mode3 = UITools.FindChild<Transform>(mUIRoot, "Button_Mode3");
        mButton_Mode4 = UITools.FindChild<Transform>(mUIRoot, "Button_Mode4");
        mButton_Mode5 = UITools.FindChild<Transform>(mUIRoot, "Button_Mode5");
        mButton_Mode6 = UITools.FindChild<Transform>(mUIRoot, "Button_Mode6");
        
        mUserNameLab = UITools.FindChild<Text>(mUIRoot, "UserNameLab");
        mMode1Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode1");
        mMode2Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode2");
        mMode3Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode3");
        mMode4Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode4");
        mMode5Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode5");
        mMode6Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode6");
        mQuit = UITools.FindChild<Button>(mUIRoot, "Button_Quit");

        mMode1Btn.onClick.AddListener(Mode1BtnOnClick);
        mMode2Btn.onClick.AddListener(Mode2BtnOnClick);
        mMode3Btn.onClick.AddListener(Mode3BtnOnClick);
        mMode4Btn.onClick.AddListener(Mode4BtnOnClick);
        mMode5Btn.onClick.AddListener(Mode5BtnOnClick);
        mMode6Btn.onClick.AddListener(Mode6BtnOnClick);
        mQuit.onClick.AddListener(mQuitBtnOnClick);

        //预留的按钮，暂时没用不显示
        mButton_Mode3.gameObject.SetActive(false);
        mButton_Mode4.gameObject.SetActive(false);
        mButton_Mode5.gameObject.SetActive(false);
        mButton_Mode6.gameObject.SetActive(false);
        

        

    }
    /// <summary>
    /// 进入时执行
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        if (mMainfacade.IsSingleMode==true)
        {
            mUserNameLab.text = "临时玩家";
        }
        else
        {
            mUserNameLab.text = mMainfacade.GetUserData().UserName;
        }
        
        EnterAnim();
    }
    /// <summary>
    /// UI进入动画
    /// </summary>
    private void EnterAnim()
    {
        mMode1Btn.enabled = true;
        mMode2Btn.enabled = true;
        mMode3Btn.enabled = true;
        mMode4Btn.enabled = true;
        mMode5Btn.enabled = true;
        mMode6Btn.enabled = true;

        mPlayerinfo.localPosition = new Vector3(-mScreenX / 5, mScreenY, 0);
        mButton_Mode1.localPosition = new Vector3(-mScreenX, mScreenY / 10 * 1, 0);
        mButton_Mode3.localPosition = new Vector3(-mScreenX, -mScreenY / 10 * 1, 0);
        mButton_Mode5.localPosition = new Vector3(-mScreenX, -mScreenY / 10 * 3, 0);

        mButton_Mode2.localPosition = new Vector3(mScreenX, mScreenY / 10 * 1, 0);
        mButton_Mode4.localPosition = new Vector3(mScreenX, -mScreenY / 10 * 1, 0);
        mButton_Mode6.localPosition = new Vector3(mScreenX, -mScreenY / 10 * 3, 0);

        mPlayerinfo.DOMoveY(mScreenY / 5 * 4, mAnimSpeed);
        mButton_Mode1.DOMoveX(mScreenX / 4, mAnimSpeed);
        mButton_Mode3.DOMoveX(mScreenX / 4, mAnimSpeed);
        mButton_Mode5.DOMoveX(mScreenX / 4, mAnimSpeed);        
        mButton_Mode2.DOMoveX(mScreenX / 4 * 3, mAnimSpeed);
        mButton_Mode4.DOMoveX(mScreenX / 4 * 3, mAnimSpeed);
        mButton_Mode6.DOMoveX(mScreenX / 4 * 3, mAnimSpeed);
        

        if (mMainfacade.IsSingleMode == true)
        {
            mMode2Btn.enabled = false;
            mMode4Btn.enabled = false;
            mMode6Btn.enabled = false;
        }
    }
    /// <summary>
    /// 继续执行
    /// </summary>
    public override void OnResume()
    {
        base.OnResume();

        EnterAnim();
    }
    /// <summary>
    /// 暂停执行
    /// </summary>
    public override void OnPause()
    {
        base.OnPause();
        HideAnim();
    }
    /// <summary>
    /// 退出时执行
    /// </summary>
    public override void OnExit()
    {
        HideAnim();
        base.OnExit();
    }
    /// <summary>
    /// 退出动画
    /// </summary>
    private void HideAnim()
    {
        mMode1Btn.enabled = false;
        mMode2Btn.enabled = false;
        mMode3Btn.enabled = false;
        mMode4Btn.enabled = false;
        mMode5Btn.enabled = false;
        mMode6Btn.enabled = false;


        mPlayerinfo.DOMoveY(mScreenY *1.5f, mAnimSpeed);

        mButton_Mode1.DOMoveX(-mScreenX / 2, mAnimSpeed);

        mButton_Mode3.DOMoveX(-mScreenX / 2, mAnimSpeed);

        mButton_Mode5.DOMoveX(-mScreenX / 2, mAnimSpeed);

        mButton_Mode4.DOMoveX(mScreenX * 1.5f, mAnimSpeed);

        mButton_Mode2.DOMoveX(mScreenX * 1.5f, mAnimSpeed);

        mButton_Mode6.DOMoveX(mScreenX * 1.5f, mAnimSpeed);

        
    }
    /// <summary>
    /// 模式1按钮点击事件
    /// 单人关卡模式
    /// </summary>
    private void Mode1BtnOnClick()
    {
        mUIManager.PushPanel(UIPanelType.MenuMode1UI);
        
    }
    /// <summary>
    /// 模式2按钮点击事件
    /// 网络模式
    /// </summary>
    private void Mode2BtnOnClick()
    {
        mUIManager.PushPanel(UIPanelType.MenuMode2UI);
    }
    /// <summary>
    /// 模式3按钮点击事件
    /// 未定义
    /// </summary>
    private void Mode3BtnOnClick()
    {

    }
    /// <summary>
    /// 模式4按钮点击事件
    /// 未定义
    /// </summary>
    private void Mode4BtnOnClick()
    {

    }
    /// <summary>
    /// 模式5按钮点击事件
    /// 未定义
    /// </summary>
    private void Mode5BtnOnClick()
    {

    }
    /// <summary>
    /// 模式6按钮点击事件
    /// 未定义
    /// </summary>
    private void Mode6BtnOnClick()
    {

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


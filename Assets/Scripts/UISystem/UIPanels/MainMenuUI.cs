using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuUI:IBaseUI
{
    private RectTransform mPlayerinfo;
    private RectTransform mButton_Mode1;
    private RectTransform mButton_Mode2;
    private RectTransform mButton_Mode3;
    private RectTransform mButton_Mode4;
    private RectTransform mButton_Mode5;
    private RectTransform mButton_Mode6;

    private Text mUserNameLab;
    private Button mMode1Btn;
    private Button mMode2Btn;
    private Button mMode3Btn;
    private Button mMode4Btn;
    private Button mMode5Btn;
    private Button mMode6Btn;

    private float mScreenX;
    private float mScreenY;

    private float mAnimSpeed;
    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();

        mPlayerinfo = UITools.FindChild<RectTransform>(mUIRoot, "PlayerInfoUI");
        mButton_Mode1 = UITools.FindChild<RectTransform>(mUIRoot, "Button_Mode1");
        mButton_Mode2 = UITools.FindChild<RectTransform>(mUIRoot, "Button_Mode2");
        mButton_Mode3 = UITools.FindChild<RectTransform>(mUIRoot, "Button_Mode3");
        mButton_Mode4 = UITools.FindChild<RectTransform>(mUIRoot, "Button_Mode4");
        mButton_Mode5 = UITools.FindChild<RectTransform>(mUIRoot, "Button_Mode5");
        mButton_Mode6 = UITools.FindChild<RectTransform>(mUIRoot, "Button_Mode6");
        
        mUserNameLab = UITools.FindChild<Text>(mUIRoot, "UserNameLab");
        mMode1Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode1");
        mMode2Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode2");
        mMode3Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode3");
        mMode4Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode4");
        mMode5Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode5");
        mMode6Btn = UITools.FindChild<Button>(mUIRoot, "Button_Mode6");


        mMode1Btn.onClick.AddListener(Mode1BtnOnClick);
        mMode2Btn.onClick.AddListener(Mode2BtnOnClick);
        mMode3Btn.onClick.AddListener(Mode3BtnOnClick);
        mMode4Btn.onClick.AddListener(Mode4BtnOnClick);
        mMode5Btn.onClick.AddListener(Mode5BtnOnClick);
        mMode6Btn.onClick.AddListener(Mode6BtnOnClick);


        //预留的按钮，暂时没用不显示
        mButton_Mode3.gameObject.SetActive(false);
        mButton_Mode4.gameObject.SetActive(false);
        mButton_Mode5.gameObject.SetActive(false);
        mButton_Mode6.gameObject.SetActive(false);

        mAnimSpeed = 0.2f;

        mScreenX = Screen.width;
        mScreenY = Screen.height;

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

        mPlayerinfo.localPosition = new Vector3(-mScreenX / 5, mScreenY / 2 + 200f, 0);
        mPlayerinfo.DOLocalMoveY(mScreenY / 10 * 3, mAnimSpeed);

        mButton_Mode1.localPosition = new Vector3(-1300, mScreenY / 10 * 1, 0);
        mButton_Mode1.DOLocalMoveX(-mScreenX / 4, mAnimSpeed);                

        mButton_Mode3.localPosition = new Vector3(-1300, -mScreenY / 10 * 1, 0);
        mButton_Mode3.DOLocalMoveX(-mScreenX / 4, mAnimSpeed);
       
        mButton_Mode5.localPosition = new Vector3(-1300, -mScreenY / 10 * 3, 0);
        mButton_Mode5.DOLocalMoveX(-mScreenX / 4, mAnimSpeed);


        mButton_Mode4.localPosition = new Vector3(1300, -mScreenY / 10 * 1, 0);
        mButton_Mode2.localPosition = new Vector3(1300, mScreenY / 10 * 1, 0);
        mButton_Mode6.localPosition = new Vector3(1300, -mScreenY / 10 * 3, 0);
        if (mMainfacade.IsSingleMode==false)
        {           
            mButton_Mode4.DOLocalMoveX(mScreenX / 4, mAnimSpeed);
            
            mButton_Mode2.DOLocalMoveX(mScreenX / 4, mAnimSpeed);
            
            mButton_Mode6.DOLocalMoveX(mScreenX / 4, mAnimSpeed);
        }   
    }
    /// <summary>
    /// 退出时执行
    /// </summary>
    public override void OnExit()
    {
        HideAnim();
    }
    /// <summary>
    /// 退出动画
    /// </summary>
    private void HideAnim()
    {

        mPlayerinfo.DOLocalMoveY(mScreenY / 2 + 200, 1f);
        
        mButton_Mode1.DOLocalMoveX(-1300, mAnimSpeed);
        
        mButton_Mode3.DOLocalMoveX(-1300, mAnimSpeed);
        
        mButton_Mode5.DOLocalMoveX(-1300, mAnimSpeed).OnComplete(() => base.OnExit());

        if (mMainfacade.IsSingleMode == false)
        {
            mButton_Mode4.DOLocalMoveX(1300, mAnimSpeed);
            
            mButton_Mode2.DOLocalMoveX(1300, mAnimSpeed);
            
            mButton_Mode6.DOLocalMoveX(1300, mAnimSpeed);
        }
    }
    /// <summary>
    /// 模式1按钮点击事件
    /// 单人关卡模式
    /// </summary>
    private void Mode1BtnOnClick()
    {
        mMainfacade.EnterMode1State();
    }
    /// <summary>
    /// 模式2按钮点击事件
    /// 网络模式
    /// </summary>
    private void Mode2BtnOnClick()
    {

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
}


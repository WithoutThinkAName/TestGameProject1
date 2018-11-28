using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Common;


public class RegistrationUI:IBaseUI
{
    private InputField mUserNameInput;
    private InputField mUserPasswordInput;
    private InputField mReUserPasswordInput;
    private Button mRegistrationBtn;
    private Button mCloseBtn;
    private Animator mAnim;

    private RegistrationRequest mRegistrationRequest;
    /// <summary>
    /// UI初始化
    /// </summary>
    public override void Init()
    {
        base.Init();

        mUserNameInput = UITools.FindChild<InputField>(mUIRoot, "UserNameInput");
        mUserPasswordInput = UITools.FindChild<InputField>(mUIRoot, "PasswordInput");
        mReUserPasswordInput = UITools.FindChild<InputField>(mUIRoot, "RePasswordInput");
        mRegistrationBtn = UITools.FindChild<Button>(mUIRoot, "RegistrationBtn2");
        mCloseBtn = UITools.FindChild<Button>(mUIRoot, "CloseBtn");
        mAnim = GetComponent<Animator>();
        
        mRegistrationBtn.onClick.AddListener(RegistrationBtnOnClick);
        mCloseBtn.onClick.AddListener(CloseBtnOnClick);

        mRegistrationRequest = GetComponent<RegistrationRequest>();
    }

    /// <summary>
    /// 窗口显示前执行
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        mUserNameInput.text = "";
        mUserPasswordInput.text = "";
        mReUserPasswordInput.text = "";

        mUIRoot.SetActive(true);
        mAnim.Play("PanelAppear");
    }
    /// <summary>
    /// 窗口关闭前执行
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        //mAnim.Play("PanelDisappear");
        //Invoke("Hide", 0.3f);
        Hide();
    }


    /// <summary>
    /// 注册按钮事件
    /// </summary>
    private void RegistrationBtnOnClick()
    {
        PlayClickSound();
        string msg = "";
        if (string.IsNullOrEmpty(mUserNameInput.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(mUserPasswordInput.text))
        {
            msg += "密码不能为空 ";
        }
        if (string.IsNullOrEmpty(mReUserPasswordInput.text))
        {
            msg += "重复输入密码不能为空 ";
        }
        if (msg != "")
        {
            mUIManager.ShowMessageUI(msg);
            return;
        }
        Debug.Log("注册请求：" + mUserNameInput.text + "-" + mUserPasswordInput.text);
        mRegistrationRequest.SendRequest(mUserNameInput.text, mUserPasswordInput.text);
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    private void CloseBtnOnClick()
    {
        PlayClickSound();
        mUIManager.PopPanel();
    }

    public void OnRegistrationResponse(ReturnCode returnCode)
    {
        Debug.Log(returnCode);
        if (returnCode == ReturnCode.Success)
        {
            mUIManager.ShowMessageUIAsyn("注册成功");
        }
        else
        {
            mUIManager.ShowMessageUIAsyn("用户名重复无法使用");
        }
    }



}


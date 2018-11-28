using UnityEngine;
using UnityEngine.UI;
using Common;

public class LoginUI:IBaseUI
{
    private InputField mUserNameInput;
    private InputField mUserPasswordInput;
    private Button mLoginBtn;
    private Button mRegistrationBtn;
    private Button mCloseBtn;
    private Animator mAnim;

    private LoginRequest mLoginRequest;

    /// <summary>
    /// UI初始化
    /// </summary>
    public override void Init()
    {
        base.Init();

        mUserNameInput = UITools.FindChild<InputField>(mUIRoot, "NameInput");
        mUserPasswordInput = UITools.FindChild<InputField>(mUIRoot, "PasswordInput");
        mLoginBtn = UITools.FindChild<Button>(mUIRoot, "LoginBtn2");
        mRegistrationBtn = UITools.FindChild<Button>(mUIRoot, "RegistrationBtn1.5");
        mCloseBtn = UITools.FindChild<Button>(mUIRoot, "CloseBtn");
        mAnim = GetComponent<Animator>();

        mLoginBtn.onClick.AddListener(LoginBtnOnClick);
        mRegistrationBtn.onClick.AddListener(RegistrationBtnOnClick);
        mCloseBtn.onClick.AddListener(CloseBtnOnClick);

        mLoginRequest = GetComponent<LoginRequest>();

    }

    /// <summary>
    /// 窗口显示前执行
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        mUserNameInput.text = "";
        mUserPasswordInput.text = "";

        mUIRoot.SetActive(true);
        mAnim.Play("PanelAppear");

    }
    /// <summary>
    /// 窗口关闭前执行
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        Hide();
    }

    
    /// <summary>
    /// 登录按钮执行
    /// </summary>
    private void LoginBtnOnClick()
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
        if (msg!="")
        {
            mUIManager.ShowMessageUI(msg);
            return;
        }
        Debug.Log("登陆请求："+ mUserNameInput.text +"-"+ mUserPasswordInput.text);
        mLoginRequest.SendRequest(mUserNameInput.text, mUserPasswordInput.text);
    }

    public void OnLoginResponse(ReturnCode returnCode)
    {
        PlayClickSound();
        Debug.Log(returnCode);
        if (returnCode==ReturnCode.Success)
        {
            mUIManager.ShowMessageUIAsyn("登录成功");
        }
        else
        {
            mUIManager.ShowMessageUIAsyn("用户名密码错误，无法登陆，请重新输入");
        }
    }

    /// <summary>
    /// 显示注册UI
    /// </summary>
    private void RegistrationBtnOnClick()
    {
        mUIManager.PushPanel(UIPanelType.RegistrationUI);
    }
    /// <summary>
    /// 关闭窗口
    /// </summary>
    private void CloseBtnOnClick()
    {
        PlayClickSound();
        mUIManager.PopPanel();
    }
   

}


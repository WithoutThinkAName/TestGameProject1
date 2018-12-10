using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

/// <summary>
/// 处理登录请求
/// </summary>
public class LoginRequest:BaseRequest
{
    private LoginUI mLoginUI;//登录UI

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Awake()
    {
        mRequestCode = RequestCode.User;
        mActionCode = ActionCode.Login;
        mLoginUI = GetComponent<LoginUI>();
        base.Awake();
    }
    /// <summary>
    /// 发送登录请求
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public void SendRequest(string username,string password)
    {
        string data = username + "," + password;
        base.SendRequest(data);
    }
    /// <summary>
    /// 登录请求服务器反馈
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string data)
    {
        string[] strs = data.Split(',');
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        mLoginUI.OnLoginResponse(returnCode);

        if (returnCode==ReturnCode.Success)
        {
            string userName = strs[1];
            int totalCount = int.Parse(strs[2]);
            int winCount = int.Parse(strs[3]);
            UserInfo userInfo = new UserInfo(userName, totalCount, winCount);
            mMainFacade.LoginSuccess(userInfo);
        }
    }
}


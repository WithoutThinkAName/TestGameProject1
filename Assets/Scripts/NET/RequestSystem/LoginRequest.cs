using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

public class LoginRequest:BaseRequest
{
    private LoginUI mLoginUI;

    public override void Awake()
    {
        mRequestCode = RequestCode.User;
        mActionCode = ActionCode.Login;
        mLoginUI = GetComponent<LoginUI>();
        base.Awake();
    }

    public void SendRequest(string username,string password)
    {
        string data = username + "," + password;
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        ReturnCode returnCode = (ReturnCode)int.Parse(data);
        mLoginUI.OnLoginResponse(returnCode);
    }
}


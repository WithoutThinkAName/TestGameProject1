using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;


public class RegistrationRequest:BaseRequest
{
    private RegistrationUI mRegistrationUI;

    public override void Awake()
    {
        mRequestCode = RequestCode.User;
        mActionCode = ActionCode.Register;
        mRegistrationUI = GetComponent<RegistrationUI>();


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
        mRegistrationUI.OnRegistrationResponse(returnCode);

    }


}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class UserInfo
{
    public UserInfo(string userName,int totalCount,int WinCount)
    {
        this.UserName = userName;
        this.TotalCount = totalCount;
        this.WinCount = WinCount;
    }

    public string UserName { get;private set; }
    public int TotalCount { get; private set; }
    public int WinCount { get; private set; }


}


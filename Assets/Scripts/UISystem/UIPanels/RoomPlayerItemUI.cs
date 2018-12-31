using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 房间内的玩家信息UI
/// </summary>
public class RoomPlayerItemUI : IBaseUI
{
    private UserInfo mUser;
    public Text mPlayerInfo;

    public void SetPlayerInfo(UserInfo user)
    {
        mUser = user;
        mPlayerInfo.text = string.Format("{0,-30}-胜率：{1}%", user.UserName, user.TotalCount == 0 ? 0 : (float)user.WinCount / user.TotalCount);
        
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }
}


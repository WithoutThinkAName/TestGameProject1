using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

public class RoomListRequest : BaseRequest
{
    private MenuMode2UI mMode2UI;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Awake()
    {
        mRequestCode = RequestCode.Room;
        mActionCode = ActionCode.RoomList;
        mMode2UI = GetComponent<MenuMode2UI>();
        base.Awake();
    }

    /// <summary>
    /// 发送房间列表信息请求
    /// </summary>
    public override void SendRequest()
    {
        base.SendRequest("rl");
    }

    /// <summary>
    /// 服务器反馈数据
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string data)
    {
        if (data == "0")
        {
            mMode2UI.LoadRoomListAsyn(null);
            return;
        }
        List<RoomInfo> userList = new List<RoomInfo>();
        
        string[] roomArray = data.Split('|');
        foreach (string roomData in roomArray)
        {
            string[] strs = roomData.Split('.');
            userList.Add(new RoomInfo(int.Parse(strs[0]), strs[1], int.Parse(strs[2]), int.Parse(strs[3])));
        }
        mMode2UI.LoadRoomListAsyn(userList);
    }


}


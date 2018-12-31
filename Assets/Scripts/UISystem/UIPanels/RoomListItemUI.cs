using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 房间列表的房间UI
/// </summary>
public class RoomListItemUI:IBaseUI
{
    private MenuMode2UI mMode2UI;
    private RoomInfo mRoom;
    public Text mRoomInfoLab;
    public Button mJoinBtn;

    public void SetRoomInfo( MenuMode2UI mode2UI,RoomInfo room)
    {
        mMode2UI = mode2UI;
        mRoom = room;

        mRoomInfoLab.text = string.Format("{0,-30}({1}人)", mRoom.RoomName,mRoom.PlayerCount);

        if (mJoinBtn!=null)
        {
            mJoinBtn.onClick.AddListener(JoinBtnOnClick);
        }
    }

    private void JoinBtnOnClick()
    {
        Debug.Log("加入按钮点击");
        mMode2UI.JoinRoomOnClick(mRoom.RoomID);
    }

    public void DestorySelf()
    {
        Destroy(gameObject);
    }
}


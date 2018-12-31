using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class RoomInfo
{
    public RoomInfo(int id,string name,int limit,int count)
    {
        RoomID = id;
        RoomName = name;
        RoomLimit = limit;
        PlayerCount = count;
    }
    
    public int RoomID { get; private set; }
    public string RoomName { get; private set; }
    public int PlayerCount { get; private set; }
    public int RoomLimit { get; private set; }
    public List<UserInfo> Players { get; private set; }

    public void SetPlayersInThisRoom(List<UserInfo> users)
    {
        Players = users;
        PlayerCount = Players.Count;
    }

}


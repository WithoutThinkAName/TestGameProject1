using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class PlayerSystem : IGameSystem
{
    private UserInfo mUserData;
    public UserInfo UserData { get { return mUserData; } set { mUserData = value; } }

    private RoomInfo mCurrentRoom;
    public RoomInfo CurrentRoom { get { return mCurrentRoom; } set { mCurrentRoom = value; } }



}


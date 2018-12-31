using UnityEngine;
using Common;


public class UpdateRoomRequest:BaseRequest
{
    private MenuMode2UI mMode2UI;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Awake()
    {
        mRequestCode = RequestCode.Room;
        mActionCode = ActionCode.RoomUpdate;
        mMode2UI = GetComponent<MenuMode2UI>();
        base.Awake();
    }

    /// <summary>
    /// 服务器反馈
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string data)
    {
        RoomInfo room = mMode2UI.HandleRoomData(data);
        mMainFacade.SetCurrentRoom(room);
        mMode2UI.RefreshRoomPlayersAsyn(room);
    }    
}


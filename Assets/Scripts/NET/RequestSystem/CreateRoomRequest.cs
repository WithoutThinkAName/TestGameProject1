using UnityEngine;
using Common;

/// <summary>
/// 处理房间创建
/// </summary>
public class CreateRoomRequest : BaseRequest
{
    private MenuMode2UI mMode2UI;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Awake()
    {
        mRequestCode = RequestCode.Room;
        mActionCode = ActionCode.RoomCreate;
        mMode2UI = GetComponent<MenuMode2UI>();
        base.Awake();
    }
    /// <summary>
    /// 发送创建房间请求
    /// </summary>
    public new void SendRequest(string data)
    {
        base.SendRequest(data);
    }
    /// <summary>
    /// 服务器反馈
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string data)
    {
        string[] strs = data.Split('|');        
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        Debug.Log("创建房间："+returnCode);

        if (returnCode == ReturnCode.Success)
        {
            RoomInfo room = mMode2UI.HandleRoomData(strs[1]);
            mMainFacade.SetCurrentRoom(room);
            mMode2UI.EnterRoomAsyn(room);
        }
    }    
}


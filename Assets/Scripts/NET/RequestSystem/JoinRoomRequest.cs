using UnityEngine;
using Common;

public class JoinRoomRequest:BaseRequest
{
    private MenuMode2UI mMode2UI;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Awake()
    {
        mRequestCode = RequestCode.Room;
        mActionCode = ActionCode.RoomJoin;
        mMode2UI = GetComponent<MenuMode2UI>();
        base.Awake();
    }

    /// <summary>
    /// 发送加入房间请求
    /// </summary>
    public new void SendRequest(string roomID)
    {
        base.SendRequest(roomID);
    }

    /// <summary>
    /// 服务器反馈
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string data)
    {
        string[] strs = data.Split('|');
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        Debug.Log("加入房间：" + returnCode);
        switch (returnCode)
        {
            case ReturnCode.Success:
                RoomInfo room= mMode2UI.HandleRoomData(strs[1]);
                mMainFacade.SetCurrentRoom(room);
                mMode2UI.EnterRoomAsyn(room);
                mMainFacade.ShowMessageUI("加入成功");
                break;
            case ReturnCode.Fail:
                mMainFacade.ShowMessageUI("加入失败");
                break;
            case ReturnCode.NotFound:
                mMainFacade.ShowMessageUI("房间不存在");
                break;
            default:
                break;
        }       
    }
}


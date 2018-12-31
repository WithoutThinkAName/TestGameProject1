using UnityEngine;
using Common;

public class ExitRoomRequest:BaseRequest
{
    private MenuMode2UI mMode2UI;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Awake()
    {
        mRequestCode = RequestCode.Room;
        mActionCode = ActionCode.RoomExit;
        mMode2UI = GetComponent<MenuMode2UI>();
        base.Awake();
    }

    /// <summary>
    /// 发送加入房间请求
    /// </summary>
    public override void SendRequest()
    {
        base.SendRequest("e");
    }

    /// <summary>
    /// 服务器反馈
    /// </summary>
    /// <param name="data"></param>
    public override void OnResponse(string data)
    {
        string[] strs = data.Split('|');
        ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
        Debug.Log("退出房间：" + returnCode);
        mMode2UI.ReturnRoomListAsyn();
    }
}


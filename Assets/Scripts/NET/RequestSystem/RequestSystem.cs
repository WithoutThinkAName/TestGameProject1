using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

public class RequestSystem:IGameSystem
{

    private Dictionary<ActionCode, BaseRequest> mRequestDict = new Dictionary<ActionCode, BaseRequest>();

    public override void Init()
    {
        base.Init();
    }


    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        mRequestDict.Add(actionCode, request);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        if (mRequestDict.ContainsKey(actionCode)==false)
        {
            Debug.Log("要删除的Request不存在：[" + actionCode + "]");
            return;
        }
        else
        {
            mRequestDict.Remove(actionCode);
        }
        
    }

    public void HandleRequest(ActionCode actionCode, string data)
    {
        BaseRequest request = mRequestDict.TryGet<ActionCode, BaseRequest>(actionCode);
        if (request == null)
        {
            Debug.Log("无法取得ActionCode：[" + actionCode + "]");
            return;
        }
        request.OnResponse(data);
    }

}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

public class RequestSystem:IGameSystem
{
    private Dictionary<RequestCode, BaseRequest> mRequestDict = new Dictionary<RequestCode, BaseRequest>();




    public void AddRequest(RequestCode requestCode, BaseRequest request)
    {
        mRequestDict.Add(requestCode, request);
    }

    public void RemoveRequest(RequestCode requestCode)
    {
        if (mRequestDict.ContainsKey(requestCode)==false)
        {
            Debug.Log("要删除的Request不存在：[" + requestCode + "]");
            return;
        }
        else
        {
            mRequestDict.Remove(requestCode);
        }
        
    }

    public void HandleRequest(RequestCode requestCode,string data)
    {
        BaseRequest request = mRequestDict.TryGet<RequestCode, BaseRequest>(requestCode);
        if (request == null)
        {
            Debug.Log("无法取得Request：[" + requestCode + "]");
            return;
        }
        request.OnRequest(data);
    }

}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

/// <summary>
/// 请求处理系统
/// </summary>
public class RequestSystem:IGameSystem
{
    //请求类型字典
    private Dictionary<ActionCode, BaseRequest> mRequestDict = new Dictionary<ActionCode, BaseRequest>();
    
    /// <summary>
    /// 添加请求类型
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="request"></param>
    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        mRequestDict.Add(actionCode, request);
    }
    /// <summary>
    /// 移除请求类型
    /// </summary>
    /// <param name="actionCode"></param>
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
    /// <summary>
    /// 处理请求
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
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


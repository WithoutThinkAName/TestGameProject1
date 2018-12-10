using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

/// <summary>
/// 服务器请求基类
/// </summary>
public class BaseRequest:MonoBehaviour  {
    
    protected RequestCode mRequestCode=RequestCode.None;
    protected ActionCode mActionCode=ActionCode.None;
    protected GameMainFacade mMainFacade;
    
    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Awake()
    {
        mMainFacade = GameMainFacade.Instance;
        GameMainFacade.Instance.AddRequest(mActionCode, this);
    }
    /// <summary>
    /// 向服务器发送
    /// </summary>
    /// <param name="data"></param>
    protected void SendRequest(string data)
    {
        mMainFacade.SendRequest(mRequestCode, mActionCode, data);
    }


    public virtual void SendRequest() { }
    public virtual void OnResponse(string data) { }


    public virtual void OnDestory()
    {
        GameMainFacade.Instance.RemoveRequest(mActionCode);
    }
}

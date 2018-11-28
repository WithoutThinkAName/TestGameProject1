using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class BaseRequest:MonoBehaviour  {
    
    protected RequestCode mRequestCode=RequestCode.None;
    protected ActionCode mActionCode=ActionCode.None;
    protected GameMainFacade mMainFacade;

   

    public virtual void Awake()
    {
        mMainFacade = GameMainFacade.Instance;
        GameMainFacade.Instance.AddRequest(mActionCode, this);
    }

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

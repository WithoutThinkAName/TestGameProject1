using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class BaseRequest  {
    
    protected RequestCode mRequestCode;
    

    public virtual void SendRequest() { }
    public virtual void OnRequest(string data) { }

}

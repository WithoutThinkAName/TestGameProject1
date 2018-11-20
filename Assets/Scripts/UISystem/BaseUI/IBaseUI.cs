using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 全部UI类的基本类
/// </summary>
public abstract class IBaseUI
{
    protected GameFacade mFacade;//中介者
    public GameObject mUIRoot;//当前UI的根位置
    
    /// <summary>
    /// UI初始化方法
    /// </summary>
    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }
    /// <summary>
    /// UI每帧运行方法
    /// </summary>
    public virtual void Update() { }
    /// <summary>
    /// UI释放方法
    /// </summary>
    public virtual void Release() { }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关闭
    /// </summary>
    public virtual void OnExit()
    {

    }





    /// <summary>
    /// 当前UI显示方法
    /// </summary>
    protected void Show()
    {
        mUIRoot.SetActive(true);
    }
    /// <summary>
    /// 当前UI隐藏方法
    /// </summary>
    protected void Hide()
    {
        mUIRoot.SetActive(false);
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 组件：兵营游戏物体点击事件
/// </summary>
public class CampOnClick:MonoBehaviour
{
    private ICamp mCamp;//兵营对象
    /// <summary>
    /// 设置兵营对象
    /// </summary>
    public ICamp camp { set { mCamp = value; } }
    /// <summary>
    /// 鼠标点击
    /// </summary>
    void OnMouseUpAsButton()
    {
        //Debug.Log(gameObject.name);
        ShowCampInfo();
    }
    /// <summary>
    /// 显示信息面板UI
    /// </summary>
    public void ShowCampInfo()
    {
        GameStageFacade.Instance.ShowCampInfo(mCamp);
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 组件：士兵游戏物体点击事件
/// </summary>
public class SoldierOnClick:MonoBehaviour
{
    private ISoldier mSoldier;//士兵对象
    /// <summary>
    /// 设置士兵对象
    /// </summary>
    public ISoldier soldier { set { mSoldier = value; } }
    /// <summary>
    /// 显示士兵信息面板
    /// </summary>
    void OnMouseUpAsButton()
    {
        //Debug.Log(gameObject.name);
        GameFacade.Instance.ShowSoldierInfo(mSoldier);
    }
}
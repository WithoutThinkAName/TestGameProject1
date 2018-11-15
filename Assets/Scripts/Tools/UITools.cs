using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 工具类：UI
/// </summary>
public static class UITools
{
    /// <summary>
    /// 根据名字获取UI根位置游戏物体
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static GameObject GetCanvas(string name = "Canvas")
    {
        return GameObject.Find(name);
    }
    /// <summary>
    /// 根据类型和名称，获取根游戏物体下指定名称子物体上的指定类型组件
    /// </summary>
    /// <typeparam name="T">查询组件类型</typeparam>
    /// <param name="parent">根游戏物体</param>
    /// <param name="childName">组件所在游戏物体名称</param>
    /// <returns>指定类型组件</returns>
    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject uiGO = UnityTool.FindChildByName(parent, childName);
        if (uiGO == null)
        {
            Debug.LogError("无法在物体" + parent + "下找到子物体" + childName); 
            return default(T);
        }
        return uiGO.GetComponent<T>();
    }
}


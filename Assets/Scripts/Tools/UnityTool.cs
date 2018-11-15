using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 工具类：游戏物体
/// </summary>
public static class UnityTool
{

    /// <summary>
    /// 按名称查找子物体并返回
    /// </summary>
    /// <param name="parent">父游戏物体</param>
    /// <param name="childName">子物体名称</param>
    /// <returns>子游戏物体</returns>
    public static GameObject FindChildByName(GameObject parent,string childName)
    {
        Transform[] children= parent.GetComponentsInChildren<Transform>();
        bool isFinded = false;
        Transform child = null;
        foreach (Transform t in children)
        {
            if (t.name==childName)
            {
                if (isFinded)
                {
                    Debug.LogWarning("查找的目标子物体[" + childName + "]不止一个");
                }
                isFinded = true;
                child = t;
            }
        }
        return child==null? null:child.gameObject;
    }
    /// <summary>
    /// 将物体挂载到某物体上成为子物体并reset
    /// </summary>
    /// <param name="parent">成为父物体的游戏物体</param>
    /// <param name="child">成为子物体的游戏物体</param>
    public static void Attach(GameObject parent,GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localEulerAngles = Vector3.zero;
    }

}


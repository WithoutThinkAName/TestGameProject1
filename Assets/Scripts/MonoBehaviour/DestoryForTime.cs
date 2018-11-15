using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 组件：人物游戏物体延迟销毁
/// 死亡动画预留时间
/// </summary>
public class DestoryForTime:MonoBehaviour
{
    private float time = 1;//销毁时间
    /// <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        Invoke("Destory", time);
    }
    /// <summary>
    /// 销毁
    /// </summary>
    void Destory()
    {
        GameObject.Destroy(this.gameObject);
    }
}


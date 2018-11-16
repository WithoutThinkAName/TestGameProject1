using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 屏幕系统
/// 处理画面移动、缩放
/// </summary>
public class ScreenSystem:IGameSystem
{
    protected IScreenHandler mScreenHandler;//屏幕处理器

    public const float LIMIT_ScreenX = 30f;//摄像机X轴移动限制
    public const float LIMIT_ScreenY = 30f;//摄像机Y轴移动限制
    public const float LIMIT_ScreenZ = 20f;//摄像机Z轴移动限制


    protected float mScreenMoveRateX = 0.1f;//X轴速率
    protected float mScreenMoveRateZ = 0.1f;//Y轴速率
    protected float mScreenScaleChangeRate = 1f;//缩放速率


    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();


#if UNITY_EDITOR

        Debug.Log("UNITY_EDITOR");
        mScreenHandler = new WindowsScreenHandler(mScreenMoveRateX, mScreenMoveRateZ, mScreenScaleChangeRate);

#elif UNITY_STANDALONE_WIN

        Debug.Log("UNITY_STANDALONE_WIN");
        mScreenHandler = new WindowsScreenHandler(mScreenMoveRateX, mScreenMoveRateZ, mScreenScaleChangeRate);

#elif UNITY_ANDROID

        Debug.Log("UNITY_ANDROID");
        mScreenHandler = new AndroidScreenHandler(mScreenMoveRateX, mScreenMoveRateZ, mScreenScaleChangeRate);

//#elif UNITY_IPHONE

//        Debug.Log("UNITY_IPHONE");

#endif

    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public override void Update()
    {
        base.Update();
        UpgradeScreenHandle();
    }
    /// <summary>
    /// 更新屏幕
    /// </summary>
    private void UpgradeScreenHandle()
    {
        mScreenHandler.ScreenMove();
        mScreenHandler.ChangeScreenScale();
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 屏幕画面处理器
/// </summary>
public abstract class IScreenHandler
{
    protected Camera mMainCamera;//主摄像机

    protected float mScreenMoveRateX;//X轴速率
    protected float mScreenMoveRateZ;//Z轴速率
    protected float mScreenScaleChangeRate;//缩放速率

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="screenMoveRateX">X轴移动速率</param>
    /// <param name="screenMoveRateZ">Y轴移动速率</param>
    /// <param name="screenScaleChangeRate">缩放速率</param>
    public IScreenHandler(float screenMoveRateX, float screenMoveRateZ, float screenScaleChangeRate )
    {
        mMainCamera = Camera.main;
        mScreenMoveRateX = screenMoveRateX;
        mScreenMoveRateZ = screenMoveRateZ;
        mScreenScaleChangeRate = screenScaleChangeRate;
    }

    /// <summary>
    /// 屏幕平移子类实现
    /// </summary>
    public abstract void ScreenMove();
    /// <summary>
    /// 屏幕缩放子类实现
    /// </summary>
    public abstract void ChangeScreenScale();

   
    /// <summary>
    /// 摄像机水平面移动实现主体
    /// </summary>
    /// <param name="moveDis"></param>
    public void CameraMove(Vector2 moveDis)
    {
        mMainCamera.transform.Translate(new Vector3(moveDis.x * mScreenMoveRateX,0, moveDis.y * mScreenMoveRateZ),Space.World);
        CheckCameraHandle();
    }
    /// <summary>
    /// 摄像机画面缩放实现主体
    /// </summary>
    /// <param name="rate"></param>
    public void CameraScale(float flag)
    {
        mMainCamera.transform.Translate(Vector3.forward * flag* mScreenScaleChangeRate,Space.Self);

        CheckCameraHandle();
    }
    /// <summary>
    /// 控制摄像机移动范围
    /// </summary>
    private void CheckCameraHandle()
    {
        Vector3 checkPositon = mMainCamera.transform.position;
        if (Mathf.Abs(checkPositon.x)>ScreenSystem.LIMIT_ScreenX)
        {
            checkPositon.x = ScreenSystem.LIMIT_ScreenX * (Mathf.Abs(checkPositon.x) / checkPositon.x);
        }
        if(Mathf.Abs(checkPositon.z) > ScreenSystem.LIMIT_ScreenZ)
        {
            checkPositon.z = ScreenSystem.LIMIT_ScreenZ * (Mathf.Abs(checkPositon.z) / checkPositon.z);
        }
        if(checkPositon.y>ScreenSystem.LIMIT_ScreenY)
        {
            checkPositon.y = ScreenSystem.LIMIT_ScreenY;
        }
        if(checkPositon.y < ScreenSystem.LIMIT_ScreenY-10f)
        {
            checkPositon.y = ScreenSystem.LIMIT_ScreenY-10f;
        }
        mMainCamera.transform.position = checkPositon;
    }
}


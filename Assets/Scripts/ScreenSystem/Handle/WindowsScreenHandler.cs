using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 屏幕画面处理：windows
/// </summary>
public class WindowsScreenHandler : IScreenHandler
{
    private Vector2 mOldPoint1;//数据点1
    private Vector2 mOldPoint2;//数据点2

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="screenMoveRateX"></param>
    /// <param name="screenMoveRateY"></param>
    /// <param name="screenScaleChangeRate"></param>
    public WindowsScreenHandler(float screenMoveRateX, float screenMoveRateY, float screenScaleChangeRate) : base(screenMoveRateX, screenMoveRateY, screenScaleChangeRate)
    {
    }
    /// <summary>
    /// 屏幕缩放
    /// </summary>
    public override void ChangeScreenScale()
    {
        float scaleFlag = Input.GetAxis("Mouse ScrollWheel");
        if (scaleFlag == 0)
        {
            return;            
        }
        else 
        {
            CameraScale(Mathf.Abs(scaleFlag) / scaleFlag);
        }
    }
    /// <summary>
    /// 屏幕平移
    /// </summary>
    public override void ScreenMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
           mOldPoint1 = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mOldPoint2 = Input.mousePosition;
            CameraMove(mOldPoint1-mOldPoint2);
            mOldPoint1 = mOldPoint2;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 生命系统
/// 统计关卡生命值，判断关卡失败条件
/// </summary>
public class HeartSystem:IGameSystem
{
    private const int MAX_HEART = 3;//最大心数

    private int mNowHeart= MAX_HEART;//目前心数

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
    }
    /// <summary>
    /// 心数减少
    /// 游戏失败判定
    /// </summary>
    public void ReduceHeart()
    {
        mNowHeart--;
        mMode1Facade.UpdateHeartCount(mNowHeart);

        if (mNowHeart<=0)
        {
            mMainFacade.ShowUIPanel(UIPanelType.GameOverUI);
        }
    }

}


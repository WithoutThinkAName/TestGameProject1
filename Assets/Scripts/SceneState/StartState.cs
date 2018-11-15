using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// 开始游戏状态类
/// </summary>
public class StartState:ISceneState
{
    public StartState(SceneStateController controller) : base("01StartScene", controller) { }

    private Text mLogo;//标题文字or图片
    private float mSmoothingSpeed = 0.5f;//标题效果切换速率
    private float mWaitTime = 2f;//开始状态持续事件
    /// <summary>
    /// 初始化
    /// </summary>
    public override void StateStart()
    {
        mLogo = GameObject.Find("LogoText").GetComponent<Text>();
        mLogo.color = Color.white;
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.black, mSmoothingSpeed*Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if (mWaitTime<=0)
        {
            mController.SetState(new MainMenuState(mController));
        }
    }
}


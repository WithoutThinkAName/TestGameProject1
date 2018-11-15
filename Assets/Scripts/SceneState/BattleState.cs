using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏战斗关卡状态类
/// </summary>
public class BattleState : ISceneState {

	public BattleState(SceneStateController controller) : base("03BattleScene", controller) { }
    /// <summary>
    /// 初始化游戏关卡
    /// </summary>
    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }
    /// <summary>
    /// 释放游戏关卡
    /// </summary>
    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }
    /// <summary>
    /// 战斗关卡状态运行
    /// </summary>
    public override void StateUpdate()
    {
        if (GameFacade.Instance.isGameOver==true)
        {
            mController.SetState(new MainMenuState(mController));
        }
        GameFacade.Instance.Update();
    }
}

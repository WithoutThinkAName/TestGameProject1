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
        base.StateStart();
        GameStageFacade.Instance.InitStage();
    }
    /// <summary>
    /// 释放游戏关卡
    /// </summary>
    public override void StateEnd()
    {
        base.StateEnd();
        GameStageFacade.Instance.ReleaseStage();
    }
    /// <summary>
    /// 战斗关卡状态运行
    /// </summary>
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (GameStageFacade.Instance.isGameOver==true)
        {
            StateEnd();
            mController.SetState(new MainMenuState(mController));
        }
        GameStageFacade.Instance.UpdateStage();
    }
}

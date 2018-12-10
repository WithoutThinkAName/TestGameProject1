using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏战斗关卡状态类
/// </summary>
public class Mode1BattleState : ISceneState {

	public Mode1BattleState(SceneStateController controller) : base("03Mode1BattleScene", controller) { }
    /// <summary>
    /// 初始化游戏关卡
    /// </summary>
    public override void StateStart()
    {
        base.StateStart();
        GameMode1Facade.Instance.InitStage();
        mMainFacade.ShowUIPanel(UIPanelType.GameMode1UI);
    }
    /// <summary>
    /// 释放游戏关卡
    /// </summary>
    public override void StateEnd()
    {
        base.StateEnd();
        GameMode1Facade.Instance.ReleaseStage();
    }
    /// <summary>
    /// 战斗关卡状态运行
    /// </summary>
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (GameMode1Facade.Instance.isGameOver==true)
        {
            StateEnd();
            mController.SetState(new MainMenuState(mController));
        }
        GameMode1Facade.Instance.UpdateStage();
    }
}

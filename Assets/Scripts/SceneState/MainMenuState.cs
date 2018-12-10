using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏主菜单状态类
/// </summary>
public class MainMenuState : ISceneState {

	public MainMenuState(SceneStateController controller) : base("02MainMenuScene", controller) { }
   
    /// <summary>
    /// 初始化主菜单状态
    /// </summary>
    public override void StateStart()
    {
        base.StateStart();
        GameMode1Facade.Instance.SetIsGameOver(false);
        mMainFacade.ShowUIPanel(UIPanelType.MainMenuUI);
    }

    

   
}

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
        GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
        GameFacade.Instance.SetIsGameOver(false);
    }
    /// <summary>
    /// 游戏开始按钮事件监听
    /// </summary>
    private void OnStartButtonClick()
    {
        mController.SetState(new BattleState(mController));
    }
}

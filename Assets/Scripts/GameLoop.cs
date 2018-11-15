using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏运行管理类
/// 尝试：
///     组件与游戏物体分离式开发
/// </summary>
public class GameLoop : MonoBehaviour {

    private SceneStateController controller;//场景状态控制器
    /// <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	/// <summary>
    /// 初始化控制器并进入开始场景状态
    /// </summary>
	void Start () {
        controller = new SceneStateController();
        controller.SetState(new StartState(controller),false);
	}
	
	/// <summary>
    /// 每帧运行游戏
    /// </summary>
	void Update () {
        controller.StatUpdate();

    }
}

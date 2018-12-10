using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 状态模式
/// 场景状态基础类
/// </summary>
public class ISceneState
{
    private string mSceneName;//场景名称
    protected SceneStateController mController;//场景控制器
    protected GameMainFacade mMainFacade;

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    /// <param name="controller">控制器</param>
    public ISceneState(string sceneName,SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
        mMainFacade = GameMainFacade.Instance;
    }
    /// <summary>
    /// 获取场景名称
    /// </summary>
    public string SceneName { get { return mSceneName; } }
    /// <summary>
    /// 新场景加载完成优先执行项
    /// </summary>
    public virtual void StateStart()
    {
        mMainFacade.CleanAllUIPanel();
    }
    /// <summary>
    /// 场景结束切换前，最后必须执行项
    /// </summary>
    public virtual void StateEnd()
    {
        mMainFacade.CleanAllUIPanel();
    }
    /// <summary>
    /// 场景每帧运行
    /// </summary>
    public virtual void StateUpdate()
    {
        mMainFacade.UpdateClient();
    }
}


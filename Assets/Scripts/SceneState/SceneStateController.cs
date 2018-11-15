using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// 场景状态控制器
/// </summary>
public class SceneStateController
{
    private bool mIsRunState = false;//场景处于运行状态判断
    private ISceneState mState;//当前状态场景
    private AsyncOperation mAO;//场景加载

    /// <summary>
    /// 场景状态切换执行
    /// 新场景载入
    /// </summary>
    /// <param name="state"></param>
    /// <param name="isLoadScene"></param>
    public void SetState(ISceneState state,bool isLoadScene=true)
    {
        if (mState!=null)
        {
            mState.StateEnd();//上一个状态结束清理
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunState = false;
        }
        else
        {
            mState.StateStart();
            mIsRunState = true;
        }
       
    }
    /// <summary>
    /// 场景运行
    /// </summary>
    public void StatUpdate()
    {
        if (mAO != null && mAO.isDone == false) return;
        
        if (mIsRunState==false&&mAO != null&&mAO.isDone==true)
        {
            mState.StateStart();
            mIsRunState = true;
        }
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}


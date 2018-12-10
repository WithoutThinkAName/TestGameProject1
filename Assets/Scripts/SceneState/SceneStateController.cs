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

    private LoadingUI mLoadingUI;
    private float mLoadingProgress;

    private bool isSetState = false;
    private ISceneState stateWaitForLoad=null;

    public SceneStateController()
    {
        GameMainFacade.Instance.SceneStateController = this;
    }
    /// <summary>
    /// 异步场景加载
    /// </summary>
    /// <param name="state"></param>
    public void SetStateAsyn(ISceneState state)
    {
        stateWaitForLoad = state;
        isSetState = true;
    }

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
            mLoadingUI= GameMainFacade.Instance.ShowLoadingUI();
            mIsRunState = false;
            mLoadingProgress = 0f;
            mAO.allowSceneActivation = false;
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
    public void StateUpdate()
    {
        if (isSetState==true)
        {
            isSetState = false;
            SetState(stateWaitForLoad);
            stateWaitForLoad = null;
            return;
        }

        if (mAO != null && mAO.isDone == false)
        {
            if (mLoadingProgress == mAO.progress && mAO.progress == 0.9f && mAO.allowSceneActivation == false)
            {
                mAO.allowSceneActivation = true;
                mLoadingProgress = 0f;
            }
            if (mLoadingProgress<mAO.progress && mAO.allowSceneActivation == false)
            {
                mLoadingProgress = Mathf.Min(mAO.progress, mLoadingProgress + 0.1f);
                mLoadingUI.SetLoadingMessage(mLoadingProgress+0.1f);
            }
            return;
        }
        
        if (mIsRunState==false&&mAO != null&&mAO.isDone==true)
        {
           
            mIsRunState = true;
            mAO = null;
            mState.StateStart();
        }
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}


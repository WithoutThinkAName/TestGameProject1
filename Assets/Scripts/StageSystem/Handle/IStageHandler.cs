using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 责任链模式处理器
/// </summary>
public abstract class IStageHandler
{
    protected int mLevel;//当前关卡
    protected IStageHandler mNextHandler;//下一级处理器
    protected StageSystem mStageSystem;//当前游戏关卡系统

    protected bool mIsAllEnemySpawned = false;//当前关卡所有敌人刷新完毕判断

    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();//访问者：人物角色存活

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="stageSystem"></param>
    /// <param name="lv"></param>
    public IStageHandler(StageSystem stageSystem, int lv)
    {
        mStageSystem = stageSystem;
        mLevel = lv;
    }
    /// <summary>
    /// 设置下一级处理器
    /// </summary>
    /// <param name="handler"></param>
    /// <returns></returns>
    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }
    /// <summary>
    /// 本处理器执行处理主体
    /// </summary>
    /// <param name="level"></param>
    public void Handle(int level)
    {        
        if (level==mLevel)
        {
            UpdateStage();
            CheckFinished();
        }
        else
        {
            if (mNextHandler!=null)
            {
                mNextHandler.Handle(level);
            }
            else
            {
                mStageSystem.StageClear();
            }
        }
    }
    /// <summary>
    /// 当前关卡每帧执行
    /// </summary>
    protected virtual void UpdateStage() { }
    /// <summary>
    /// 关卡结束判断与新关卡切换
    /// 结束条件：全部敌人刷新完毕->当前没有存活的敌人（访问者）
    /// </summary>
    private void CheckFinished()
    {
        mAliveCountVisitor.Reset();
        GameFacade.Instance.RunVisitor(mAliveCountVisitor);
        if (mIsAllEnemySpawned == true&&mAliveCountVisitor.enemyCount==0)
        {            
            mStageSystem.EnterNextStage();
            mIsAllEnemySpawned = false;
        }
    }
}


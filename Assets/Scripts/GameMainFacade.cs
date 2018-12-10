using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Common;

/// <summary>
/// 客户端主中介
/// </summary>
public class GameMainFacade
{
    private static GameMainFacade _instance = new GameMainFacade();//单例模式
    public static GameMainFacade Instance { get { return _instance; } }

    private SceneStateController mSceneStateController;//场景状态控制器
    public SceneStateController SceneStateController { set { mSceneStateController = value; } }


    private PlayerSystem mPlayerSystem;
    private UIManagerSystem mUIManagerSystem;//UI管理系统
    public UIManagerSystem UIManagerSystem { get { return mUIManagerSystem; } }
    private ClientSystem mClientSystem;//客户端系统
    private RequestSystem mRequestSystem;//请求处理系统
    private AudioSystem mAudioSystem;//声音系统

    
    private AchievementSystem mAchievementSystem;//成就系统

    private bool mIsSingleMode = false;
    public bool IsSingleMode { get { return mIsSingleMode; } private set { mIsSingleMode = value; } }

    /// <summary>
    /// 私有构造
    /// </summary>
    private GameMainFacade() { }

    /// <summary>
    /// 初始化客户端
    /// </summary>
    public void InitClient()
    {
        mClientSystem = new ClientSystem();
        mRequestSystem = new RequestSystem();
        mPlayerSystem = new PlayerSystem();
        mAchievementSystem = new AchievementSystem();
        mUIManagerSystem = new UIManagerSystem();
        mAudioSystem = new AudioSystem();

        mClientSystem.Init();
        mRequestSystem.Init();
        mPlayerSystem.Init();
        //mAchievementSystem.Init();
        mUIManagerSystem.Init();
        mAudioSystem.Init();

        LoadMemento();
    }

    public void UpdateClient()
    {
        mClientSystem.Update();
        mRequestSystem.Update();
        mPlayerSystem.Update();
        //mAchievementSystem.Update();
        mUIManagerSystem.Update();
        mAudioSystem.Update();
    }

    /// <summary>
    /// 释放客户端
    /// </summary>
    public void ReleaseClient()
    {
        mClientSystem.Release();
        mRequestSystem.Release();
        mPlayerSystem.Release();
       
        //mAchievementSystem.Release();
        mUIManagerSystem.Release();
        mAudioSystem.Release();

        CreateMemento();
    }
    /// <summary>
    /// 加载UI路径数据
    /// </summary>
    /// <returns></returns>
    public Dictionary<UIPanelType, string> ParseUIPanelTypeJson()
    {
        return FactoryManager.assetFactory.ParseUIPanelTypeJson();
    }
    /// <summary>
    /// 显示提示信息
    /// </summary>
    /// <param name="message"></param>
    public void ShowMessageUI(string message)
    {
        mUIManagerSystem.ShowMessageUI(message);
    }
    /// <summary>
    /// 异步加载场景过场UI
    /// </summary>
    /// <returns></returns>
    public LoadingUI ShowLoadingUI()
    {
        return mUIManagerSystem.ShowLoadingUI();
    }
    /// <summary>
    /// 关闭所有现有UI
    /// </summary>
    public void CleanAllUIPanel()
    {
        mUIManagerSystem.ClearPanel();
    }
    /// <summary>
    /// 显示指定类型的UI
    /// </summary>
    public void ShowUIPanel(UIPanelType type)
    {
        mUIManagerSystem.PushPanel(type);
    }
    /// <summary>
    /// 单机模式
    /// </summary>
    public void NoNetWorkMode()
    {
        mPlayerSystem.UserData = new UserInfo("临时用户",0,0);
        IsSingleMode = true;
        mSceneStateController.SetStateAsyn(new MainMenuState(mSceneStateController));
    }
    /// <summary>
    /// 开始游戏模式一
    /// </summary>
    public void EnterMode1State()
    {
        mSceneStateController.SetStateAsyn(new Mode1BattleState(mSceneStateController));
    }
    

    /// <summary>
    /// 添加服务器请求
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="request"></param>
    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        mRequestSystem.AddRequest(actionCode, request);
    }
    /// <summary>
    /// 移除服务器请求
    /// </summary>
    /// <param name="actionCode"></param>
    public void RemoveRequest(ActionCode actionCode)
    {
        mRequestSystem.RemoveRequest(actionCode);
    }

    /// <summary>
    /// 处理客户端请求
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
    public void HandleRequest(ActionCode actionCode, string data)
    {
        mRequestSystem.HandleRequest(actionCode, data);
    }
    /// <summary>
    /// 发送服务器请求数据
    /// </summary>
    /// <param name="requestCode"></param>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        mClientSystem.SendRequest(requestCode, actionCode, data);
    }

    /// <summary>
    /// 读取并设置备忘录
    /// </summary>
    public void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }
    /// <summary>
    /// 创建并存储备忘录
    /// </summary>
    public void CreateMemento()
    {
        AchievementMemento memento = mAchievementSystem.CreateMemento();
        memento.SaveData();
    }
    /// <summary>
    /// 背景声音变更
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayBackgroundSound(string soundName)
    {
        mAudioSystem.PlayBackgroundSound(soundName);
    }
    /// <summary>
    /// 效果声音变更
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayNormalSound(string soundName)
    {
        mAudioSystem.PlayNormalSound(soundName);
    }
    /// <summary>
    /// 玩家登陆之后用户数据设置
    /// </summary>
    /// <param name="userdata"></param>
    public void LoginSuccess(UserInfo userdata)
    {
        mPlayerSystem.UserData = userdata;
        IsSingleMode = false;
        mSceneStateController.SetStateAsyn(new MainMenuState(mSceneStateController));
    }
    /// <summary>
    /// 用户数据的获取方法
    /// </summary>
    /// <param name="userdata"></param>
    public UserInfo GetUserData()
    {
       return mPlayerSystem.UserData;
    }
    
}


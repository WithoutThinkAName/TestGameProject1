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

    private UIManagerSystem mUIManagerSystem;//UI管理系统

    private ClientSystem mClientSystem;//客户端系统
    private RequestSystem mRequestSystem;//请求处理系统
    private AudioSystem mAudioSystem;//声音系统

    private AchievementSystem mAchievementSystem;//成就系统

    /// <summary>
    /// 初始化客户端
    /// </summary>
    public void InitClient()
    {
        mClientSystem = new ClientSystem();
        mRequestSystem = new RequestSystem();       
        mAchievementSystem = new AchievementSystem();
        mUIManagerSystem = new UIManagerSystem();
        mAudioSystem = new AudioSystem();

        mClientSystem.Init();
        mRequestSystem.Init();        
        //mAchievementSystem.Init();
        mUIManagerSystem.Init();
        mAudioSystem.Init();

        LoadMemento();
    }

    public void UpdateClient()
    {
        mClientSystem.Update();
        mRequestSystem.Update();
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

        mAchievementSystem.Release();
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


    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        mRequestSystem.AddRequest(actionCode, request);
    }

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
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// UI管理器
/// 从注册登录界面开始使用
/// </summary>
public class UIManagerSystem:IGameSystem
{
    private Transform mCanvasTransform;//UI根位置数据
    private Transform CanvasTransform
    {
        get
        {
            if (mCanvasTransform == null)
            {
                mCanvasTransform = GameObject.Find("Canvas").transform;
            }
            return mCanvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;//存储所有面板Prefab的路径
    private Dictionary<UIPanelType, IBaseUI> panelDict;//保存所有实例化面板的游戏物体身上的IBaseUI组件
    private Stack<IBaseUI> panelStack;

    private LoadingUI mLoadingUI=null;

    private string mMsgAsyn = null;
    

    public override void Init()
    {
        base.Init();
        ParseUIPanelTypeJson();
        panelDict = new Dictionary<UIPanelType, IBaseUI>();
        panelStack = new Stack<IBaseUI>();

        UnityTool.Attach(GameObject.Find("GameLoop"), CanvasTransform.gameObject);
    }
    /// <summary>
    /// 加载Json
    /// </summary>
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = GameMainFacade.Instance.ParseUIPanelTypeJson();
    }
    
    public override void Update()
    {
        base.Update();
        if (mMsgAsyn!=null)
        {
            ShowMessageUI(mMsgAsyn);
            mMsgAsyn = null;
        }


        if (panelStack.Count > 0)
        {
            foreach (IBaseUI panel in panelStack)
            {
                panel.Update();
            }
        }
    }
    /// <summary>
    /// 异步消息UI显示
    /// </summary>
    /// <param name="message"></param>
    public void ShowMessageUIAsyn(string message)
    {
        mMsgAsyn = message;
    }

    /// <summary>
    /// 提示消息框
    /// </summary>
    /// <param name="message"></param>
    private void ShowMessageUI(string message)
    {
        MessageUI panel =(MessageUI) GetPanel(UIPanelType.MessageUI);
        
        panel.OnEnter();
        panel.SetMessage(message);
    }
    /// <summary>
    /// 显示载入UI
    /// </summary>
    public LoadingUI ShowLoadingUI()
    {
        if (mLoadingUI==null)
        {
            mLoadingUI = (LoadingUI)GetPanel(UIPanelType.LoadingUI);
        }

        mLoadingUI.OnEnter();
        panelStack.Push(mLoadingUI);

        return mLoadingUI;
    }
   
    /// <summary>
    /// 显示兵营信息
    /// </summary>
    /// <param name="camp"></param>
    public void ShowCampInfo(ICamp camp)
    {
        GameMode1UI panel =(GameMode1UI) panelDict.TryGet(UIPanelType.GameMode1UI);
        panel.ShowCampInfo(camp);
    }
    /// <summary>
    /// 刷新能量信息
    /// </summary>
    /// <param name="nowEnergy"></param>
    /// <param name="maxEnergy"></param>
    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        GameMode1UI panel = (GameMode1UI)panelDict.TryGet(UIPanelType.GameMode1UI);
        panel.UpdateEnergySlider(nowEnergy, maxEnergy);
    }
    /// <summary>
    /// 更新关卡数
    /// </summary>
    /// <param name="lv"></param>
    public void UpdateStageLv(int lv)
    {
        GameMode1UI panel = (GameMode1UI)panelDict.TryGet(UIPanelType.GameMode1UI);
        panel.UpdateStageLv(lv);
    }
    /// <summary>
    /// 更新关卡生命心数
    /// </summary>
    /// <param name="heartCount"></param>
    public void UpdateHeartCount(int heartCount)
    {
        GameMode1UI panel = (GameMode1UI)panelDict.TryGet(UIPanelType.GameMode1UI);
        panel.UpdateHeartCount(heartCount);
    }
    /// <summary>
    /// 把某个页面入栈，把某个页面显示在界面上
    /// </summary>
    public void PushPanel(UIPanelType panelType)
    {
        //判断一下栈里面是否有页面
        if (panelStack.Count > 0)
        {
            IBaseUI topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        IBaseUI panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
    }
    /// <summary>
    /// 出栈 ，把页面从界面上移除
    /// </summary>
    public void PopPanel()
    { 
        if (panelStack.Count <= 0) return;

        //关闭栈顶页面的显示
        IBaseUI topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        IBaseUI topPanel2 = panelStack.Peek();
        topPanel2.OnResume();

    }
    /// <summary>
    /// 清除栈中所有Panel
    /// 场景切换重置
    /// </summary>
    public void ClearPanel()
    {
        if (panelStack.Count <= 0) return;

        while (panelStack.Count > 0)
        {
            //关闭栈顶页面的显示
            IBaseUI topPanel = panelStack.Pop();
            topPanel.OnExit();
            
        }
       
    }


    /// <summary>
    /// 根据面板类型 得到实例化的面板
    /// </summary>
    /// <returns></returns>
    private IBaseUI GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, IBaseUI>();
        }
        
        IBaseUI panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            //如果找不到，那么就找这个面板的prefab的路径，然后去根据prefab去实例化面板
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            instPanel.GetComponent<IBaseUI>().UIManager = this;
            panelDict.Add(panelType, instPanel.GetComponent<IBaseUI>());
            instPanel.GetComponent<IBaseUI>().Init();
            return instPanel.GetComponent<IBaseUI>();
        }
        else
        {
            return panel;
        }
    }    
}


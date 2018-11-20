﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// UI管理器
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

    //private UIManagerSystem()
    //{
    //    ParseUIPanelTypeJson();
    //}






    /// <summary>
    /// 把某个页面入栈，  把某个页面显示在界面上
    /// </summary>
    public void PushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
            panelStack = new Stack<IBaseUI>();

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
        if (panelStack == null)
            panelStack = new Stack<IBaseUI>();

        if (panelStack.Count <= 0) return;

        //关闭栈顶页面的显示
        IBaseUI topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        IBaseUI topPanel2 = panelStack.Peek();
        topPanel2.OnResume();

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

        //IBaseUI panel;
        //panelDict.TryGetValue(panelType, out panel);//TODO

        IBaseUI panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            //如果找不到，那么就找这个面板的prefab的路径，然后去根据prefab去实例化面板
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            panelDict.Add(panelType, instPanel.GetComponent<IBaseUI>());
            return instPanel.GetComponent<IBaseUI>();
        }
        else
        {
            return panel;
        }

    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            //Debug.Log(info.panelType);
            panelPathDict.Add(info.panelType, info.path);
        }
    }

    /// <summary>
    /// just for test
    /// </summary>
    public void Test()
    {
        string path;
        panelPathDict.TryGetValue(UIPanelType.Knapsack, out path);
        Debug.Log(path);
    }
}

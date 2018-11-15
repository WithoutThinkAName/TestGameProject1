using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 兵营系统类
/// 初始化并管理所有兵营
/// </summary>
public class CampSystem : IGameSystem
{
    //兵营字典存放所有现有兵营
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    /// <summary>
    /// 初始化所有兵营
    /// </summary>
    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Captain);
        InitCamp(SoldierType.Sergeant);
    }
    /// <summary>
    /// 根据数据初始化兵营
    /// </summary>
    /// <param name="soldierType"></param>
    private void InitCamp(SoldierType soldierType)
    {
        GameObject gameObjec = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;

        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新兵兵营";
                icon = "RookieCamp";
                trainTime = 1;
                break;
            case SoldierType.Captain:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 1.5f;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 2;
                break;
            default:
                break;
        }
        gameObjec = GameObject.Find(gameObjectName);
        position = UnityTool.FindChildByName(gameObjec, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObjec, name, icon, soldierType, position,trainTime);

        gameObjec.AddComponent<CampOnClick>().camp = camp;
        camp.campOnClick = gameObjec.GetComponent<CampOnClick>();

        mSoldierCamps.Add(soldierType, camp);
    }

    /// <summary>
    /// 每帧兵营运行
    /// </summary>
    public override void Update()
    {
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }
    }

    /// <summary>
    /// 根据类型查找兵营数据
    /// </summary>
    /// <param name="soldierType"></param>
    /// <returns></returns>
    public SoldierCamp FindSoldierCampByCampType(SoldierType soldierType)
    {
        if (mSoldierCamps.ContainsKey(soldierType)==true)
        {
            Debug.Log(soldierType);
            return mSoldierCamps[soldierType];
        }
        else
        {
            Debug.LogError("不存在查找的Camp类型：[" + soldierType + "]");
            return null;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//备忘录模式测试
public class AchievementMemento
{
    public int enemyKilledCount { get; set; }
    public int soldierKilledCount { get; set; }
    public int maxStageLv { get; set; }

    /// <summary>
    /// 本地简单的成就数据存储
    /// </summary>
    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKillledCount", enemyKilledCount);
        PlayerPrefs.SetInt("SoldierKillledCount", soldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", maxStageLv);
    }

   /// <summary>
   /// 本地数据读取
   /// </summary>
    public void LoadData()
    {
        enemyKilledCount = PlayerPrefs.GetInt("EnemyKillledCount");
        soldierKilledCount = PlayerPrefs.GetInt("SoldierKillledCount");
        maxStageLv = PlayerPrefs.GetInt("MaxStageLv");
    }



}


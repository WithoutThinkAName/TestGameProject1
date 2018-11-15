using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 普通关卡处理器
/// </summary>
public class NormalStageHandler:IStageHandler
{
    private EnemyType mEnemyType;//当前关卡敌人类型
    private WeaponType mWeaponType;//当前关卡敌人武器类型
    private int mCount;//当前关卡敌人总数
    private Vector3 mPosition;//敌人生成位置

    private int mSpawnTime = 1;//敌人生成间隔
    private float mSpawnTimer = 0;//敌人生成间隔计时器
    private int mCountSpawned = 0;//已生成敌人数量

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="stageSystem">当前关卡系统</param>
    /// <param name="lv">关卡等级</param>
    /// <param name="et">敌人类型</param>
    /// <param name="wt">敌人武器类型</param>
    /// <param name="count">敌人个数</param>
    /// <param name="pos">生成位置</param>
    public NormalStageHandler(StageSystem stageSystem, int lv,EnemyType et,WeaponType wt,int count,Vector3 pos) : base(stageSystem,lv)
    {
        mEnemyType = et;
        mWeaponType = wt;
        mCount = count;
        mPosition = pos;
        mSpawnTimer = mSpawnTime;
    }
    /// <summary>
    /// 当前关卡每帧运行
    /// </summary>
    protected override void UpdateStage()
    {
        base.UpdateStage();
        if (mCountSpawned<mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if (mSpawnTimer<=0)
            {
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
                if (mCountSpawned==mCount)
                {
                    mIsAllEnemySpawned = true;
                }
            }
        }        
    }
    /// <summary>
    /// 通过敌人工厂，生成敌人单位
    /// </summary>
    private void SpawnEnemy()
    {
        mCountSpawned++;
        //Debug.Log(mCountSpawned + "-" + mCount);
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mPosition);
                break;
            case EnemyType.Ogre:
                FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition);
                break;
            case EnemyType.Troll:
                FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition);
                break;
            default:
                Debug.LogError("无法生成["+mEnemyType+"]类型的敌人");
                break;
        }
    }
}


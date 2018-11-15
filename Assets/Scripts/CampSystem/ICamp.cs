using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 兵营基本类
/// </summary>
public abstract class ICamp
{
    protected GameObject mGameObject;//兵营游戏物体
    protected string mName;//兵营名称
    protected string mIconSprite;//兵营显示图标
    protected SoldierType mSoldierType;//生产士兵类型
    protected Vector3 mPosition;//生成点
    protected float mTrainTime;//单个士兵训练时间

    protected CampOnClick mCampOnClick;//组件：被点击事件

    protected List<ITrainCommand> mCommands;//生产士兵命令列表
    protected float mTrainTimer;//生产士兵计时器

    protected IEnergyCountStrategy mEnergyCostStrategy;//能量计算类引用

    protected int mEnergyCostCampUpgrade;//当前兵营升级需求能量数
    protected int mEnergyCostWeaponUpgrade;//当前武器升级需求能量数
    protected int mEnergyCostTrain;//当前士兵训练需求能量数

    /// <summary>
    /// 初始化兵营构造
    /// </summary>
    /// <param name="gameObject">兵营游戏对象</param>
    /// <param name="name">兵营名称</param>
    /// <param name="icon">兵营显示图标</param>
    /// <param name="soldierType">生产士兵类型</param>
    /// <param name="position">生成点</param>
    /// <param name="trainTime">单个士兵训练时间</param>
    public ICamp(GameObject gameObject,string name,string icon,SoldierType soldierType,Vector3 position,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;
        mCommands = new List<ITrainCommand>();
    }
    /// <summary>
    /// 每帧运行方法
    /// </summary>
    public virtual void Update()
    {
        UpdateCommand();
    }
    /// <summary>
    /// 每帧执行命令运行方法
    /// </summary>
    private void UpdateCommand()
    {
        if (mCommands.Count <= 0) return;
        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer <= 0)
        {
            mCommands[0].Execute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }
    }
    /// <summary>
    /// 外部获取兵营名称
    /// </summary>
    public string name { get { return mName; } }
    /// <summary>
    /// 外部获取兵营图标
    /// </summary>
    public string iconSprite { get { return mIconSprite; } }
    /// <summary>
    /// 外部获取兵营物体组件
    /// </summary>
    public CampOnClick campOnClick { set { mCampOnClick = value; } }
    /// <summary>
    /// 显示兵营信息
    /// </summary>
    public abstract void ShowCampInfo();
    /// <summary>
    /// 外部获取兵营等级
    /// </summary>
    public abstract int lv { get; }
    /// <summary>
    /// 外部获取武器等级
    /// </summary>
    public abstract WeaponType weaponType { get; }
    /// <summary>
    /// 外部获取当前兵营升级能量
    /// </summary>
    public abstract int energyCostCampUpgrade { get; }
    /// <summary>
    /// 外部获取当前武器升级能量
    /// </summary>
    public abstract int energyCostWeaponUpgrade { get; }
    /// <summary>
    /// 外部获取当前士兵训练能量
    /// </summary>
    public abstract int energyCostTrain { get; }
    /// <summary>
    /// 获取当前士兵训练命令列表内命令数量
    /// </summary>
    public int trainCount { get { return mCommands.Count; } }
    /// <summary>
    /// 获取当前训练士兵剩余时间
    /// </summary>
    public float trainRemainingTime { get { return mTrainTimer; } }
    /// <summary>
    /// 更新能量消耗
    /// </summary>
    protected abstract void UpdateEnergyCost();
    /// <summary>
    /// 训练命令添加
    /// </summary>
    public abstract void Train();
    /// <summary>
    /// 升级兵营
    /// </summary>
    public abstract void UpgradeCamp();
    /// <summary>
    /// 升级武器
    /// </summary>
    public abstract void UpgradeWeapon();

    /// <summary>
    /// 取消命令列表中最后一个训练命令
    /// 只有一个时，取消命令并初始化训练剩余时间计时器
    /// </summary>
    public void CancelATrainCommand()
    {
        if (mCommands.Count>0)
        {
            mCommands.RemoveAt(mCommands.Count - 1);
            if (mCommands.Count==0)
            {
                mTrainTimer = mTrainTime;
            }
        }
    }
}


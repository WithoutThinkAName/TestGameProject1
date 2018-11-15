using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// 人物角色基础类
/// 桥接，处理武器
/// </summary>
public abstract class ICharacter
{
    protected ICharacterAttr mAttr;//人物属性

    protected GameObject mGameObject;//人物游戏物体
    protected NavMeshAgent mNavAgent;//导航组件
    protected AudioSource mAudio;//音效组件
    protected Animation mAnim;//动画组件
    protected IWeapon mWeapon;//武器

    protected bool mIsKilled = false;//死亡状态
    protected bool mCanDestoryImmediately = false;//立刻移除人物游戏物体判定

    protected CharacterHPSlider HPSlider;//人物血条

    /// <summary>
    /// 获取人物死亡状态
    /// </summary>
    public bool isKilled { get { return mIsKilled;  } }

    /// <summary>
    /// 获取人物位置
    /// </summary>
    public Vector3 position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("士兵实体不存在");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }
    /// <summary>
    /// 获取人物攻击范围
    /// </summary>
    public float atkRange
    {
        get
        {
            return mWeapon.atkRange;
        }
    }
    /// <summary>
    /// 获取人物属性
    /// </summary>
    public ICharacterAttr attr
    {
        get
        {
            return mAttr;
        }
        set
        {
            mAttr = value;
        }
    }
    /// <summary>
    /// 获取人物角色游戏物体
    /// </summary>
    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
            HPSlider = mGameObject.GetComponentInChildren<CharacterHPSlider>();
        }
    }
    /// <summary>
    /// 获取武器
    /// </summary>
    public IWeapon weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.owner = this;
            //Transform weaponPoint=mGameObject.transform.
            GameObject child = UnityTool.FindChildByName(mGameObject, "weapon-point");
            UnityTool.Attach(child, mWeapon.gameObject);
        }
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public void Update()
    {        
        mWeapon.Update();       
    }
    /// <summary>
    /// AI有限状态机每帧运行
    /// </summary>
    /// <param name="targets"></param>
    public abstract void UpdateFSMAI(List<ICharacter> targets);
    /// <summary>
    /// 访问者运行
    /// </summary>
    /// <param name="visitor"></param>
    public abstract void RunVisitor(ICharacterVisitor visitor);
    /// <summary>
    /// 查询列表中最近的单位
    /// </summary>
    /// <param name="targets"></param>
    /// <returns></returns>
    public ICharacter GetNearestTarget(List<ICharacter> targets)
    {
        ICharacter target = null;
        float minDistance = -1;
        float distance = 0;
        foreach (ICharacter c in targets)
        {
            distance= Vector3.Distance(c.position, this.position);
            if (distance<minDistance||minDistance==-1)
            {
                minDistance = distance;
                target = c;
            }
        }
        return target;
    }
    /// <summary>
    /// 攻击目标单位
    /// </summary>
    /// <param name="target"></param>
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.position);
        mGameObject.transform.LookAt(target.position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.atk+mAttr.critValue);
    }
    /// <summary>
    /// 自身被攻击
    /// </summary>
    /// <param name="damage"></param>
    public virtual void UnderAttack(int damage)
    {
        if (mIsKilled) return;
        
        mAttr.TakeDamage(damage);
        SetHPSlider();
    }
    /// <summary>
    /// 自身死亡
    /// </summary>
    public virtual void Killed()
    {        
        mNavAgent.isStopped = true;
    }
    /// <summary>
    /// 到达目标点：目前只有敌人用
    /// </summary>
    public virtual void ReachTargetPoint() { }
    /// <summary>
    /// 释放这个人物角色
    /// </summary>
    public void Release()
    {
        if (mCanDestoryImmediately)
        {
            GameObject.Destroy(mGameObject);
        }
        else
        {
            mGameObject.AddComponent<DestoryForTime>();
        }
    }
    /// <summary>
    /// 播放人物动画
    /// </summary>
    /// <param name="animName"></param>
    public void PlayAnim(string animName)
    {
        if (animName.Equals(""))
        {
            return;
        }
        mAnim.CrossFade(animName);
    }
    /// <summary>
    /// 设置导航目标移动点
    /// </summary>
    /// <param name="targetPosition"></param>
    public void MoveToTarget(Vector3 targetPosition)
    {
        mNavAgent.isStopped = false;
        mNavAgent.SetDestination(targetPosition);
        PlayAnim("move");
    }
    /// <summary>
    /// 停止导航移动
    /// </summary>
    public void StopMove()
    {
        mNavAgent.isStopped = true;
        PlayAnim("stand");
    }
    /// <summary>
    /// 执行显示特效
    /// </summary>
    /// <param name="effectName"></param>
    protected void DoPlayEffect(string effectName)
    {
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectName);
        effectGO.transform.position = position;

        effectGO.AddComponent<DestoryForTime>();
    }
    /// <summary>
    /// 执行播放声音
    /// </summary>
    /// <param name="soundName"></param>
    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }
    /// <summary>
    /// 设置HP血条
    /// </summary>
    private void SetHPSlider()
    {
        HPSlider.SetCurrentHP(mAttr.currentHP, mAttr.maxHP);
    }
}


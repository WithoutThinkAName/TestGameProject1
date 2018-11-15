using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 武器类型
/// </summary>
public enum WeaponType
{
    Gun=0,
    Rifle=1,
    Rocket=2,
    Max
}

/// <summary>
/// 武器基础类
/// </summary>
public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;//武器基础属性

    protected GameObject mGameObject;//武器游戏物体
    protected ICharacter mOwner;//武器持有人

    protected ParticleSystem mPariticle;//武器特效
    protected LineRenderer mLine;//武器线效
    protected Light mLight;//武器光效
    protected AudioSource mAudio;//武器音效

    protected float mEffectDisplayTime=0;//武器效果持续时间
    /// <summary>
    /// 获取武器攻击范围
    /// </summary>
    public float atkRange{ get{ return mBaseAttr.atkRange; } }
    /// <summary>
    /// 获取武器攻击力
    /// </summary>
    public int atk { get { return mBaseAttr.atk; } }
    /// <summary>
    /// 设置武器持有人
    /// </summary>
    public ICharacter owner { set { mOwner = value; } }
    /// <summary>
    /// 获取武器游戏物体
    /// </summary>
    public GameObject gameObject { get { return mGameObject; } }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="baseAttr">武器基础属性</param>
    /// <param name="gameObject">武器游戏物体</param>
    public IWeapon(WeaponBaseAttr baseAttr,GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;

        Transform effect = mGameObject.transform.Find("Effect");
        mPariticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }

    /// <summary>
    /// 每帧运行
    /// 开枪特效处理
    /// </summary>
    public void Update()
    {
        if (mEffectDisplayTime>=0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime<=0)
            {
                DisableEffect();
            }
        }
    }
    /// <summary>
    /// 武器开枪特效
    /// </summary>
    /// <param name="targetPosition"></param>
    public void Fire(Vector3 targetPosition)
    {
        //特效
        PlayMuzzleEffect();

        //子弹轨迹
        PlayBulletEffect(targetPosition);

        //特效时间
        SetEffectDisplayTime();

        //声音
        PlaySound();
    }
    /// <summary>
    /// 设置特效小时时间
    /// </summary>
    protected abstract void SetEffectDisplayTime();
    /// <summary>
    /// 播放枪口效果
    /// </summary>
    protected virtual void PlayMuzzleEffect()
    {
        //特效
        mPariticle.Stop();
        mPariticle.Play();
        mLight.enabled = true;
    }
    /// <summary>
    /// 播放子弹特效
    /// </summary>
    /// <param name="targetPosition"></param>
    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    /// <summary>
    /// 子弹特效执行主体
    /// </summary>
    /// <param name="width"></param>
    /// <param name="targetPosition"></param>
    protected void DoPlayBulletEffect(float width, Vector3 targetPosition)
    {
        //轨迹
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }
    /// <summary>
    /// 播放声音
    /// </summary>
    protected abstract void PlaySound();
    /// <summary>
    /// 播放声音执行主体
    /// </summary>
    /// <param name="clipName"></param>
    protected void DoPlaySound(string clipName)
    {
        //声音
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }
    /// <summary>
    /// 特效停止
    /// </summary>
    private void DisableEffect()
    {
        mLight.enabled = false;
        mLine.enabled = false;
    }
}


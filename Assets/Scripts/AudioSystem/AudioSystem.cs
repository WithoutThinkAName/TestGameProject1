using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AudioSystem:IGameSystem
{
    public const string Sound_Bg_Moderate = "Bg(moderate)";
    public const string Sound_Bg_fast = "Bg(fast)";
    public const string Sound_ButtonClick = "ButtonClick";
    public const string Sound_Timer = "Timer";
    public const string Sound_Alert = "Alert";

    private GameObject mAudioSourceGO;//声源游戏物体
    private AudioSource mBackgroundAS;//背景声源
    private AudioSource mNormalAS;//通用音效声源

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();
        mAudioSourceGO = new GameObject("MainAudioSource");

        

        mBackgroundAS = mAudioSourceGO.AddComponent<AudioSource>();
        mNormalAS =mAudioSourceGO.AddComponent<AudioSource>();

        UnityTool.Attach(GameObject.Find("GameLoop"), mAudioSourceGO);

        //PlaySound(mBackgroundAS, Sound_Bg_Moderate,1f, true);
    }
    /// <summary>
    /// 每帧运行
    /// </summary>
    public override void Update()
    {
        base.Update();
        
    }
    /// <summary>
    /// 播放声音方法(内部)
    /// </summary>
    /// <param name="audioSource">播放声音的声源组件</param>
    /// <param name="soundName">播放的声音名称路径</param>
    /// <param name="isLoop">播放是否循环</param>
    private void PlaySound(AudioSource audioSource,string soundName,float volume=0.5f,bool isLoop=false)
    {
        audioSource.clip = LoadSound(soundName);
        audioSource.volume = volume;
        audioSource.loop = isLoop;
        audioSource.Play();
    }
    /// <summary>
    /// 切换背景音
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayBackgroundSound(string soundName)
    {
        PlaySound(mBackgroundAS, soundName,0.2f, true);
    }
    /// <summary>
    /// 切换效果音
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayNormalSound(string soundName)
    {
        PlaySound(mNormalAS, soundName);
    }

    /// <summary>
    /// 通过工厂获取声音文件
    /// </summary>
    /// <param name="soundName"></param>
    /// <returns></returns>
    private AudioClip LoadSound(string soundName)
    {
        return  FactoryManager.assetFactory.LoadSoundClip(soundName);
    }
}


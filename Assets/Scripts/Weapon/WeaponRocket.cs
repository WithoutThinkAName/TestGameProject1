using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 火箭发射器类
/// </summary>
public class WeaponRocket : IWeapon
{
    public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }

    /// <summary>
    /// 子弹效果
    /// </summary>
    /// <param name="targetPosition"></param>
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.3f, targetPosition);
    }
    /// <summary>
    /// 音效
    /// </summary>
    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }
    /// <summary>
    /// 效果时间
    /// </summary>
    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
}


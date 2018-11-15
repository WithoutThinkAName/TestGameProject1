using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 步枪类
/// </summary>
public class WeaponRifle : IWeapon
{
    public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }

    /// <summary>
    /// 子弹效果
    /// </summary>
    /// <param name="targetPosition"></param>
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.1f, targetPosition);
    }
    /// <summary>
    /// 音效
    /// </summary>
    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }
    /// <summary>
    /// 特效时间
    /// </summary>
    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}


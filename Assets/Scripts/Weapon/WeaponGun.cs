using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 手枪类
/// </summary>
public class WeaponGun : IWeapon
{
    public WeaponGun(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject) { }

    /// <summary>
    /// 子弹效果
    /// </summary>
    /// <param name="targetPosition"></param>
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.05f, targetPosition);
    }
    /// <summary>
    /// 音效
    /// </summary>
    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }
    /// <summary>
    /// 效果持续时间
    /// </summary>
    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.2f;
    }
}


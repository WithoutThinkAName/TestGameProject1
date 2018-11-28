using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 资源载入工厂
/// </summary>
public interface IAssetFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    AudioClip LoadSoundClip(string name);
    Sprite LoadSprite(string name);
    Dictionary<UIPanelType, string> ParseUIPanelTypeJson();
}


using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 组件：人物角色血条
/// </summary>
public class CharacterHPSlider:MonoBehaviour
{
    private GameObject HPobj;//血条游戏物体
    private Slider HPSlider;//血条显示slider

    /// <summary>
    /// 初始化
    /// </summary>
    void Awake()
    {
        HPobj = UnityTool.FindChildByName(gameObject,"HP");
        HPSlider = UITools.FindChild<Slider>(HPobj, "HPSliderGO");
        HPSlider.value = 1;
        HPSlider.SetDirection(Slider.Direction.RightToLeft, true);
    }
    /// <summary>
    /// 血条UI朝向摄像机
    /// </summary>
    void Update()
    {
        HPobj.transform.LookAt(Camera.main.transform);
    }
    /// <summary>
    /// 设置血条显示
    /// </summary>
    /// <param name="nowHP"></param>
    /// <param name="maxHP"></param>
    public void SetCurrentHP(int nowHP,int maxHP)
    {
        HPSlider.value = (float)nowHP / maxHP;
    }
    /// <summary>
    /// 设置血条显示
    /// </summary>
    /// <param name="isShow"></param>
    public void SetHPSliderState(bool isShow)
    {
        HPobj.SetActive(isShow);
    }
}


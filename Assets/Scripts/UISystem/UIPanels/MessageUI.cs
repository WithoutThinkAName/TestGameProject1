using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 提示信息展示UI
/// 自动销毁，不进UI栈
/// </summary>
public class MessageUI:IBaseUI
{
    private Text mMessageLab;//信息文本
    private Animator mAnim;//动画组件

    public override void Init()
    {
        base.Init();

        mMessageLab = UITools.FindChild<Text>(mUIRoot, "MessageInfo");
        mAnim = GetComponent<Animator>();
    }


    /// <summary>
    /// 初始化UI
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();       
        
    }
    /// <summary>
    /// 设置内容
    /// 根据UI动画时间，设定销毁
    /// </summary>
    /// <param name="message"></param>
    public void SetMessage(string message)
    {
        mMessageLab.text = message;
        transform.SetAsLastSibling();
        Show();
        CancelInvoke();
        mAnim.Play("MessageAppear");
        Invoke("Hide", 1.5f);
    }
}


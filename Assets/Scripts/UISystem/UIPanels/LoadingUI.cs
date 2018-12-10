using UnityEngine;
using UnityEngine.UI;

public class LoadingUI:IBaseUI
{
    private Text mMessageLab;//信息文本

    public override void Init()
    {
        base.Init();

        mMessageLab = UITools.FindChild<Text>(mUIRoot, "LoadingLab");
    }
    /// <summary>
    /// 初始化UI
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

    }
    /// <summary>
    /// 等待载入的文本数据
    /// </summary>
    public void SetLoadingMessage(float loadingSpeed)
    {
        mMessageLab.text = string.Format("Loading({0}%)", (int)(loadingSpeed * 100));
    }

}


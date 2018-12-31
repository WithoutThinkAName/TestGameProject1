using UnityEngine;

/// <summary>
/// 全部UI类的基本类
/// </summary>
public abstract class IBaseUI:MonoBehaviour
{
    protected GameMainFacade mMainfacade;//主中介者
    protected GameMode1Facade mMode1Facade;//游戏中介者
    protected UIManagerSystem mUIManager;//UI系统
    public UIManagerSystem UIManager { set { mUIManager = value; } }
    protected GameObject mUIRoot;//当前UI的根位置
    protected RectTransform thisPanel;
    protected float mAnimSpeed;

    protected float mScreenX { get { return Screen.width; } }
    protected float mScreenY { get { return Screen.height; } }

    /// <summary>
    /// UI初始化方法
    /// </summary>
    public virtual void Init()
    {
        mMainfacade = GameMainFacade.Instance;
        mMode1Facade = GameMode1Facade.Instance;
        
        mUIRoot =gameObject;
        thisPanel = GetComponent<RectTransform>();

        mAnimSpeed = 0.2f;
    }
    /// <summary>
    /// UI每帧运行方法
    /// </summary>
    public virtual void Update() { }
    /// <summary>
    /// UI释放方法
    /// </summary>
    public virtual void Release()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {
        thisPanel.SetAsLastSibling();
        Show();
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void OnResume()
    {

    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关闭
    /// </summary>
    public virtual void OnExit()
    {
        Hide();
    }





    /// <summary>
    /// 当前UI显示方法
    /// </summary>
    protected void Show()
    {
        mUIRoot.SetActive(true);
    }
    /// <summary>
    /// 当前UI隐藏方法
    /// </summary>
    protected void Hide()
    {
        mUIRoot.SetActive(false);
    }
    /// <summary>
    /// 按钮点击声音
    /// </summary>
    protected void PlayClickSound()
    {
        mMainfacade.PlayNormalSound(AudioSystem.Sound_ButtonClick);
    }
}


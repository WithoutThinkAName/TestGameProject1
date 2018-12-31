using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

/// <summary>
/// 模式二的UI界面
/// 有点臃肿了
/// </summary>
public class MenuMode2UI:IBaseUI
{
    private Text mPlayerNameLab;//用户名
    private Text mPlayerWinCountLab;//胜场
    private Text mPlayerTotalCountLab;//总场
    private Button mCreateRoomBtn;//创建房间按钮组件
    private InputField mRoomNameInput;
    private Transform mCreateRoomRect;//创建房间按钮数据组件
    private Button mStartBtn;//开始按钮组件
    private Transform mStartGameRect;//开始按钮数据组件
    private Button mReturnMainMenuBtn;//返回主菜单按钮
    
    private Transform mRoomListPanel;//房间列表UI
    private VerticalLayoutGroup mRoomListLayout;
    private GameObject mRoomListItemPrefab;

    private Transform mRoomStatePanel;//房间UI
    private VerticalLayoutGroup mRoomStateLayout;
    private GameObject mRoomPlayerItemPrefab;

    private Button mRefreshRoomListBtn;//刷新按钮
    private Button mReturnRoomListBtn;//返回房间列表按钮

    private float RefreshRoomListTimer = 10f;//自动刷新计时器
    
    private List<RoomInfo> roomListData=null;
    private bool IsInARoom = false;
    private RoomInfo mRoom=null;
    private bool IsReturnRoomList = false;
    private bool IsCleanList = false;

    private CreateRoomRequest mCreateRoomRequest;
    private RoomListRequest mRoomListRequest;
    private JoinRoomRequest mJoinRoomRequest;
    private ExitRoomRequest mExitRoomRequest;
    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();

        mPlayerNameLab = UITools.FindChild<Text>(mUIRoot, "PlayerNameLab");
        mPlayerWinCountLab = UITools.FindChild<Text>(mUIRoot,"WinCountLab");
        mPlayerTotalCountLab = UITools.FindChild<Text>(mUIRoot, "TotalCountLab");
        mCreateRoomBtn = UITools.FindChild<Button>(mUIRoot, "CreatRoomButton_Mode2");
        mRoomNameInput= UITools.FindChild<InputField>(mUIRoot, "RoomNameInput");
        mCreateRoomRect = UITools.FindChild<Transform>(mUIRoot, "CreateRoom");
        mStartBtn = UITools.FindChild<Button>(mUIRoot, "StartButton_Mode2");
        mStartGameRect = UITools.FindChild<Transform>(mUIRoot, "StartGame");
        mReturnMainMenuBtn = UITools.FindChild<Button>(mUIRoot, "CloseButton_Mode2");

        mRoomListPanel = UITools.FindChild<Transform>(mUIRoot, "RoomListPanel");
        mRoomListLayout = UITools.FindChild<VerticalLayoutGroup>(mUIRoot, "RoomListArea");
        mRoomListItemPrefab = UnityTool.FindChildByName(mUIRoot, "RoomListItem");
        mRoomListItemPrefab.SetActive(false);

        mRoomStatePanel = UITools.FindChild<Transform>(mUIRoot, "RoomStatePanel");
        mRoomStateLayout= UITools.FindChild<VerticalLayoutGroup>(mUIRoot, "RoomStateArea");
        mRoomPlayerItemPrefab = UnityTool.FindChildByName(mUIRoot, "RoomPlayerItem");
        mRoomPlayerItemPrefab.SetActive(false);

        mRoomStatePanel = UITools.FindChild<Transform>(mUIRoot, "RoomStatePanel");

        mRefreshRoomListBtn = UITools.FindChild<Button>(mUIRoot, "RefreshButton");
        mReturnRoomListBtn = UITools.FindChild<Button>(mUIRoot, "ReturnRoomList");


        mCreateRoomRequest = GetComponent<CreateRoomRequest>();
        mRoomListRequest = GetComponent<RoomListRequest>();
        mJoinRoomRequest = GetComponent<JoinRoomRequest>();
        mExitRoomRequest = GetComponent<ExitRoomRequest>();
        SetPlayerData();

        mCreateRoomBtn.onClick.AddListener(CreateRoomBtnOnClick);
        mStartBtn.onClick.AddListener(StartBtnOnClick);
        mRefreshRoomListBtn.onClick.AddListener(RefreshBtnOnClick);
        mReturnRoomListBtn.onClick.AddListener(ReturnRoomListBtnOnClick);
        mReturnMainMenuBtn.onClick.AddListener(ReturnMainMenuBtnOnClick);

    }
    /// <summary>
    /// 设置用户数据
    /// </summary>
    private void SetPlayerData()
    {
        UserInfo user = mMainfacade.GetUserData();
        mPlayerNameLab.text = user.UserName;
        mPlayerWinCountLab.text = user.WinCount.ToString();
        mPlayerTotalCountLab.text = user.TotalCount.ToString();
        mRoomNameInput.text = user.UserName + "的房间";
    }
    /// <summary>
    /// UI进入事件
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        EnterAnim();
        RefreshBtnOnClick();
    }
    /// <summary>
    /// UI进入动画
    /// </summary>
    private void EnterAnim()
    {
        thisPanel.localPosition = new Vector3(0, -mScreenY, 0);

        //mRoomListPanel.localPosition = new Vector3(-mScreenX / 4, 0, 0);
        //mRoomStatePanel.localPosition = new Vector3(- mScreenX, 0, 0);

        //mCreateRoomRect.localPosition = new Vector3(mScreenX / 4, -mScreenY / 3, 0);
        //mStartGameRect.localPosition = new Vector3(mScreenX, -mScreenY / 3, 0);

        mCreateRoomBtn.enabled = true;
        mStartBtn.enabled = false;
        mRefreshRoomListBtn.enabled = true;
        mReturnRoomListBtn.enabled = false;
        mReturnMainMenuBtn.enabled = true;


        thisPanel.DOMoveY(mScreenY/2, mAnimSpeed);
    }
    /// <summary>
    /// UI退出事件
    /// </summary>
    public override void OnExit()
    {
        HideAnim();
    }
    /// <summary>
    /// UI退出动画
    /// </summary>
    private void HideAnim()
    {
        mCreateRoomBtn.enabled = false;
        mStartBtn.enabled = false;
        mRefreshRoomListBtn.enabled = false;
        mReturnRoomListBtn.enabled = false;
        mReturnMainMenuBtn.enabled = false;

        thisPanel.DOMoveY(-mScreenY/2, mAnimSpeed).OnComplete(() => base.OnExit());
    }
   
    /// <summary>
    /// 创建房间按钮点击事件
    /// </summary>
    private void CreateRoomBtnOnClick()
    {
        mCreateRoomBtn.enabled = false;
        mStartBtn.enabled = true;
        

        mCreateRoomRequest.SendRequest(mRoomNameInput.text);
    }
    /// <summary>
    /// 进入房间按钮点击事件
    /// </summary>
    public void JoinRoomOnClick(int roomID)
    {
        mJoinRoomRequest.SendRequest(roomID.ToString());
    }
    /// <summary>
    /// 进入房间成功UI事件
    /// </summary>
    public void EnterRoomAsyn(RoomInfo room)
    {
        mRoom = room;
        IsInARoom = true;
    }
   
    /// <summary>
    /// 房间开始游戏按钮点击事件
    /// </summary>
    private void StartBtnOnClick()
    {

    }
    /// <summary>
    /// 返回房间列表按钮点击事件
    /// </summary>
    private void ReturnRoomListBtnOnClick()
    {
        mCreateRoomBtn.enabled = true;
        mStartBtn.enabled = false;
        mExitRoomRequest.SendRequest();
        
    }
    /// <summary>
    /// 异步返回房间列表
    /// </summary>
    public void ReturnRoomListAsyn()
    {
        mMainfacade.SetCurrentRoom(null);
        IsReturnRoomList = true;
        
    }
    /// <summary>
    /// 返回房间列表执行
    /// </summary>
    private void ReturnRoomList()
    {
        IsInARoom = false;
        RefreshBtnOnClick();
        ReturnRoomListAnim();
    }
    /// <summary>
    /// 进入房间动画
    /// </summary>
    private void ShowRoomStateUIAnim()
    {
        mReturnRoomListBtn.enabled = true;
        mReturnMainMenuBtn.gameObject.SetActive(false);

        mCreateRoomRect.DOMoveX(mScreenX * 2, mAnimSpeed).OnComplete(() => mStartGameRect.DOMoveX(mScreenX / 4 * 3, mAnimSpeed));
        mRoomListPanel.DOMoveX(-mScreenX, mAnimSpeed).OnComplete(() => mRoomStatePanel.DOMoveX(mScreenX / 4, mAnimSpeed));

    }
    /// <summary>
    /// 返回房间列表UI动画
    /// </summary>
    private void ReturnRoomListAnim()
    {
        mReturnRoomListBtn.enabled = false;
        mReturnMainMenuBtn.gameObject.SetActive(true);

        mStartGameRect.DOMoveX(mScreenX * 2, mAnimSpeed).OnComplete(() => mCreateRoomRect.DOMoveX(mScreenX / 4 * 3, mAnimSpeed));
        mRoomStatePanel.DOMoveX(-mScreenX, mAnimSpeed).OnComplete(() => mRoomListPanel.DOMoveX(mScreenX / 4, mAnimSpeed));
    }
    /// <summary>
    /// update方法
    /// </summary>
    public override void Update()
    {
        base.Update();
        
        if (roomListData!=null|| IsCleanList==true)
        {            
            RefreshRoomListData();
        }
        if (mRoom!=null)
        {
            RefreshRoomStateData();
            ShowRoomStateUIAnim();
        }
        if (IsReturnRoomList==true)
        {
            IsReturnRoomList = false;
            ReturnRoomList();
        }

        if (IsInARoom == false) RefreshRoomListTimer -= Time.deltaTime;
        if (RefreshRoomListTimer<=0)
        {
            RefreshRoomListTimer = 10f;
            RefreshBtnOnClick();
        }
    }
    /// <summary>
    /// 房间列表刷新按钮点击事件
    /// </summary>
    private void RefreshBtnOnClick()
    {        
        mRoomListRequest.SendRequest();
    }
    /// <summary>
    /// 异步刷新房间列表
    /// </summary>
    public void LoadRoomListAsyn(List<RoomInfo> roomList)
    {
        if (roomList!=null)
        {
            roomListData = roomList;
        }
        else
        {
            IsCleanList = true;
        }       
    }
    /// <summary>
    /// 房间数据异步变更更新
    /// </summary>
    /// <param name="room"></param>
    public void RefreshRoomPlayersAsyn(RoomInfo room)
    {
        mRoom = room;
    }
    /// <summary>
    /// 销毁所有房间物体
    /// </summary>
    private void CleanRoomItem()
    {
        if (IsInARoom==false)
        {
            RoomListItemUI[] ritems = mRoomListLayout.GetComponentsInChildren<RoomListItemUI>();
            foreach (RoomListItemUI item in ritems)
            {
                item.DestorySelf();
            }
        }
        else
        {
            RoomPlayerItemUI[] pitems = mRoomStateLayout.GetComponentsInChildren<RoomPlayerItemUI>();
            foreach (RoomPlayerItemUI item in pitems)
            {
                item.DestorySelf();
            }
        }
        
    }
    /// <summary>
    /// 刷新房间列表
    /// </summary>
    private void RefreshRoomListData()
    {
        RefreshRoomListTimer = 10f;
        IsCleanList = false;
        CleanRoomItem();
        if (roomListData == null) return;

        int count = roomListData.Count;
        Vector2 size = mRoomListLayout.GetComponent<RectTransform>().sizeDelta;
        float prifabH = mRoomListItemPrefab.GetComponent<RectTransform>().sizeDelta.y;
        mRoomListLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(0, Mathf.Max( prifabH * count, size.y));

        for (int i = 0; i < count; i++)
        {
            GameObject roomItem = Instantiate(mRoomListItemPrefab);
            roomItem.GetComponent<RoomListItemUI>().SetRoomInfo(this, roomListData[i]);
            roomItem.SetActive(true);
            UnityTool.Attach(mRoomListLayout.gameObject, roomItem);
        }

        roomListData = null;
    }
    /// <summary>
    /// 刷新房间数据
    /// </summary>
    /// <param name="count"></param>
    private void RefreshRoomStateData()
    {
        CleanRoomItem();
        List<UserInfo> players = mRoom.Players;

        int count = players.Count;

        Vector2 size = mRoomStateLayout.GetComponent<RectTransform>().sizeDelta;
        float prifabH = mRoomListItemPrefab.GetComponent<RectTransform>().sizeDelta.y;
        mRoomStateLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(0, Mathf.Max(prifabH * count, size.y));

        for (int i = 0; i < count; i++)
        {
            GameObject PlayerItem = Instantiate(mRoomPlayerItemPrefab);
            PlayerItem.GetComponent<RoomPlayerItemUI>().SetPlayerInfo(players[i]);
            PlayerItem.SetActive(true);
            UnityTool.Attach(mRoomStateLayout.gameObject, PlayerItem);
        }

        mRoom = null;
    }
    /// <summary>
    /// 游戏模式一返回主菜单按钮点击事件
    /// </summary>
    private void ReturnMainMenuBtnOnClick()
    {

        mUIManager.PopPanel();
    }

    /// <summary>
    /// 处理房间数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public RoomInfo HandleRoomData(string data)
    {
        string[] strs = data.Split('.');
        int roomID = int.Parse(strs[0]);
        string roomNmae = strs[1];
        int roomLimit = int.Parse(strs[2]);

        List<UserInfo> players = new List<UserInfo>();
        string userName;
        int winCount;
        int totalCount;

        for (int i = 3; i < strs.Length; i++)
        {
            string[] user= strs[i].Split(',');
            userName = user[0];
            winCount= int.Parse(user[1]);
            totalCount = int.Parse(user[2]);

            players.Add(new UserInfo(userName, winCount, totalCount));
        }

        RoomInfo room = new RoomInfo(roomID, roomNmae, roomLimit, players.Count);
        room.SetPlayersInThisRoom(players);

        return room;
    }
}


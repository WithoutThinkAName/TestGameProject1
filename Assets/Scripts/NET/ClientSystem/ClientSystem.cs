using UnityEngine;
using System.Net.Sockets;
using System;
using Common;

/// <summary>
/// 客户端系统
/// </summary>
public class ClientSystem:IGameSystem
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket mClientSocket;
    private Message mMsg = new Message();

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        base.Init();

        mClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            mClientSocket.Connect(IP, PORT);
            StartReceive();
        }
        catch (Exception e)
        {
            Debug.Log("无法连接到服务器，网络不通。"+e);
            mClientSocket = null;
        }
    }
    /// <summary>
    /// 开始等待接收数据
    /// </summary>
    private void StartReceive()
    {
        mClientSocket.BeginReceive(mMsg.Data,mMsg.StartIndex,mMsg.RemainSize, SocketFlags.None,ReceiveCallBack,null);
    }
    /// <summary>
    /// 接收数据的回调
    /// </summary>
    /// <param name="ar"></param>
    private void ReceiveCallBack(IAsyncResult ar)
    {
        Debug.Log("接收");
        try
        {
            if (mClientSocket == null || mClientSocket.Connected == false) return;

            int count = mClientSocket.EndReceive(ar);
            mMsg.ReadMessage(count, OnProcessDataCallBack);

            StartReceive();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    /// <summary>
    /// 处理接收到的数据
    /// </summary>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
    private void OnProcessDataCallBack(ActionCode actionCode,string data)
    {
        Debug.Log("接收到的数据：" + data);
        mMainFacade.HandleRequest(actionCode, data);
    }
    /// <summary>
    /// 向服务器端发送数据
    /// </summary>
    /// <param name="requestCode"></param>
    /// <param name="actionCode"></param>
    /// <param name="data"></param>
    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] bytes = Message.PackDataRequestCode(requestCode, actionCode, data);
        Debug.Log("发送数据：" + data);
        if (mClientSocket==null)
        {
            GameMainFacade.Instance.ShowMessageUI("网络错误，未能连接到服务器。");
        }
        else
        {
            mClientSocket.Send(bytes);
        }        
    }
    /// <summary>
    /// 释放客户端
    /// </summary>
    public override void Release()
    {
        base.Release();
        try
        {
            mClientSocket.Close();
        }
        catch (Exception e)
        {

            Debug.Log("无法关闭网络连接。"+e);
        }
    }
}

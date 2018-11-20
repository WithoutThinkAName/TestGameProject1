using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using Common;

public class ClientSystem:IGameSystem
{
    private const string IP = "127.0.0.1";
    private const int PORT = 6688;

    private Socket mClientSocket;
    private Message mMsg = new Message();

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
        }
    }

    private void StartReceive()
    {
        mClientSocket.BeginReceive(mMsg.Data,mMsg.StartIndex,mMsg.RemainSize, SocketFlags.None,ReceiveCallBack,null);
    }

    private void ReceiveCallBack(IAsyncResult ar)
    {
        try
        {
            int count = mClientSocket.EndReceive(ar);
            mMsg.ReadMessage(count, OnProcessDataCallBack);

            StartReceive();
        }
        catch (Exception e)
        {

            Debug.Log(e);
        }
    }

    private void OnProcessDataCallBack(RequestCode resquestCode,string data)
    {
        mFacade.HandleRequest(resquestCode, data);
    }

    public void SendRequest(RequestCode requestCode,ActionCode actionCode,string data)
    {
        byte[] bytes = Message.PackDataRequestCode(requestCode, actionCode, data);
        mClientSocket.Send(bytes);
    }


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

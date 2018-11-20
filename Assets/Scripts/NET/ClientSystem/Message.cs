using System;
using System.Text;
using Common;
using System.Linq;

public class Message
{
    private byte[] data = new byte[1024];
    private int startIndex = 0;

    public byte[] Data
    {
        get { return data; }
    }
    public int StartIndex
    {
        get { return startIndex; }
    }

    public int RemainSize
    {
        get { return data.Length - startIndex; }
    }


    /// <summary>
    /// 读取，数据解析
    /// 4(数据长度)+4(requestCode)+4(actionCode)+数据主体
    /// </summary>
    public void ReadMessage(int newdataAmount, Action<RequestCode, string> processDataCallback)
    {
        startIndex += newdataAmount;
        while (true)
        {
            if (startIndex <= 4) return;

            int count = BitConverter.ToInt32(data, 0);//int32只会读4字节
            if ((startIndex - 4) >= count)
            {
                RequestCode requestCode = (RequestCode)BitConverter.ToInt32(data, 4);
                string s = Encoding.UTF8.GetString(data, 8, count - 4);
                processDataCallback(requestCode, s);
                Array.Copy(data, count + 4, data, 0, startIndex - count - 4);
                startIndex -= count + 4;
            }
            else
            {
                return;
            }
        }
    }

    public static byte[] PackDataRequestCode(RequestCode requestData,ActionCode actionCode, string data)
    {
        byte[] requestCodeBytes = BitConverter.GetBytes((int)requestData);
        byte[] actionCodeBytes = BitConverter.GetBytes((int)actionCode);
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        int dataAmount = requestCodeBytes.Length+ actionCodeBytes.Length + dataBytes.Length;

        byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
        dataAmountBytes.Concat(requestCodeBytes)
                        .Concat(actionCodeBytes)
                        .Concat(dataBytes);

        return dataAmountBytes;
    }

}


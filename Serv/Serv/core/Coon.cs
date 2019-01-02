﻿using System;
using System.Net;
using System.Net.Sockets;





public class Conn
{
    //常量
    public const int BUFFER_SIZE = 1024;
    //Socket
    public Socket socket;
    //是否使用
    public bool isUse = false;
    //Buff缓冲区
    public byte[] readBuff = new byte[BUFFER_SIZE];
    public int buffCount = 0;
    //沾包分包
    public byte[] lenBytes = new Byte[sizeof(UInt32)];
    public Int32 msgLength = 0;
    //心跳时间
    public long lastTickTime = long.MinValue;
    //对应的Player
    public Player player;

    public Conn()
    {
        readBuff = new byte[BUFFER_SIZE];
    }

    //初始化处理
    public void Init(Socket socket)
    {
        this.socket = socket;
        isUse = true;
        buffCount = 0;
        //心跳处理，稍后实现GetTimeStamp方法
        lastTickTime = Sys.GetTimeStamp();
    }
    //缓冲区剩余长度
    public int BuffRemain()
    {
        return BUFFER_SIZE - buffCount;
    }
    //获取客户端地址
    public string GetAddress()
    {
        if (!isUse)
        {
            return "无法获取地址";
        }
        return socket.RemoteEndPoint.ToString();
    }
    /// <summary>
    /// 关闭连接
    /// </summary>
    public void Close()
    {
        if (!isUse)
            return;
        if (player != null)
        {
            //玩家退出处理
            return;
        }
        Console.WriteLine("[断开连接]" + GetAddress());
        socket.Shutdown(SocketShutdown.Both);//禁用socket接受和发送
        socket.Close();
        isUse = false;
    }
    //发送协议，相关内容
    public void Send(ProtocolBase protocol)
    {
        ServNet.instance.Send(this, protocol);
    }





}
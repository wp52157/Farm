﻿using System;

public partial class HandleConnMsg
{
    //心跳
    //协议参数：无
    public void MsgHeatBeat(Conn conn, ProtocolBase protoBase)
    {
        conn.lastTickTime = Sys.GetTimeStamp();
        Console.WriteLine("[更新心跳时间]" + conn.GetAddress());
    }

    //注册
    //协议参数：str用户名,str密码
    //返回协议：-1表示失败 0表示成功
    public void MsgRegister(Conn conn, ProtocolBase protoBase)
    {
        //获取数值
        int start = 0;
        ProtocolBytes protocol = (ProtocolBytes)protoBase;
        string protoName = protocol.GetString(start, ref start);
        string id = protocol.GetString(start, ref start);
        string pw = protocol.GetString(start, ref start);
        string strFormat = "[收到注册协议]" + conn.GetAddress();
        Console.WriteLine(strFormat + " 用户名：" + id + " 密码：" + pw);
        //构建返回协议
        protocol = new ProtocolBytes();
        protocol.AddString("Register");
        //注册
        if (DataMgr.instance.Register(id, pw))
        {
            Console.WriteLine("注册成功");
            protocol.AddInt(1);
            Console.WriteLine("123456789");
        }
        else
        {
            protocol.AddInt(-1);
        }
        //创建玩家数据
        DataMgr.instance.CreatePlayerData(id,"12000","0","13","0","0","0");
        //返回协议给客户端
        conn.Send(protocol);
    }

    //登录
    //协议参数：str用户名,str密码
    //返回协议：-1表示失败 0表示成功
    public void MsgLogin(Conn conn, ProtocolBase protoBase)
    {
        //获取数值
        int start = 0;
        ProtocolBytes protocol = (ProtocolBytes)protoBase;
        string protoName = protocol.GetString(start, ref start);
        string id = protocol.GetString(start, ref start);
        string pw = protocol.GetString(start, ref start);
        string strFormat = "[收到登录协议]" + conn.GetAddress();
        Console.WriteLine(strFormat + " 用户名：" + id + " 密码：" + pw);
        //构建返回协议
        ProtocolBytes protocolRet = new ProtocolBytes();
        protocolRet.AddString("Login");
        //验证
        if (!DataMgr.instance.CheckPassWord(id, pw))
        {
            protocolRet.AddInt(-1);
            conn.Send(protocolRet);
            return;
        }
        ////是否已经登录
        //ProtocolBytes protocolLogout = new ProtocolBytes();
        //protocolLogout.AddString("Logout");
        //if (!Player.KickOff(id, protocolLogout))
        //{
        //    protocolRet.AddInt(-1);
        //    conn.Send(protocolRet);
        //    return;
        //}

        //获取玩家数据
        //PlayerData playerData = DataMgr.instance.GetPlayerData(id);
        //if (playerData == null)
        //{
        //    protocolRet.AddInt(-1);
        //    conn.Send(protocolRet);
        //    return;
        //}
        //conn.player = new Player(id, conn);
        //conn.player.data = playerData;
        //事件触发
        ServNet.instance.handlePlayerEvent.OnLogin(conn.player);

        //返回
        protocolRet.AddInt(1);
        conn.Send(protocolRet);
        Console.WriteLine("^^^^^^^^^^^^^666^^");
        return;
    }

    //下线
    //协议参数：
    //返回协议：0-正常下线
    public void MsgLogout(Conn conn, ProtocolBase protoBase)
    {
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Logout");
        protocol.AddInt(0);
        if (conn.player == null)
        {
            conn.Send(protocol);
            conn.Close();
        }
        else
        {
            conn.Send(protocol);
            conn.player.Logout();
        }
    }
    //SaveData
    public void MsgSaveData(Conn conn, ProtocolBase protoBase)
    {
        int start = 0;
        ProtocolBytes protocol = (ProtocolBytes)protoBase;
        string protoName = protocol.GetString(start, ref start);
        string id = protocol.GetString(start, ref start);
        string sj = protocol.GetString(start, ref start);
        string mff = protocol.GetString(start, ref start);
        string mkktd = protocol.GetString(start, ref start);
        string pttd = protocol.GetString(start, ref start);
        string jtd = protocol.GetString(start, ref start);
        string zstd = protocol.GetString(start, ref start);
        string strFormat = "[收到保存数据协议]" + conn.GetAddress();
        Console.WriteLine(strFormat + " 用户名：" + id + " 水晶：" + sj + "魔法粉：" + mff + "未开垦土地：" + mkktd + "普通土地：" + pttd + "金土地：" + jtd + "钻石土地：" + zstd);
        if (DataMgr.instance.SaveData(id, sj,mff,mkktd,pttd,jtd,zstd))
        {
            Console.WriteLine("注册成功");
            protocol.AddInt(1);
            Console.WriteLine("123456789");
        }
        else
        {
            protocol.AddInt(-1);
        }
    }
}
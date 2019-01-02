using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
public class LoginPanel : TTUIPage {
    Button loginbutton; //登录按钮
    Button regbutton;//注册按钮
    public static InputField  idInput;//ID输入框
    InputField pwInput;//密码文本框

    public LoginPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "LoginPanel";
    }
    public override void Awake(GameObject go)
    {
        base.Awake(go);
        loginbutton = transform.Find("LoginBtn").GetComponent<Button>();
        regbutton = transform.Find("RegBtn").GetComponent<Button>();
        idInput = transform.Find("IDInput").GetComponent<InputField>();
        pwInput = transform.Find("PWInput").GetComponent<InputField>();


        loginbutton.onClick.AddListener(OnLoginClik);
        regbutton.onClick.AddListener(OnRegClik);
    }
    public void OnLoginClik()
    {
        //用户名密码为空
        if (idInput.text == "" || pwInput.text == "")
        {
            ShowPage<TipPanel>("用户名密码不能为空!");
            return;
        }
        //连接服务器
        if (NetMgr.srvConn.status != Connection.Status.Connected)
        {
            string host = "127.0.0.1";
            int port = 1234;
            NetMgr.srvConn.proto = new ProtocolBytes();
            if (!NetMgr.srvConn.Connect(host, port))
            ShowPage<TipPanel>("连接服务器失败!");
        }
        //发送
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Login");
        protocol.AddString(idInput.text);
        protocol.AddString(pwInput.text);
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol, OnLoginBack);

        
    }

    public void OnLoginBack(ProtocolBase protocol)
    {
        ProtocolBytes proto = (ProtocolBytes)protocol;
        int start = 0;
        string protoName = proto.GetString(start, ref start);
        int ret = proto.GetInt(start, ref start);
        Debug.Log(ret);
        if (ret == 1)
        {
            ShowPage<MainPanel>();
            Hide();
        }
        else
        {
            ShowPage<TipPanel>("登录失败，请检查用户名密码!");
        }
    }

    public void OnRegClik()
    {
       
        ShowPage<RegPanel>();
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class RegPanel : TTUIPage
{

    private InputField idInput;
    private InputField pwInput;
    private Button regBtn;
    private Button closeBtn;
    private InputField repInput;
    private Text idtishiText;
    private Text pwtishiText;

    public RegPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "RegPanel";
    }

    public override void Awake(GameObject go)
    {
        idInput = transform.Find("IDInput").GetComponent<InputField>();
        pwInput = transform.Find("PWInput").GetComponent<InputField>();
        regBtn = transform.Find("RegBtn").GetComponent<Button>();
        closeBtn = transform.Find("CloseBtn").GetComponent<Button>();
        repInput = transform.Find("RepInput").GetComponent<InputField>();
        idtishiText = transform.Find("IDTiShiText").GetComponent<Text>();
        pwtishiText = transform.Find("PWTiShiText").GetComponent<Text>();

        regBtn.onClick.AddListener(OnRegClick);
        closeBtn.onClick.AddListener(OnCloseClick);




        idInput.onValueChanged.AddListener((s) => { idtishiText.gameObject.SetActive(true); });
        idInput.onEndEdit.AddListener(s => { idtishiText.gameObject.SetActive(false); });

        pwInput.onValueChanged.AddListener((s) => { pwtishiText.gameObject.SetActive(true); });
        pwInput.onEndEdit.AddListener(s => { pwtishiText.gameObject.SetActive(false); });
    }
   
    public void OnCloseClick()
    {
        ShowPage<LoginPanel>();
        Hide();
    }

    public void OnRegClick()
    {
        //用户名密码为空
        if (idInput.text == "" || pwInput.text == "")
        {
            ShowPage<TipPanel>("用户名密码不能为空!");
            return;
        }
        if (idInput.text.Length < 4 || idInput.text.Length > 20)
        {
            ShowPage<TipPanel>("用户名长度为4-20位");
            return;
        }
        if (pwInput.text.Length < 4 || pwInput.text.Length > 10)
        {
            ShowPage<TipPanel>("密码长度为4-10位");
            return;
        }

        //两次密码不同
        if (pwInput.text != repInput.text)
        {
            ShowPage<TipPanel>("两次输入的密码不同！");
            return;
        }
        //连接服务器
        if (NetMgr.srvConn.status != Connection.Status.Connected)
        {
            string host = "127.0.0.1";
            int port = 1234;
            NetMgr.srvConn.proto = new ProtocolBytes();
            if (!NetMgr.srvConn.Connect(host, port))
            {
                 ShowPage<TipPanel>("连接服务器失败!");
            }
        }
        //发送
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("Register");
        protocol.AddString(idInput.text);
        protocol.AddString(pwInput.text);
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol, OnRegBack);
    }

    public void OnRegBack(ProtocolBase protocol)
    {
        ProtocolBytes proto = (ProtocolBytes)protocol;
        int start = 0;
        string protoName = proto.GetString(start, ref start);
        int ret = proto.GetInt(start, ref start);
        Debug.Log(ret);
        if (ret == 1)
        {
            ShowPage<TipPanel>("注册成功");
            ShowPage<LoginPanel>();
            Hide();
        }
        else
        {
            ShowPage<TipPanel>("注册失败，请更换用户名");
        }
    }
}

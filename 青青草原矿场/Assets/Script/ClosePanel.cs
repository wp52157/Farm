using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
/// <summary>
/// 退出游戏
/// </summary>
public class ClosePanel : TTUIPage
{
    Button yesbutton;//退出按钮
    Button noButton;//返回按钮
    public ClosePanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "ClosePanel";
    }
    public override void Awake(GameObject go)
    {
        noButton = transform.Find("NoBtn").GetComponent<Button>();
        yesbutton = transform.Find("YesBtn").GetComponent<Button>();

        noButton.onClick.AddListener(OnNoClick);
        yesbutton.onClick.AddListener(OnYesClick);
    }

    private void OnNoClick()
    {
        Hide();
    }
    public void OnYesClick()
    {
        //保存数据
        ProtocolBytes protocol = new ProtocolBytes();
        protocol.AddString("SaveData");
        protocol.AddString(MainPanel.NiChengText.text);
        protocol.AddString(MainPanel.sj.text);
        protocol.AddString(MainPanel.mmf.text);
        protocol.AddString((13 - int.Parse(MianBanPanel.tudi1Text.text) - int.Parse(MianBanPanel.tudi1Text.text) - int.Parse(MianBanPanel.tudi1Text.text)).ToString());
        protocol.AddString(MianBanPanel.tudi1Text.text);
        protocol.AddString(MianBanPanel.tudi2Text.text);
        protocol.AddString(MianBanPanel.tudi3Text.text);
        
        Debug.Log("发送 " + protocol.GetDesc());
        NetMgr.srvConn.Send(protocol);

        //退出
        Application.Quit();
    }

    
}

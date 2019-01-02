using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class CangKuPanel : TTUIPage {
    Button closeButton;//关闭按钮
    Text greenGem;//绿水晶
    Text blueGem;//蓝水晶
    Text redGem;//红水晶
    Text vioGem;//紫水晶
    public CangKuPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "CangKuPanel";
    }

    public override void Awake(GameObject go)
    {
        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        greenGem = transform.Find("BaoShi").GetChild(0).GetChild(0).GetComponent<Text>();
        blueGem = transform.Find("BaoShi").GetChild(1).GetChild(0).GetComponent<Text>();
        redGem = transform.Find("BaoShi").GetChild(2).GetChild(0).GetComponent<Text>();
        vioGem = transform.Find("BaoShi").GetChild(3).GetChild(0).GetComponent<Text>();

        closeButton.onClick.AddListener(OnCloseCilck);
    }

    public void OnCloseCilck()
    {
        Hide();
    }
}

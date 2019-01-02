using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;

public class HaoYouPanel :  TTUIPage{

    Button CloseButton;//关闭按钮
    public HaoYouPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "HaoYouPanel";
    }
    public override void Awake(GameObject go)
    {
        CloseButton = transform.Find("CloseButton").GetComponent<Button>();

        CloseButton.onClick.AddListener(OnCloseClick);
    }

    private void OnCloseClick()
    {
        Hide();
    }
}

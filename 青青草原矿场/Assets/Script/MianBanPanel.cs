using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
public class MianBanPanel : TTUIPage {

    Text idText;
    Text nichengText;
    Text phonenumText;
    Text youxiangText;
    public static Text tudi1Text;
    public static Text tudi2Text;
    public static Text tudi3Text;
    Button TouXiangButton;
   public static Button closeButton;

    public MianBanPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "MianBanPanel";
    }


    public override void Awake(GameObject go)
    {
        idText =transform.Find("TouXiang").GetChild(0).GetChild(0).GetComponent<Text>();
        nichengText = transform.Find("MSG").GetChild(0).GetChild(0).GetComponent<Text>();
        phonenumText = transform.Find("MSG").GetChild(1).GetChild(0).GetComponent<Text>();
        youxiangText = transform.Find("MSG").GetChild(2).GetChild(0).GetComponent<Text>();
        tudi1Text = transform.Find("MSG").GetChild(3).GetChild(0).GetComponent<Text>();
        tudi2Text = transform.Find("MSG").GetChild(4).GetChild(0).GetComponent<Text>();
        tudi3Text = transform.Find("MSG").GetChild(5).GetChild(0).GetComponent<Text>();
        TouXiangButton = transform.Find("TouXiang").GetChild(2).GetComponent<Button>();
        closeButton = transform.Find("ColseButton").GetComponent<Button>();

        idText.text =LoginPanel.idInput.text;


        TouXiangButton.onClick.AddListener(OnTouXiangClick);
        closeButton.onClick.AddListener(OnCloseClick);
        }
    public void OnCloseClick()
    {
        Hide();
    }
    public void OnTouXiangClick()
    {
        ShowPage<TouXiangPanel>();
        closeButton.GetComponent<Button>().enabled = false; 
    }
       
}

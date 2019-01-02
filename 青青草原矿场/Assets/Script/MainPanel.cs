using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
public class MainPanel : TTUIPage {
    Button msgbutton;
    Button setUpbutton;
    Button caiJibutton;
    Button moFaPbutton;
    Button zhengZbutton;
    Button kaiKenbutton;
    Button cangKubutton;
    Button haoyoubutton;
    public static Text NiChengText;
    public static Text mmf;//魔法粉数量
    public static Text sj;//水晶数量

    public MainPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "MainPanel";
    }
    public override void Awake(GameObject go)
    {
        mmf = transform.Find("MFFImage").transform.GetChild(0).GetComponent<Text>();
        sj = transform.Find("SJImage").transform.GetChild(0).GetComponent<Text>();
        sj.text = 12000.ToString();
        mmf.text = 1000.ToString();
        NiChengText = GameObject.FindWithTag("ID").GetComponent<Text>();
        NiChengText.text = LoginPanel.idInput.text;
        haoyoubutton = transform.Find("AllButton").GetChild(0).GetChild(0).GetComponent<Button>();
        msgbutton = transform.Find("AllButton").GetChild(1).GetChild(0).GetComponent<Button>();
        setUpbutton = transform.Find("AllButton").GetChild(2).GetComponent<Button>();
        cangKubutton = transform.Find("AllButton").GetChild(7).GetComponent<Button>();

        caiJibutton = transform.Find("AllButton").GetChild(3).GetComponent<Button>();
        moFaPbutton= transform.Find("AllButton").GetChild(4).GetComponent<Button>();
        zhengZbutton= transform.Find("AllButton").GetChild(5).GetComponent<Button>();
        kaiKenbutton= transform.Find("AllButton").GetChild(6).GetComponent<Button>();


        haoyoubutton.onClick.AddListener(()=>ShowPage<HaoYouPanel>());
        msgbutton.onClick.AddListener(()=> ShowPage<MianBanPanel>());
        setUpbutton.onClick.AddListener(() => ShowPage<SetupPanel>());
        cangKubutton.onClick.AddListener(() => ShowPage<CangKuPanel>());

        //caiJibutton.onClick.AddListener(LandPanel.OnGatherClick);
        //moFaPbutton.onClick.AddListener(LandPanel.OnMagicClick);
        //zhengZbutton.onClick.AddListener(LandPanel.OnAddClick);
        //kaiKenbutton.onClick.AddListener(LandPanel.OnAssartClick);
       
    }
}

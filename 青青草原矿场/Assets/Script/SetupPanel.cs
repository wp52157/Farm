using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class SetupPanel : TTUIPage {

    Slider bgmslider;
    Slider buttonslider;
    Button closebutton;
    Button savebutton;
    public SetupPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "SetupPanel";

    }
    public override void Awake(GameObject go)
    {
        bgmslider = transform.Find("BGMSlider").GetComponent<Slider>();
        buttonslider = transform.Find("ButtonSlider").GetComponent<Slider>();
        closebutton =  transform.Find("CloseButton").GetComponent<Button>();
        savebutton = transform.Find("SaveButton").GetComponent<Button>();

        closebutton.onClick.AddListener(OnCloseClick);
        savebutton.onClick.AddListener(OnSaveClick);

        bgmslider.value = PlayerPrefs.GetFloat("BGMNum");
        buttonslider.value = PlayerPrefs.GetFloat("ButNum");
    }
    public void OnCloseClick()
    {
        Hide();
    }
    public void OnSaveClick()
    {
        PlayerPrefs.SetFloat("BGMNum",bgmslider.value);
        PlayerPrefs.SetFloat("ButNum", buttonslider.value);
        Hide();
    }

}

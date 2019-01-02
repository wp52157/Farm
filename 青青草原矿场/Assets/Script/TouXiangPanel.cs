using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
public class TouXiangPanel : TTUIPage {
    Button closeButton;
    Button saveButton;
    Button Button1;
    Button Button2;
    Button Button3;
    Button Button4;
    Button Button5;
    Button Button6;
    Button Button7;
    Button Button8;
   
  

    public TouXiangPanel() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
    {
        uiPath = "TouXiangPanel";
    }

    public override void Awake(GameObject go)
    {
        //mianbanclosebutton = GameObject.Find("TouXiangPanel").transform.GetChild(2).GetComponent<Button>();
        closeButton = transform.Find("CloseButton").GetComponent<Button>();
        saveButton = transform.Find("SaveButton").GetComponent<Button>();
        Button1 = transform.Find("TouXiang").GetChild(0).GetChild(1).GetComponent<Button>();
        Button2 = transform.Find("TouXiang").GetChild(1).GetChild(1).GetComponent<Button>();
        Button3 = transform.Find("TouXiang").GetChild(2).GetChild(1).GetComponent<Button>();
        Button4 = transform.Find("TouXiang").GetChild(3).GetChild(1).GetComponent<Button>();
        Button5 = transform.Find("TouXiang").GetChild(4).GetChild(1).GetComponent<Button>();
        Button6 = transform.Find("TouXiang").GetChild(5).GetChild(1).GetComponent<Button>();
        Button7 = transform.Find("TouXiang").GetChild(6).GetChild(1).GetComponent<Button>();
        Button8 = transform.Find("TouXiang").GetChild(7).GetChild(1).GetComponent<Button>();

        
       

        

        closeButton.onClick.AddListener(OnCloseClick);
        //saveButton.onClick.AddListener();
        Button1.onClick.AddListener(()=> {
            GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/11", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/11", typeof(Sprite)) as Sprite;
        });
        Button2.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/22", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/22", typeof(Sprite)) as Sprite;
        });
        Button3.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/33", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/33", typeof(Sprite)) as Sprite;
        });
        Button4.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/44", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/44", typeof(Sprite)) as Sprite;
        });
        Button5.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/55", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/55", typeof(Sprite)) as Sprite;
        });
        Button6.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/66", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/66", typeof(Sprite)) as Sprite;
        });
        Button7.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/77", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/77", typeof(Sprite)) as Sprite;
        });
        Button8.onClick.AddListener(() => { GameObject.FindWithTag("TouXiang").GetComponent<Image>().sprite = Resources.Load("picture/88", typeof(Sprite)) as Sprite;
            GameObject.FindWithTag("touxiang").GetComponent<Image>().sprite = Resources.Load("picture/88", typeof(Sprite)) as Sprite;
        });

       
    }
    public void OnCloseClick()
    {
       
        Hide();
        MianBanPanel.closeButton.enabled = true;
    }
}

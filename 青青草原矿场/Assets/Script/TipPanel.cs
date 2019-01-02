using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TinyTeam.UI;
public class TipPanel : TTUIPage
{
    private Text text;
    private Button btn;
    string str = "";
    public TipPanel() : base(UIType.PopUp, UIMode.DoNothing, UICollider.None)
    {

        uiPath = "TipPanel";
    }
  

    //初始化
    public override void Awake(GameObject go)
    {
         
        text = transform.Find("Text").GetComponent<Text>();
        //text.text = str;
        text.text = data.ToString();
        //关闭按钮
        btn = transform.Find("Btn").GetComponent<Button>();
        btn.onClick.AddListener(OnBtnClick);
    }
   

    //按下“知道了”按钮的事件
    public void OnBtnClick()
    {
        GameObject.Destroy(gameObject);
    }
}
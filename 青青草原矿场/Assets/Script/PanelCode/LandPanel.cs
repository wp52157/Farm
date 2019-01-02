using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class LandPanel :MonoBehaviour
{
    public  List<Land> landList ;//用来存储每块土地

    public  bool isAssart=false;//开垦按钮的转换，并让土地可以开垦

    //增种按钮
    public  Image AddImage;//增种画面
    public  InputField AddCry;//输入框
    public  Text ButName;//用于记录哪块土地
    public  int Cry;//用于修改土地水晶数量

    public int MainCry;//页面水晶数量
    public int MainMagic;//页面魔法粉数量

    public static ButtonEnum isButton = ButtonEnum.None;
    public enum ButtonEnum
    {
        None,Assart,Add,Magic,Gather
    }


    void Start()
    {
        foreach (Transform item in transform)
        {
            landList.Add(item.GetComponent<Land>());
            MainCry = System.Convert.ToInt32(MainPanel.sj.text);
            MainMagic = System.Convert.ToInt32(MainPanel.mmf.text);
        }
    }

    public  void AddCryClick()
    {
        AddImage.gameObject.SetActive(false);
        Cry = System.Convert.ToInt32(AddCry.text);
        for (int i = 0; i < landList.Count; i++)
        {
            if(landList[i].name==ButName.name&&MainCry>=Cry)
            {
                landList[i].crystal += Cry;
                landList[i].ChangeCrystal();
                MainCry -= Cry;
                ChangeCrystal();
            }
        }
    }
    public void ChangeCrystal()
    {
        MainPanel.sj.text = System.Convert.ToString(MainCry);
    }

    /// <summary>
    /// 开垦按钮绑定事件
    /// </summary>
    public  void OnAssartClick()
    {
        //当isAssart为false时让土地变红,否则变白
        if(isButton!=ButtonEnum.Assart)
        {
            for (int i = 0; i < landList.Count; i++)
            {
                if (landList[i].landLevel == Land.LandLevel.None)
                {
                    landList[i].GetComponent<Image>().color = Color.red;
                }
            }
            isAssart = true;
            isButton = ButtonEnum.Assart;
        }else
        {
            for (int i = 0; i < landList.Count; i++)
            {
                if (landList[i].landLevel == Land.LandLevel.None)
                {
                    landList[i].GetComponent<Image>().color = Color.white;
                }
            }
            isAssart = false;
            isButton = ButtonEnum.None;
        }

    }
    /// <summary>
    /// 增种按钮绑定事件
    /// </summary>
    public  void OnAddClick()
    {
        if(isButton!=ButtonEnum.Add)
        {
            isButton = ButtonEnum.Add;
        }
        else
        {
            isButton = ButtonEnum.None;
        }
    }
    /// <summary>
    /// 魔法粉按钮绑定事件
    /// </summary>
    public  void OnMagicClick()
    {
        if (isButton != ButtonEnum.Magic)
        {
            isButton = ButtonEnum.Magic;
        }
        else
        {
            isButton = ButtonEnum.None;
        }

    }
    /// <summary>
    /// 采集按钮绑定事件
    /// </summary>
    public  void OnGatherClick()
    {
        if (isButton != ButtonEnum.Gather)
        {
            isButton = ButtonEnum.Gather;
        }
        else
        {
            isButton = ButtonEnum.None;
        }
    }

}



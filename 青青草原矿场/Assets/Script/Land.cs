using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;

public class Land : MonoBehaviour {

    public LandPanel landParent;
    public int crystal=300;//土地水晶数量
    public List<Image> CryList;//水晶状态数组

    public string name;

    public MoFaFen Mofafen;
    public enum LandLevel
    {
        None,Normal,GodLand, DiamondLand
    }
    public LandLevel landLevel = LandLevel.None;

    void Start()
    {
        name = transform.name;
        foreach (Transform item in transform)
        {
            CryList.Add(item.GetComponent<Image>());
        }
        
    }
    void Update()
    {
        
    }
    /// <summary>
    /// 改变水晶的状态
    /// </summary>
    public void ChangeCrystal()
    {
        if (landLevel==LandLevel.Normal)
        {
            if (crystal < 500)
            {
                CryList[0].gameObject.SetActive(true);
                CryList[1].gameObject.SetActive(false);
                CryList[2].gameObject.SetActive(false);
                CryList[3].gameObject.SetActive(false);

            }
            else if(crystal>=500&&crystal<1000)
            {
                CryList[0].gameObject.SetActive(false);
                CryList[1].gameObject.SetActive(true);
                CryList[2].gameObject.SetActive(false);
                CryList[3].gameObject.SetActive(false);
            }
            else if(crystal>=1000&&crystal<1800)
            {
                CryList[0].gameObject.SetActive(false);
                CryList[1].gameObject.SetActive(false);
                CryList[2].gameObject.SetActive(true);
                CryList[3].gameObject.SetActive(false);
            }
            else
            {
                CryList[0].gameObject.SetActive(false);
                CryList[1].gameObject.SetActive(false);
                CryList[2].gameObject.SetActive(false);
                CryList[3].gameObject.SetActive(true);
            }

        }

    }
    /// <summary>
    /// 判断当前状态
    /// </summary>
    public void OnLandClick()
    {
        switch (LandPanel.isButton)
        {
            case LandPanel.ButtonEnum.None:
                break;
            case LandPanel.ButtonEnum.Assart:
                AssartBth();
                break;
            case LandPanel.ButtonEnum.Add:
                AddBth();
                break;
            case LandPanel.ButtonEnum.Magic:
                MagicBth();
                break;
            case LandPanel.ButtonEnum.Gather:
                GatherBth();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 开垦执行的方法
    /// </summary>
    public void AssartBth()
    {
        if (landParent.isAssart&&landParent.MainCry>=300&&landLevel==LandLevel.None)
        {
            Image ob = transform.Find("1").GetComponent<Image>();
            ob.gameObject.SetActive(true);
            gameObject.GetComponent<Image>().color = Color.white;
            Image icon = gameObject.GetComponent<Image>();
            Sprite sp = Resources.Load("Image/Tudi", typeof(Sprite)) as Sprite;
            icon.sprite = sp;
            landLevel = LandLevel.Normal;
            landParent.MainCry -= 300;
            landParent.ChangeCrystal();
        }
    }
    /// <summary>
    /// 增种执行的方法
    /// </summary>
    public void AddBth()
    {
        if(landLevel!=LandLevel.None)
        {
            landParent.AddImage.gameObject.SetActive(true);
            landParent.AddImage.transform.position = gameObject.transform.position;
            landParent.ButName.name = name;
        }
    }

    /// <summary>
    /// 魔法粉执行的方法
    /// </summary>
    public void MagicBth()
    {
        if(landLevel!=LandLevel.None)
        {
            Mofafen.gameObject.SetActive(true);
            Mofafen.isStart = true;
            Mofafen.transform.position = transform.position; 
        }
    }
    /// <summary>
    /// 采摘执行的方法
    /// </summary>
    public void GatherBth()
    {
        if (landLevel != LandLevel.None)
        {
            landParent.MainCry += (crystal - 300);
            crystal = 300;
            landParent.ChangeCrystal();

            ChangeCrystal();
        }
    }
}

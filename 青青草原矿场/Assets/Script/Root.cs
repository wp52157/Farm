using UnityEngine;
using System.Collections;
using TinyTeam.UI;
public class Root : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        TTUIPage.ShowPage<LoginPanel>();
        // TTUIPage.ShowPage<AssartPanel>();
        //TTUIPage.ShowPage<LandPanel>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TTUIPage.ShowPage<ClosePanel>();
        }
        NetMgr.Update();
    }
}

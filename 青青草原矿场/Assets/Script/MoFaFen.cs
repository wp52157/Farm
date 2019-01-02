using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoFaFen : MonoBehaviour {
    public bool isStart=false;

    public float time = 0;
    public float isTime = 0;
	void Start () {

	}
	

	void Update () {
        if(isStart==true)
        {
            time = Time.time;
            if ((isTime+2.5f) <time)
               {
                isStart = false;
                gameObject.SetActive(false);
                isTime = time;
                }
        }

	}
}

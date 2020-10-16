using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornGrow : MonoBehaviour
{
    int waterLevel, growlevel;
    

    float growtimer;
    float watertimer;
    // Start is called before the first frame update
    void Start()
    {
        waterLevel = 100;
        growlevel = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        growtimer += Time.deltaTime;
        watertimer += Time.deltaTime;
    }
    public void CanvasUpdate()
    {

    }
}

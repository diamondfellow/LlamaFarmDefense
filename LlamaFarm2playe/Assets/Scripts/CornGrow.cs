using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornGrow : MonoBehaviour
{
    int health;
    public int waterLevel, growlevel;
    
    GameObject waterBar;

    float growtimer;
    float watertimer;
    // Start is called before the first frame update
    void Start()
    {
        Transform trans = transform;
        Transform childtrans = trans.Find("WaterBar");
        if (childtrans != null)
        {
            waterBar = childtrans.gameObject;
        }
        waterLevel = 100;
        growlevel = 0;
        health = 3;

        GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
    }

    // Update is called once per frame
    void Update()
    {
        growtimer += Time.deltaTime;
        watertimer += Time.deltaTime;
        if (growtimer > GameController.GC.growMaxTimer)
        {
            GrowUpdate();
        }     
        if (watertimer > GameController.GC.waterMaxTimer)
        {
            if (waterLevel == 0)
            {
                growlevel = 3;
                GetComponent<SpriteRenderer>().sprite = GameController.GC.wilt;
            }
            waterLevel -= 1;
            WaterBarUpdate();
        }
    }
    void WaterBarUpdate()
    {
        if (waterLevel <= 100 && waterLevel > 80)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar4;
        }
        else if (waterLevel <= 80 && waterLevel > 60)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar3;
        }
        else if (waterLevel <= 60 && waterLevel > 40)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar2;
        }
        else if (waterLevel <= 40 && waterLevel > 20)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar1;
        }
        else if (waterLevel <= 20)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar0;
        }

    }
    void GrowUpdate()
    {              
           growtimer = 0;
           if (growlevel == 7)
           {
               growlevel = 0;
               GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
           }
           else if (growlevel == 6)
           {
               growlevel = 7;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.wilt;
           }
        else if (growlevel == 5)
        {
            growlevel = 6;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate6;
        }
        else if (growlevel == 4)
        {
            growlevel = 5;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate5;
        }
        else if (growlevel == 3)
        {
            growlevel = 4;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate4;
        }
        else if (growlevel == 2)
        {
            growlevel = 3;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate3;
        }
        else if (growlevel == 1)
        {
            growlevel = 2;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate2;
        }
        else if (growlevel == 0)
        {
            growlevel = 1;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate1;
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            growlevel = 0;
            GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
        }
    }
}

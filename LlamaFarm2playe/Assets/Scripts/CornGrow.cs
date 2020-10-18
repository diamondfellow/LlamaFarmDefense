using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CornGrow : MonoBehaviour
{
    int health;
    public int waterLevel, growlevel, growChance;
    
    GameObject waterBar;
    public GameObject gameController;
    
    float growtimer;
    float watertimer;
    // Start is called before the first frame update
    private void Awake()
    {
        //CReset();
    }
    void Start()
    {
        Transform trans = transform;
        Transform childtrans = trans.Find("WaterBar");
        if (childtrans != null)
        {
            waterBar = childtrans.gameObject;
        }
        CReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.GetComponent<GameController>().gameEnded)
        {
            growtimer += Time.deltaTime;
            watertimer += Time.deltaTime;
            if (growtimer > GameController.GC.growMaxTimer)
            {
                growtimer = 0;
                growChance += 3;
                float extraChance = waterLevel / 100;
                if(extraChance > 1)
                {
                    int transfer = Mathf.FloorToInt(extraChance);
                    growChance += transfer;
                }
                int check = Random.Range(growChance, 131);
                if (check >= 130)
                {
                    growChance = 0;
                    GrowUpdate();
                }
            }
            if (watertimer > GameController.GC.waterMaxTimer)
            {
                watertimer = 0;
                if (waterLevel < 0)
                {
                    CReset();
                }
                waterLevel -= Random.Range(1, 60);
                WaterBarUpdate();

            }
        }
    }
    public void WaterBarUpdate()
    {
        if (waterLevel > 800)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar4;
        }
        else if (waterLevel <= 800 && waterLevel > 600)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar3;
        }
        else if (waterLevel <= 600 && waterLevel > 400)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar2;
        }
        else if (waterLevel <= 400 && waterLevel > 200)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar1;
        }
        else if (waterLevel <= 200 && waterLevel > 50)
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar0;
        }
        else
        {
            waterBar.GetComponent<SpriteRenderer>().sprite = GameController.GC.Wbar00;
        }

    }
    void GrowUpdate()
    {              
           //growtimer = 0;
           if (growlevel == 7)
           {
               growlevel = 0;
               GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
            waterLevel = 1000;
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
            CReset();
        }
    }
    public void CReset()
    {
        health = 3;
        growlevel = 0;
        GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
        growChance = 0;
        waterLevel = 100;
        WaterBarUpdate();
    }
}

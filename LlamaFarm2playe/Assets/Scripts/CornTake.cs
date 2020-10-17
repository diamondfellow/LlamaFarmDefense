using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornTake : MonoBehaviour
{
    GameObject currentCorn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentCorn != null)
            {
                currentCorn.GetComponent<CornGrow>().growlevel = 0;
                currentCorn.GetComponent<CornGrow>().waterLevel = 100;
                currentCorn.GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
                if (currentCorn.GetComponent<CornGrow>().growlevel == 2)
                {
                    GameController.GC.cornAmountP1 += 3;
                }
                else if(currentCorn.GetComponent<CornGrow>().growlevel == 3)
                {
                    GameController.GC.cornAmountP1 += 1;
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CornP1")
        {
            currentCorn = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCorn = null;
    }
}

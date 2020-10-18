using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CornTake : MonoBehaviour
{
    GameObject currentCorn;
    Vector2 checkSize = new Vector2(.5f, .5f);
    public Text cornText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentCorn);
        cornText.text = PlayerPrefs.GetInt("Corn").ToString();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Collider2D[] cornCollision = Physics2D.OverlapBoxAll(transform.position, checkSize, 0);
            foreach (Collider2D collider in cornCollision)
            {
                Debug.Log(collider.gameObject);
                if (collider.gameObject.tag == "Corn")
                {
                    //Debug.Log("lemona");
                    //Debug.Log(collider.gameObject);

                    if (collider.gameObject.GetComponent<CornGrow>().growlevel == 6)
                    {
                        GameController.GC.cornAmountP1 += 5;
                        PlayerPrefs.SetInt("Corn", PlayerPrefs.GetInt("Corn") + 5);
                        collider.gameObject.GetComponent<CornGrow>().growlevel = 0;
                        collider.gameObject.GetComponent<CornGrow>().growChance = 0;
                        collider.gameObject.GetComponent<CornGrow>().waterLevel = 1000;
                        collider.gameObject.GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
                        //Debug.Log("test");
                    }
                    else if (collider.gameObject.GetComponent<CornGrow>().growlevel == 7)
                    {
                        GameController.GC.cornAmountP1 += 1;
                        PlayerPrefs.SetInt("Corn", PlayerPrefs.GetInt("Corn") + 1);
                        collider.gameObject.GetComponent<CornGrow>().growlevel = 0;
                        collider.gameObject.GetComponent<CornGrow>().growChance = 0;
                        collider.gameObject.GetComponent<CornGrow>().waterLevel = 1000;
                        collider.gameObject.GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
                        //Debug.Log("test2");
                    }
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Corn")
        {
            currentCorn = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCorn = null;
    }
}

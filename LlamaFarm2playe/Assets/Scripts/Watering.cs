using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public int waterlevel;
    public int maximumWater;
    float waterTimer;

    Collider2D[] collidedObjects;
    public Vector2 checkSize;
    // Start is called before the first frame update
    void Start()
    {
        waterlevel = maximumWater;
    }

    // Update is called once per frame
    void Update()
    {
        waterTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collidedObjects = Physics2D.OverlapBoxAll(transform.position, checkSize, 0);
            waterTimer = 0;
        }
        if (Input.GetKey(KeyCode.Space) && waterTimer > .3)
        {
            waterTimer = 0;
            //Debug.Log(collidedObjects[0]);
            foreach (Collider2D collider in collidedObjects)
            {
                if (collider.gameObject.tag == "Well" && waterlevel < maximumWater)
                {
                    waterlevel += 3;
                   // Debug.Log("broski");
                }
                if (collider.gameObject.tag == "Corn" && waterlevel > 0 && collider.gameObject.GetComponent<CornGrow>().waterLevel <= 1000)
                {
                    collider.gameObject.GetComponent<CornGrow>().waterLevel += 20;
                    //Debug.Log("broski2");
                    waterlevel -= 1;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (Collider2D collider in collidedObjects)
            {
                if (collider.gameObject.tag == "Corn")
                {
                    collider.gameObject.GetComponent<CornGrow>().WaterBarUpdate();
                }
            }
        }
    }
}

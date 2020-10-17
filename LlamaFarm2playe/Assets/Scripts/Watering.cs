using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    int waterlevel;
    public int maximumWater;
    Collider2D[] collidedObjects;
    public Vector2 checkSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            collidedObjects = Physics2D.OverlapBoxAll(transform.position, checkSize, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            foreach(Collider2D collider in collidedObjects)
            {
                if(collider.gameObject.tag == "Well" && waterlevel < maximumWater)
                {
                    waterlevel += 3;
                }
                if(collider.gameObject.tag == "CornP1" && waterlevel > 0 && collider.gameObject.GetComponent<CornGrow>().waterLevel <= 100)
                {
                    collider.gameObject.GetComponent<CornGrow>().waterLevel += 1;
                    waterlevel -= 1;
                }
            }
        }
    }
}

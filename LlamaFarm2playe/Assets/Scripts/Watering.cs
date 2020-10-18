using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watering : MonoBehaviour
{
    public float waterlevel;
    public int maximumWater;
    float waterTimer;
    public Slider waterSlider;

    Collider2D[] collidedObjects;
    public Vector2 checkSize;
    bool waterFill = false;
    // Start is called before the first frame update
    void Start()
    {
        waterlevel = maximumWater;
    }

    // Update is called once per frame
    void Update()
    {
        waterSlider.value = waterlevel;
        waterTimer += Time.deltaTime;
        if (waterFill && waterlevel < maximumWater)
        {
            waterlevel += 80 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collidedObjects = Physics2D.OverlapBoxAll(transform.position, checkSize, 0);
            waterTimer = 0;
            if (waterlevel > 0)
            {
                PlayerMovement.PC.Sprinkle();
            }
            PlayerMovement.PC.moveSpeed = PlayerMovement.PC.moveSpeed * .5f;
            Debug.Log(PlayerMovement.PC.moveSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && waterTimer > .3)
        {
            waterTimer = 0;
            collidedObjects = Physics2D.OverlapBoxAll(transform.position, checkSize, 0);
            //Debug.Log(collidedObjects[0]);
            foreach (Collider2D collider in collidedObjects)
            {
                /*
                if (collider.gameObject.tag == "Well" && waterlevel < maximumWater)
                {
                    waterlevel += 20;
                   // Debug.Log("broski");
                }
                */
                if (collider.gameObject.tag == "Corn" && waterlevel > 0 && collider.gameObject.GetComponent<CornGrow>().waterLevel <= 1000)
                {
                    collider.gameObject.GetComponent<CornGrow>().waterLevel += 100;
                    Debug.Log("broski2");
                    waterlevel -= 1;
                }
            }
        }
        if ((Input.GetKeyUp(KeyCode.Space) && PlayerMovement.PC.moveSpeed == 3) || (waterlevel == 0 && PlayerMovement.PC.moveSpeed == 3))
        {
            PlayerMovement.PC.NoSprinkle();
            PlayerMovement.PC.moveSpeed = PlayerMovement.PC.moveSpeed / .5f;
            foreach (Collider2D collider in collidedObjects)
            {
                
                if (collider.gameObject.tag == "Corn")
                {
                    collider.gameObject.GetComponent<CornGrow>().WaterBarUpdate();
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Well")
        {
            waterFill = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Well")
        {
            waterFill = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llama : MonoBehaviour
{
    GameObject[] corn;
    Vector3 distance;
    float shortestDistance = 999;
    GameObject shortestCorn;
    float longestDistance = 0;
    GameObject longestCorn;
    GameObject player;
    public float llamaSpeed;
    Vector2 walkDirection;
    bool arrived = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        corn = GameObject.FindGameObjectsWithTag("Corn");
        foreach (GameObject corn in corn)
        {
            distance.x = (Mathf.Abs(transform.position.x - corn.transform.position.x));
            distance.x = distance.x * distance.x;
            distance.y = (Mathf.Abs(transform.position.y - corn.transform.position.y));
            distance.y = distance.y * distance.y;
            distance.z = Mathf.Sqrt(distance.x + distance.y);
            if (distance.z < shortestDistance)
            {
                shortestDistance = distance.z;
                shortestCorn = corn;
            }
            if (distance.z > longestDistance)
            {
                longestDistance = distance.z;
                longestCorn = corn;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance.x = (Mathf.Abs(transform.position.x - player.transform.position.x));
        distance.x = distance.x * distance.x;
        distance.y = (Mathf.Abs(transform.position.y - player.transform.position.y));
        distance.y = distance.y * distance.y;
        distance.z = Mathf.Sqrt(distance.x + distance.y);
        if (gameObject.name == "Llama(Clone)")
        {
            if (distance.z > 4 && !arrived)
            {
                walkDirection = new Vector2(shortestCorn.transform.position.x - transform.position.x, shortestCorn.transform.position.y - transform.position.y);
                walkDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
            }
            else if (distance.z < 3)
            {
                walkDirection = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
                walkDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        else if (gameObject.name == "LaserLlama(Clone)")
        {
            if (distance.z > 4)
            {
                walkDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                walkDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
            }
            else if (distance.z < 3)
            {
                walkDirection = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
                walkDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if (distance.z < 5 && distance.z > 1.5f)
            {
                GetComponent<LlamaLaser>().enabled = true;
            }
            else
            {
                GetComponent<LlamaLaser>().enabled = false;
            }
        }
        else
        {
            if (distance.z > 2 && !arrived)
            {
                walkDirection = new Vector2(longestCorn.transform.position.x - transform.position.x, longestCorn.transform.position.y - transform.position.y);
                walkDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
            }
            else if (distance.z < 1)
            {
                walkDirection = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
                walkDirection.Normalize();
                GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }

        if (transform.position.x > 9.2f || transform.position.x < -9.2f || transform.position.y > 5.2f || transform.position.y < -5.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.name == "Llama(Clone)" && collision.gameObject == shortestCorn)
        {
            arrived = true;
        }
        else if (gameObject.name == "JuggerLlama(Clone)" && collision.gameObject == longestCorn)
        {
            arrived = true;
        }
        if (gameObject.name == "JuggerLlama(Clone)" && !arrived)
        {
            if (collision.gameObject.TryGetComponent<CornGrow>(out CornGrow cornGrow))
            {
                cornGrow.growlevel = 0;
                cornGrow.gameObject.GetComponent<SpriteRenderer>().sprite = GameController.GC.Gstate0;
                cornGrow.growChance = 0;
                cornGrow.waterLevel = 1000;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "Llama(Clone)" && collision.gameObject == shortestCorn)
        {
            arrived = false;
        }
        else if (gameObject.name == "JuggerLlama(Clone)" && collision.gameObject == longestCorn)
        {
            arrived = false;
        }
    }
    // called from animation event
    public void Attack()
    {

    }
}

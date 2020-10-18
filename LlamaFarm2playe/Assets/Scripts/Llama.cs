using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Llama : MonoBehaviour
{
    GameObject[] corn;
    Vector3 playerToLlamaDistance;
    Vector3 llamaToCornDistance;
    Vector3 playerToCornDistance;
    float shortestDistance;
    GameObject shortestCorn;
    float longestDistance;
    GameObject longestCorn;
    GameObject player;
    public float llamaSpeed;
    Vector2 walkDirection;
    bool arrived = false;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        corn = GameObject.FindGameObjectsWithTag("Corn");
        gameController = GameObject.FindGameObjectWithTag("MainCamera");
        shortestDistance = 999;
        longestDistance = 0;
        FindCorn();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody2D>().velocity.x == 0 && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Animator>().SetBool("idle", true);
        }
        else if(GetComponent<Rigidbody2D>().velocity.x != 0 && GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            GetComponent<Animator>().SetBool("idle", false);
        }
        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (!gameController.GetComponent<GameController>().gameEnded)
        {
            playerToLlamaDistance.x = (Mathf.Abs(transform.position.x - player.transform.position.x));
            playerToLlamaDistance.x = playerToLlamaDistance.x * playerToLlamaDistance.x;
            playerToLlamaDistance.y = (Mathf.Abs(transform.position.y - player.transform.position.y));
            playerToLlamaDistance.y = playerToLlamaDistance.y * playerToLlamaDistance.y;
            playerToLlamaDistance.z = Mathf.Sqrt(playerToLlamaDistance.x + playerToLlamaDistance.y);
            PlayerCorn();
            if (gameObject.name == "Llama(Clone)")
            {
                
                if (playerToLlamaDistance.z > 4 && !arrived)
                {
                    walkDirection = new Vector2(shortestCorn.transform.position.x - transform.position.x, shortestCorn.transform.position.y - transform.position.y);
                    walkDirection.Normalize();
                    GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
                }
                else if (playerToLlamaDistance.z < 3)
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
                if (playerToLlamaDistance.z > 4)
                {
                    walkDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
                    walkDirection.Normalize();
                    GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
                }
                else if (playerToLlamaDistance.z < 3)
                {
                    walkDirection = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
                    walkDirection.Normalize();
                    GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }

                if (playerToLlamaDistance.z < 5 && playerToLlamaDistance.z > 1.5f)
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
                if (playerToLlamaDistance.z > 3 && !arrived)
                {
                    walkDirection = new Vector2(longestCorn.transform.position.x - transform.position.x, longestCorn.transform.position.y - transform.position.y);
                    walkDirection.Normalize();
                    GetComponent<Rigidbody2D>().velocity = walkDirection * llamaSpeed;
                }
                else if (playerToLlamaDistance.z < 2)
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
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.name == "Llama(Clone)" && collision.gameObject == shortestCorn)
        {
            arrived = true;
            GetComponent<Animator>().SetBool("at corn", true);
        }
        else if (gameObject.name == "JuggerLlama(Clone)" && collision.gameObject == longestCorn)
        {
            arrived = true;
            GetComponent<Animator>().SetBool("at corn", true);
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
            arrived = false; GetComponent<Animator>().SetBool("at corn", false);
        }
        else if (gameObject.name == "JuggerLlama(Clone)" && collision.gameObject == longestCorn)
        {
            arrived = false;
            GetComponent<Animator>().SetBool("at corn", false);
        }
    }
    // called from animation event
    public void Attack()
    {
        if (arrived)
        {
            if(gameObject.name == "Llama(Clone)")
            {
                shortestCorn.GetComponent<CornGrow>().Damage(1);
            }
            else if (gameObject.name == "JuggerLlama(Clone)")
            {
                shortestCorn.GetComponent<CornGrow>().Damage(3);
            }
        }
    }

    void FindCorn()
    {
        foreach (GameObject corn in corn)
        {
            llamaToCornDistance.x = (Mathf.Abs(transform.position.x - corn.transform.position.x));
            llamaToCornDistance.x = llamaToCornDistance.x * llamaToCornDistance.x;
            llamaToCornDistance.y = (Mathf.Abs(transform.position.y - corn.transform.position.y));
            llamaToCornDistance.y = llamaToCornDistance.y * llamaToCornDistance.y;
            llamaToCornDistance.z = Mathf.Sqrt(llamaToCornDistance.x + llamaToCornDistance.y);
            playerToCornDistance.x = (Mathf.Abs(player.transform.position.x - corn.transform.position.x));
            playerToCornDistance.x = playerToCornDistance.x * playerToCornDistance.x;
            playerToCornDistance.y = (Mathf.Abs(player.transform.position.y - corn.transform.position.y));
            playerToCornDistance.y = playerToCornDistance.y * playerToCornDistance.y;
            playerToCornDistance.z = Mathf.Sqrt(playerToCornDistance.x + playerToCornDistance.y);
            if (llamaToCornDistance.z < shortestDistance && playerToCornDistance.z < 3)
            {
                shortestDistance = llamaToCornDistance.z;
                shortestCorn = corn;
            }
            if (llamaToCornDistance.z > longestDistance && playerToCornDistance.z < 2)
            {
                longestDistance = llamaToCornDistance.z;
                longestCorn = corn;
            }
        }
    }

    void PlayerCorn()
    {
        if (gameObject.name == "Llama(Clone)")
        {
            playerToCornDistance.x = (Mathf.Abs(player.transform.position.x - shortestCorn.transform.position.x));
            playerToCornDistance.x = playerToCornDistance.x * playerToCornDistance.x;
            playerToCornDistance.y = (Mathf.Abs(player.transform.position.y - shortestCorn.transform.position.y));
            playerToCornDistance.y = playerToCornDistance.y * playerToCornDistance.y;
            playerToCornDistance.z = Mathf.Sqrt(playerToCornDistance.x + playerToCornDistance.y);
            if (playerToCornDistance.z < 3)
            {
                shortestDistance = 99;
                FindCorn();
            }
        }
        else if (gameObject.name == "JuggerLlama(Clone)")
        {
            playerToCornDistance.x = (Mathf.Abs(player.transform.position.x - longestCorn.transform.position.x));
            playerToCornDistance.x = playerToCornDistance.x * playerToCornDistance.x;
            playerToCornDistance.y = (Mathf.Abs(player.transform.position.y - longestCorn.transform.position.y));
            playerToCornDistance.y = playerToCornDistance.y * playerToCornDistance.y;
            playerToCornDistance.z = Mathf.Sqrt(playerToCornDistance.x + playerToCornDistance.y);
            if (playerToCornDistance.z < 2)
            {
                longestDistance = 0;
                FindCorn();
            }
        }
    }
}

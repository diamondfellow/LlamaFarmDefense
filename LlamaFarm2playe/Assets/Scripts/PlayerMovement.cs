using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float timer;
    public bool frozen = false;
    bool beginFreeze = true;
    public GameObject gameController;
    public static PlayerMovement PC;
    // Start is called before the first frame update
    private void Awake()
    {
        PC = this;
    }
    void Start()
    {
       beginFreeze = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.x == 0 && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Animator>().SetBool("idle", true);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x != 0 || GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            GetComponent<Animator>().SetBool("idle", false);
        }
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (!frozen && !beginFreeze)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector2 velocity = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = velocity * moveSpeed;
        }
        else if (!gameController.GetComponent<GameController>().gameEnded)
        {
            timer += Time.deltaTime;
            if (timer > .5f)
            {
                timer = 0;
                frozen = false;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector3(7.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.5f)
        {
            transform.position = new Vector3(-7.5f, transform.position.y, 0);
        }
        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }
        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "E_Bullet")
        {
            timer = 0;
            frozen = true;
            Destroy(collision.gameObject);
        }
    }
    public void CanMove()
    {
        beginFreeze = false;
    }
    public void Sprinkle()
    {
        GetComponent<Animator>().SetBool("sprinkle", true);
    }
    public void NoSprinkle()
    {
        GetComponent<Animator>().SetBool("sprinkle", false);
    }
}

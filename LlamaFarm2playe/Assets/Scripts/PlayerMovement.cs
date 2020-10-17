using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    float timer;
    bool frozen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector2 velocity = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = velocity * moveSpeed;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > .5f)
            {
                timer = 0;
                frozen = false;
            }
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
            frozen = true;
            Destroy(collision.gameObject);
        }
    }
}

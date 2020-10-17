using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaLaser : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject player;
    public float bulletSpeed = 7f;
    public float playerDistanceMin = 1;
    public float bulletLifetime = .75f;
    public float shootDelay = 1;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 shootDirection = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        float playerDistance = shootDirection.magnitude;
        timer += Time.deltaTime;
        if (timer > shootDelay && playerDistance < playerDistanceMin)
        {
            shootDirection.Normalize();
            Vector3 spawnPosition = transform.position;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            timer = 0;
        }
    }
}

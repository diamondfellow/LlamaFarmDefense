using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaController : MonoBehaviour
{
    float gameTimer;
    float llamaTimer;
    int difficulty = 1;
    public GameObject llama;
    public GameObject laserLlama;
    public GameObject juggerLlama;
    int x;
    int llamaChooser;
    System.Random rnd = new System.Random();

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        llamaTimer += Time.deltaTime;
        if (gameTimer > 29)
        {
            gameTimer = 0;
            difficulty++;
        }
        if (llamaTimer > 12 - difficulty && difficulty < 7)
        {
            llamaTimer = 0;
            if (rnd.Next(1, 3) == 1)
            {
                x = 9;
            }
            else
            {
                x = -9;
            }
            if (difficulty > 3)
            {
                llamaChooser = rnd.Next(1, 9);
                if (llamaChooser < 3)
                {
                    Instantiate(llama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
                }
                else if (llamaChooser > 5)
                {
                    Instantiate(juggerLlama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(laserLlama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
                }
            }
            else if (difficulty > 1)
            {
                llamaChooser = rnd.Next(1, 6);
                if (llamaChooser == 1)
                {
                    Instantiate(laserLlama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
                }
                else if (llamaChooser == 2)
                {
                    Instantiate(juggerLlama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(llama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
                }
            }
            else
            {
                Instantiate(llama, new Vector3(x, rnd.Next(-45, 46) / 10, 0), Quaternion.identity);
            }
        }
    }
}

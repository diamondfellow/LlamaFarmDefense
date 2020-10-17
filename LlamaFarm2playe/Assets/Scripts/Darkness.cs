using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Darkness : MonoBehaviour
{
    public GameObject gameController;
    public Color color;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.GetComponent<GameController>().gameEnded)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                color.a += Time.deltaTime * .5f;
                GetComponent<Image>().color = color;
                if (color.a > 1)
                {
                    SceneManager.LoadScene("EndScene");
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Buttons : MonoBehaviour
{
    public GameObject grey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GetComponent<Canvas>().enabled)
            {
                Resume();
            }
            else
            {
                Time.timeScale = 0;
                grey.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Canvas>().enabled = true;
            }
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("Corn", 0);
        SceneManager.LoadScene("GameScene");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        grey.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Canvas>().enabled = false;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Buttons : MonoBehaviour
{
    public GameObject grey;
    public AudioSource music;
    public Toggle musicOn;
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
        PlayerPrefs.SetFloat("MusicTime", music.GetComponent<AudioSource>().time);
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
        PlayerPrefs.SetFloat("MusicTime", music.GetComponent<AudioSource>().time);
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        PlayerPrefs.SetFloat("MusicTime", 0);
        Application.Quit();
    }
    public void Options()
    {
        PlayerPrefs.SetFloat("MusicTime", music.GetComponent<AudioSource>().time);
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        PlayerPrefs.SetFloat("MusicTime", music.GetComponent<AudioSource>().time);
        SceneManager.LoadScene("Credits");
    }
}

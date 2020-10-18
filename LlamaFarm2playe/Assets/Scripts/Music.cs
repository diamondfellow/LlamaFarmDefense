using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Music : MonoBehaviour
{
    public Toggle music;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().time = PlayerPrefs.GetFloat("MusicTime");
        if (PlayerPrefs.GetInt("Mute") == 1)
        {
            music.isOn = false;
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Options")
        {
            if (music.isOn)
            {
                PlayerPrefs.SetInt("Mute", 0);
                GetComponent<AudioSource>().mute = false;
            }
            else
            {
                PlayerPrefs.SetInt("Mute", 1);
                GetComponent<AudioSource>().mute = true;
            }
        }
        else if (PlayerPrefs.GetInt("Mute") == 1)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
        }
    }
}

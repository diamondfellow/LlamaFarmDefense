using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "You harvested " + PlayerPrefs.GetInt("Corn") + " corn!";
    }

    public void BrowserOpen()
    {
        System.Diagnostics.Process.Start("https://www.feedingamerica.org/find-your-local-foodbank");
    }
}

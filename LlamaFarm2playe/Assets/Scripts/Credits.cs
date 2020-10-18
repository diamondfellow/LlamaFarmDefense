using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour
{
    List<string> names = new List<string>();
    int rnd;
    public Text first;
    public Text second;
    public Text third;
    public Text fourth;

    // Start is called before the first frame update
    void Start()
    {
        names.Add("Conner Anderson - Programming");
        names.Add("Griffin Gaskins - Art");
        names.Add("Brianna Simpson - Art");
        names.Add("Taran Zorn - Programming");

        rnd = Random.Range(0, 4);
        first.text = names[rnd];
        names.RemoveAt(rnd);
        rnd = Random.Range(0, 3);
        second.text = names[rnd];
        names.RemoveAt(rnd);
        rnd = Random.Range(0, 2);
        third.text = names[rnd];
        names.RemoveAt(rnd);
        fourth.text = names[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

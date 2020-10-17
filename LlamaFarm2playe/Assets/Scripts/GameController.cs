using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GC;
    public int cornAmountP1;

    float Gametimer;
    float resetTimer;
    public int GameTime;

    Canvas mainCanvas;
    public Slider waterlevel;
    public Text cornAmount1;
    public Text gameTimerText;

    #region sprites
    public Sprite Wbar0;
    public Sprite Wbar1;
    public Sprite Wbar2;
    public Sprite Wbar3;
    public Sprite Wbar4;

    public Sprite Gstate0;
    public Sprite Gstate1;
    public Sprite Gstate2;
    public Sprite Gstate3;
    public Sprite Gstate4;
    public Sprite Gstate5;
    public Sprite Gstate6;
    public Sprite wilt;
    #endregion

    public float waterMaxTimer;
    public float growMaxTimer;

    int minutes = 3;
    int seconds = 00;

    // Start is called before the first frame update
    private void Awake()
    {
        GC = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gametimer += Time.deltaTime;
        resetTimer += Time.deltaTime;
        if(Gametimer > GameTime)
        {
            EndGame();
        }
        if (resetTimer > 1)
        {
            resetTimer = 0;
            if (seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }
            if (seconds > 9)
            {
                gameTimerText.text = minutes + ":" + seconds;
            }
            else
            {
                gameTimerText.text = minutes + ":0" + seconds;
            }
        }
    }
    void EndGame()
    {

    }
}

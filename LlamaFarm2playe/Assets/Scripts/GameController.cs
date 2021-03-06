﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GC;
    public int cornAmountP1;

    float Gametimer = 0;
    float resetTimer;
    int GameTime = 120;

    Canvas mainCanvas;
    public Slider waterlevel;
    public Text cornAmount1;
    public Text gameTimerText;
    public Image gameTimerImage;

    #region sprites
    public Sprite Wbar00;
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

    public Sprite timer2;
    public Sprite timer3;
    public Sprite timer4;
    #endregion

    public float waterMaxTimer;
    public float growMaxTimer;

    int minutes = 2;
    int seconds = 00;
    public bool gameEnded;
    public GameObject player;

    // Start is called before the first frame update
    private void Awake()
    {
        GC = this;
        gameEnded = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gametimer += Time.deltaTime;
        resetTimer += Time.deltaTime;
        if (Gametimer > GameTime)
        {
            EndGame();
        }
        if (Gametimer > 90)
        {
            gameTimerImage.GetComponent<Image>().sprite = timer4;
        }
        else if (Gametimer > 60)
        {
            gameTimerImage.GetComponent<Image>().sprite = timer3;
        }
        else if (Gametimer > 30)
        {
            gameTimerImage.GetComponent<Image>().sprite = timer2;
        }
        if (resetTimer > 1 && (minutes > 0 || seconds > 0))
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
        gameEnded = true;
        player.GetComponent<PlayerMovement>().frozen = true;
    }
}

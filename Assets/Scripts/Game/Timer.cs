using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timer;
    public bool running;
    public GameStarter gameEnder;
    public TextMeshPro text;

    private float lerpTime;
    //private bool startLerp;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            Debug.Log("Timer is Running");
            timer -= 1 * Time.deltaTime;

            text.SetText(Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00"));

            
            if (timer <= 0)
            {
                text.SetText("");
                running = false;
                GameSettings.gameInPlay = false;
                gameEnder.ChangeGame();
                lerpTime = 1;
                //LerpDown();
            }
        }
        else if(!running && lerpTime >= 0)
        {
            LerpDown();
        }
        

    }

    private void LerpDown()
    {

        lerpTime -= Time.deltaTime * lerpSpeed;
        CurrentSong.discoValue = lerpTime;

    }

    public void SetTimer()
    {
        
        timer = GameSettings.gameDuration * 60f;
        text.SetText(Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00"));
        //lerpTime = 1;
        

    }

    public void StartTimer()
    {
        GameSettings.gameInPlay = true;
        running = true;

    }

    public void StopTimer()
    {
        GameSettings.gameInPlay = false;
        running = false;
        text.SetText("");
    }
}

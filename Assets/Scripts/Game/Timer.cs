using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timer;
    public bool running;
    public GameStarter gameEnder;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            Debug.Log("Timer is Running");
            timer -= 1 * Time.deltaTime;

            text.SetText(Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00"));

            //text.SetText((timer / 60).ToString("00") + ":" + (timer % 60).ToString("00"));
            //text.SetText(timer.ToString("00"));
            if (timer <= 0)
            {
                text.SetText("");
                running = false;
                GameSettings.gameInPlay = false;
                gameEnder.ChangeGame();
            }
        }
    }

    public void SetTimer()
    {
        
        timer = GameSettings.gameDuration * 60f;
        text.SetText(Mathf.Floor(timer / 60).ToString("00") + ":" + Mathf.FloorToInt(timer % 60).ToString("00"));
        //running = true;

    }

    public void StartTimer()
    {
        GameSettings.gameInPlay = true;
        running = true;

    }
}

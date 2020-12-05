using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    public bool running;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0)
                running = false;
        }
    }

    public void SetTimer()
    {
        
        timer = GameSettings.gameDuration * 60f;


    }
}

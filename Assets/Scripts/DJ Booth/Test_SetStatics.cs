using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SetStatics : MonoBehaviour
{
    public Crowd crowd;
    public int score;
    public int color;

    private void Awake()
    {
        CurrentSong.selectedCrowd = crowd;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        CurrentSong.currentColor = color;
        score = CurrentSong.gameScore;

    }
}

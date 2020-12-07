using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SetStatics : MonoBehaviour
{
    public Crowd crowd;
    public int score;
    public int color;

    [Header("Active Modifier")]
    public int mod0;
    public int mod1;
    public int mod2;
    public int mod3;

    [Header("Game Settings")]
    public float timer;


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
        //GameSettings.gameDuration = timer;

        CurrentSong.currentColor = color;
        score = CurrentSong.gameScore;
        mod0 = CurrentSong.currentModifier_0;
        mod1 = CurrentSong.currentModifier_1;
        mod2 = CurrentSong.currentModifier_2;
        mod3 = CurrentSong.currentModifier_3;


    }
}

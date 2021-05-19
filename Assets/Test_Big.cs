using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Big : MonoBehaviour
{

    public GameStarter gs;

    public bool tester;
    public Crowd crwd;
    public GameToFmod fmd;
    public Score_Script sscript;
    public int mnu;
    [Range(0, 3)]
    public int songCat;
    [Range(0,1)]
    public int mod0;
    [Range(0, 1)]
    public int mod1;
    [Range(0, 1)]
    public int mod2;
    [Range(0, 1)]
    public int mod3;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && !GameSettings.gameInPlay )
        {
            CurrentSong.discoValue = 1;
            fmd.menu = mnu;
            gs.ChangeGame();
            GameSettings.gameDuration = 10;
        }
        if(tester)
        {
            CurrentSong.selectedCrowd = crwd;
            CurrentSong.songPlaying = songCat;
            CurrentSong.currentModifier_0 = mod0;
            CurrentSong.currentModifier_1 = mod1;
            CurrentSong.currentModifier_2 = mod2;
            CurrentSong.currentModifier_3 = mod3;
        }

        score = sscript._Score;
        

    }
}

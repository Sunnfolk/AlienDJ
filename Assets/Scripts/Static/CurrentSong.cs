using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CurrentSong
{

    //Variables about the current song being played
    public static int songPlaying;
    public static int currentModifier_0;
    public static int currentModifier_1;
    public static int currentModifier_2;
    public static int currentModifier_3;
    public static int currentColor;

    public static Crowd selectedCrowd;
    public static int gameScore;
    
}

enum Modifier
{
    mod0,
    mod1,
    mod2,
    mod3
}

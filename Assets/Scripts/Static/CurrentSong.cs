﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public static class CurrentSong
{

    //Variables about the current song being played
    public static int songPlaying;
    public static int currentModifier_0;
    public static int currentModifier_1;
    public static int currentModifier_2;
    public static int currentModifier_3;
    public static int currentColor;

    public static float discoValue;


    public static Crowd selectedCrowd;
    public static int gameScore;
    public static int crowdDesire;
}

enum Modifier
{
    mod0,
    mod1,
    mod2,
    mod3
}

enum LightColor
{
    blue,
    green,
    yellow,
    red
}

enum Song
{
    chill,
    calm,
    energetic,
    aggressive
}
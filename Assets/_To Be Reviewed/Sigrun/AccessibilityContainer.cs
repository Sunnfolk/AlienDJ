﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public static class AccessibilityContainer
{
    //Changes Text
    public static TMP_FontAsset fontInUse; //the current font
    public static int fontSizeMulitplier = 10; //how much the font should increase by, a multiplier so the ratio stays the same
    public static int fontMultiplierMaxSize = 2; //so the text has a max sixe


    //Changes Colors
    public static Color aggressive; //contains the color used for this mood
    public static Color energetic; //contains the color used for this mood
    public static Color calm; //contains the color used for this mood
    public static Color chill; //contains the color used for this mood


    //The photosensitivity settings
    public static bool hyperspaceEnabled = true;
    public static bool lightshowsEnabled = true;
}

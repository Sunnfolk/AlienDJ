using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeFont : MonoBehaviour
{
    public TMP_FontAsset dyslexia; //the dyslexic friendly font
    public TMP_FontAsset standard; //The "standard" font

    public static bool fontchange;

    [SerializeField] private int fontSizeMultiplierChange = 1; //how much the multiplier changes with per press

    public void ButtonDyslexia()
    {
        AccessibilityContainer.fontInUse = dyslexia; //on button press change the font in the container
        fontchange = true; //make setfont update the fonts
        Invoke("boolFlip", 1f);
    }

    public void ButtonStandard()
    {
        AccessibilityContainer.fontInUse = standard;//on button press change the font in the container
        fontchange = true; //make setfont update the fonts
        Invoke("boolFlip", 1f);
    }

    public void ButtonSizeUp()
    {
        AccessibilityContainer.fontSizeMulitplier = AccessibilityContainer.fontSizeMulitplier + fontSizeMultiplierChange; //increase the multiplier
        if (AccessibilityContainer.fontSizeMulitplier > AccessibilityContainer.fontMultiplierMaxSize) //don't increase the multiplier past pax
            AccessibilityContainer.fontSizeMulitplier = AccessibilityContainer.fontMultiplierMaxSize;
        fontchange = true; //make setfont update the fonts
        Invoke("boolFlip", 1f);
    }

    public void ButtonSizeDown()
    {
        if (AccessibilityContainer.fontSizeMulitplier >= 2) //don't go below 1
            AccessibilityContainer.fontSizeMulitplier = AccessibilityContainer.fontSizeMulitplier - fontSizeMultiplierChange;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void boolFlip()
    {
        fontchange = !fontchange;
    }
}

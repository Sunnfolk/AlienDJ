using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFont : MonoBehaviour
{
    public Font dyslexia;
    public Font standard;

    public static bool fontchange;

    [SerializeField] private int fontSizeMultiplierChange = 1;

    public void ButtonDyslexia()
    {
        AccessibilityContainer.fontInUse = dyslexia;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void ButtonStandard()
    {
        AccessibilityContainer.fontInUse = standard;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void ButtonSizeUp()
    {
        AccessibilityContainer.fontSizeMulitplier = AccessibilityContainer.fontSizeMulitplier + fontSizeMultiplierChange;
        if (AccessibilityContainer.fontSizeMulitplier > AccessibilityContainer.fontMultiplierMaxSize)
            AccessibilityContainer.fontSizeMulitplier = AccessibilityContainer.fontMultiplierMaxSize;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void ButtonSizeDown()
    {
        if (AccessibilityContainer.fontSizeMulitplier >= 2)
            AccessibilityContainer.fontSizeMulitplier = AccessibilityContainer.fontSizeMulitplier - fontSizeMultiplierChange;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void boolFlip()
    {
        fontchange = !fontchange;
    }
}

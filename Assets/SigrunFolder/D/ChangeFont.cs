using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFont : MonoBehaviour
{
    public Font dyslexia;
    public Font standard;

    public FontSource fontSource;

    public static bool fontchange;

    [SerializeField] private int fontSizeChange = 1;

    public void ButtonDyslexia()
    {
        fontSource.inUse = dyslexia;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void ButtonStandard()
    {
        fontSource.inUse = standard;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void ButtonSizeUp()
    {
        fontSource.fontSize = fontSource.fontSize + fontSizeChange;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void ButtonSizeDown()
    {
        fontSource.fontSize = fontSource.fontSize - fontSizeChange;
        fontchange = true;
        Invoke("boolFlip", 1f);
    }

    public void boolFlip()
    {
        fontchange = !fontchange;
    }
}

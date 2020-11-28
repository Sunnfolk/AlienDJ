using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTheColor : MonoBehaviour
{
    public int musicCategory;
    public ColorScriptableObjectScript colors;

    private void Start()
    {
        ColorDisplay();
    }

    private void Update()
    {
        if (SetTheColor.colorUpdate == true)
            ColorDisplay();
    }

    public void ColorDisplay()
    {
        var renderer = GetComponent<Renderer>();

        switch (musicCategory)
        {
            case 3:
                renderer.material.color = new Color(colors.aggressive.r,colors.aggressive.g,colors.aggressive.b);
                break;
            case 2:
                renderer.material.color = new Color(colors.energetic.r, colors.energetic.g, colors.energetic.b);
                break;
            case 1:
                renderer.material.color = new Color(colors.calm.r, colors.calm.g, colors.calm.b);
                break;
            case 0:
                renderer.material.color = new Color(colors.chill.r, colors.chill.g, colors.chill.b);
                break;
        }
    }
}

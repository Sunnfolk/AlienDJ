using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTheColor : MonoBehaviour
{

    public int musicCategory;
    public ColorScriptableObjectScript colors;



    private void Start()
    {
        var renderer = GetComponent<Renderer>();

        switch (musicCategory)
        {
            case 0:
                renderer.material.color = new Color(colors.aggressive.r,colors.aggressive.g,colors.aggressive.b);
                break;
            case 1:
                renderer.material.color = new Color(colors.energetic.r, colors.energetic.g, colors.energetic.b);
                break;
            case 2:
                renderer.material.color = new Color(colors.calm.r, colors.calm.g, colors.calm.b);
                break;
            case 3:
                renderer.material.color = new Color(colors.chill.r, colors.chill.g, colors.chill.b);
                break;
        }
    }
}

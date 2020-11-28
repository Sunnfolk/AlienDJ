using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTheColor : MonoBehaviour
{
    public int musicCategory; //Set on the object

    private void Awake()
    {
        ColorDisplay(); //set the color when it spawns
    }

    private void Update()
    {
        if (SetTheColor.colorUpdate == true) //if the color should be changed change the color
            ColorDisplay();
    }

    public void ColorDisplay()
    {
        var renderer = GetComponent<Renderer>();

        switch (musicCategory) //change the color of the object with the color from the container
        {
            case 3:
                renderer.material.color = new Color(AccessibilityContainer.aggressive.r,AccessibilityContainer.aggressive.g,AccessibilityContainer.aggressive.b);
                break;
            case 2:
                renderer.material.color = new Color(AccessibilityContainer.energetic.r, AccessibilityContainer.energetic.g, AccessibilityContainer.energetic.b);
                break;
            case 1:
                renderer.material.color = new Color(AccessibilityContainer.calm.r, AccessibilityContainer.calm.g, AccessibilityContainer.calm.b);
                break;
            case 0:
                renderer.material.color = new Color(AccessibilityContainer.chill.r, AccessibilityContainer.chill.g, AccessibilityContainer.chill.b);
                break;
        }
    }
}

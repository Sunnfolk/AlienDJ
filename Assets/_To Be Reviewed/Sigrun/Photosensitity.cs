using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photosensitity : MonoBehaviour
{
    public void EnableHyperspace()
    {
        AccessibilityContainer.hyperspaceEnabled = true;
    }

    public void DisableHyperspace()
    {
        AccessibilityContainer.hyperspaceEnabled = false;
    }

    public void EnableLightshow()
    {
        AccessibilityContainer.lightshowsEnabled = true;
    }

    public void DisableLightshow()
    {
        AccessibilityContainer.lightshowsEnabled = false;
    }
}

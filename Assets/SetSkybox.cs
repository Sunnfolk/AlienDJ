using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkybox : MonoBehaviour
{
    public void ActivateSkybox()
    {
        GameSettings.skyboxActive = true;
    }

    public void DeactivateSkybox()
    {
        GameSettings.skyboxActive = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
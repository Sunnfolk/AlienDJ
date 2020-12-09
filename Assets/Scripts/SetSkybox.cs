using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSkybox : MonoBehaviour
{
    public void ActivateSkybox()
    {
        GameSettings.skyboxActive = true;
        SceneManager.LoadScene(CurrentSong.selectedCrowd.SceneName, LoadSceneMode.Additive);

    }

    public void DeactivateSkybox()
    {
        GameSettings.skyboxActive = false;
        SceneManager.UnloadSceneAsync(CurrentSong.selectedCrowd.SceneName);
    }
}
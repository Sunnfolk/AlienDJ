using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSkybox : MonoBehaviour
{
    public void ActivateSkybox()
    {
        GameSettings.skyboxActive = true;
        //SceneManager.LoadScene(nameof(CurrentSong.selectedCrowd._environmentScene), LoadSceneMode.Additive);
    }

    public void DeactivateSkybox()
    {
        GameSettings.skyboxActive = false;
        //SceneManager.UnloadSceneAsync(nameof(CurrentSong.selectedCrowd._environmentScene));
    }
}

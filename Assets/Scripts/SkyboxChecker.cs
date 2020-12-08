using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChecker : MonoBehaviour
{
    private MeshRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rend.enabled = GameSettings.skyboxActive;

        if (!GameSettings.skyboxActive)
        {
            UpdateSkyBox();
        }

    }

    public void UpdateSkyBox()
    {
        _rend.material.SetTexture("_EmissionMap", CurrentSong.selectedCrowd.Skybox);
        _rend.material.SetTexture("_BaseMap", CurrentSong.selectedCrowd.Skybox);
    }
}
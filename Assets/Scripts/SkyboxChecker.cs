using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChecker : MonoBehaviour
{
    private MeshRenderer _rend;

    public List<GameObject> _environments;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<MeshRenderer>();
        _rend.enabled = true;
        GameSettings.skyboxActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rend.enabled = GameSettings.skyboxActive;

        if (!GameSettings.skyboxActive)
        {
            UpdateSkyBox();
            ActivateEnvironment();
        }
    }

    public void UpdateSkyBox()
    {
        _rend.material.SetTexture("_EmissionMap", CurrentSong.selectedCrowd.Skybox);
        _rend.material.SetTexture("_BaseMap", CurrentSong.selectedCrowd.Skybox);
    }
    
    public void ActivateEnvironment()
    {
        for (int i = 0; i < _environments.Count; i++)
        {
            if (_environments[i].gameObject.name == CurrentSong.selectedCrowd.SceneName)
            {
                _environments[i].gameObject.SetActive(true);
            }
            else
            {
                _environments[i].gameObject.SetActive(false);
            }
            
        }
    }
}
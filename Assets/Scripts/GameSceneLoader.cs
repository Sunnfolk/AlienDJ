using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    public List<String> _sceneNames;
    // Start is called before the first frame update
    private void Start()
    {
        foreach (String scene in _sceneNames)
        {
            SceneManager.LoadScene( scene, LoadSceneMode.Additive);
        }
    }
}

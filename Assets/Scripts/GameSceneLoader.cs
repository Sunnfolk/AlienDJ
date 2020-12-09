using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    public List<SceneAsset> _scenes;
    // Start is called before the first frame update
    private void Start()
    {
        foreach (SceneAsset scene in _scenes)
        {
            SceneManager.LoadScene(nameof(scene), LoadSceneMode.Additive);
        }
    }
}

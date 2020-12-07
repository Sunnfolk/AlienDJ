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
        print("The Mesh Renderer is: " +_rend);
        _rend.enabled = GameSettings.skyboxActive;
    }
}
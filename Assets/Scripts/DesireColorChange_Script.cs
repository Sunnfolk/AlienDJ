using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesireColorChange_Script : MonoBehaviour
{
    private Light _Light;

    private void Start() 
    {
        _Light = gameObject.GetComponent<Light>();
    }

    private void Update() 
    {
        _Light.color = new Color( 255, 0, 0, 255);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFont : MonoBehaviour
{
    public FontSource fontSource;
    private void Start()
    {
        GetComponent<Text>().font = fontSource.inUse;
    }
    private void Update()
    {
        if (ChangeFont.fontchange == true)
        {
            GetComponent<Text>().font = fontSource.inUse;
            GetComponent<Text>().fontSize = fontSource.fontSize;
        }
        
    }
}

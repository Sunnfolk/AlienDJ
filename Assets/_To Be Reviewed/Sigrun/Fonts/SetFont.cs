using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetFont : MonoBehaviour
{
    [SerializeField] private int fontDefaultSize = 10; //the default size of this text's font, set individually

    private void Start()
    {
        GetComponent<TextMeshPro>().font = AccessibilityContainer.fontInUse; //change the font to the one stored in the container
        GetComponent<TextMeshPro>().fontSize = fontDefaultSize * AccessibilityContainer.fontSizeMulitplier; //increase the font by the value in the container
    }
    private void Update()
    {
        if (ChangeFont.fontchange == true) //only change when there is a change
        {
            GetComponent<TextMeshPro>().font = AccessibilityContainer.fontInUse; //change the font to the one stored in the container
            GetComponent<TextMeshPro>().fontSize = fontDefaultSize * AccessibilityContainer.fontSizeMulitplier; //increase the font by the value in the container
        }
        
    }
}

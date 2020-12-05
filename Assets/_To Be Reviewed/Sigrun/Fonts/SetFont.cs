using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetFont : MonoBehaviour
{
    [SerializeField] private int fontDefaultSize = 100; //the default size of this text's font, set individually

    public TextMeshPro text;

    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        
        text.font = AccessibilityContainer.fontInUse; //change the font to the one stored in the container
        text.fontSize = fontDefaultSize * AccessibilityContainer.fontSizeMulitplier; //increase the font by the value in the container
    }
    private void Update()
    {
        if (ChangeFont.fontchange == true) //only change when there is a change
        {
            text.font = AccessibilityContainer.fontInUse; //change the font to the one stored in the container
            text.fontSize = fontDefaultSize * AccessibilityContainer.fontSizeMulitplier; //increase the font by the value in the container
        }
        
    }
}

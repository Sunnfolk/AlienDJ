using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFont : MonoBehaviour
{
    [SerializeField] private int fontDefaultSize = 14;

    private void Start()
    {
        GetComponent<Text>().font = AccessibilityContainer.fontInUse;
        GetComponent<Text>().fontSize = fontDefaultSize * AccessibilityContainer.fontSizeMulitplier;
    }
    private void Update()
    {
        if (ChangeFont.fontchange == true)
        {
            GetComponent<Text>().font = AccessibilityContainer.fontInUse;
            GetComponent<Text>().fontSize = fontDefaultSize * AccessibilityContainer.fontSizeMulitplier;
        }
        
    }
}

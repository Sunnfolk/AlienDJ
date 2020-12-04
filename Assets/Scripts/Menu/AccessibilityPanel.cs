using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessibilityPanel : MonoBehaviour
{
    [Header("Menu looks can be edited in the MenuFunctions scriptable object")]
    public MenuFunctions menuFunctions;

    public enum AccessibilytyType { volumeLevel, textSize, textFont, colorProfile, placeholder};
    [Header("Type of action for each option")]
    public AccessibilytyType accessibilityType;

    
    private void OnEnable()
    {
        //Waits until end of frame and sets the active window to gameobject name
        //Without waiting it would skip through the entire menu in one frame
        StartCoroutine(waitAndSetActiveWindow(this.gameObject));

        //Set menu panel color
        this.gameObject.GetComponent<Image>().color = menuFunctions.activeMenuPanelColor;
    }

    //Used in ^OnEnable^
    private IEnumerator waitAndSetActiveWindow(GameObject panelName)
    {
        yield return new WaitForEndOfFrame();
        menuFunctions.activePanel = panelName;
    }

    public void buttonUp()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            switch (accessibilityType)
            {
                case AccessibilytyType.colorProfile:

                    break;
                case AccessibilytyType.textFont:

                    break;
                case AccessibilytyType.textSize:

                    break;
                case AccessibilytyType.volumeLevel:

                    break;
                case AccessibilytyType.placeholder:

                    break;
                default:
                    Debug.LogError("this accessibilityType is not defined in this switch");
                    break;
            }
        }
    }

    public void buttonDown()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            switch (accessibilityType)
            {
                case AccessibilytyType.colorProfile:

                    break;
                case AccessibilytyType.textFont:

                    break;
                case AccessibilytyType.textSize:

                    break;
                case AccessibilytyType.volumeLevel:

                    break;
                case AccessibilytyType.placeholder:

                    break;
                default:
                    Debug.LogError("this accessibilityType is not defined in this switch");
                    break;
            }
        }
    }

    public void buttonSelect()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            switch (accessibilityType)
            {
                case AccessibilytyType.colorProfile:

                    break;
                case AccessibilytyType.textFont:

                    break;
                case AccessibilytyType.textSize:

                    break;
                case AccessibilytyType.volumeLevel:

                    break;
                case AccessibilytyType.placeholder:

                    break;
                default:
                    Debug.LogError("this accessibilityType is not defined in this switch");
                    break;
            }
        }  
    }


    public void buttonBack()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            StartCoroutine(waitEndFrame());
        }
    }

    private IEnumerator waitEndFrame()
    {
        yield return new WaitForEndOfFrame();
        //set index and active panel to last active values
        menuFunctions.menuIndex = menuFunctions.lastMenuIndex[menuFunctions.lastMenuIndex.Count - 1];
        menuFunctions.activePanel = menuFunctions.lastActivePanel[menuFunctions.lastActivePanel.Count - 1];

        //Remove the last last-active-value from lists
        menuFunctions.lastMenuIndex.RemoveAt(menuFunctions.lastMenuIndex.Count - 1);
        menuFunctions.lastActivePanel.RemoveAt(menuFunctions.lastActivePanel.Count - 1);

        //Set activepanel color to previous window
        menuFunctions.activePanel.GetComponent<Image>().color = menuFunctions.activeMenuPanelColor;


        this.gameObject.SetActive(false);
    }
}

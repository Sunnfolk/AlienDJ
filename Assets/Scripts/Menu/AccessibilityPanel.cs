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

    [Header("Gameobjects to choose from on the panel")]
    public List<GameObject> options;

    
    private void OnEnable()
    {
        //Waits until end of frame and sets the active window to gameobject name
        //Without waiting it would skip through the entire menu in one frame
        StartCoroutine(waitAndSetActiveWindow(this.gameObject));

        //ser menuindex to 0
        menuFunctions.menuIndex = 0;

        //Set menu panel color
        this.gameObject.GetComponent<Image>().color = menuFunctions.activeMenuPanelColor;

        if (accessibilityType != AccessibilytyType.colorProfile)
        {
            //Set all texts to text color
            foreach (GameObject gm in options)
            {
                gm.GetComponent<TextMeshProUGUI>().color = menuFunctions.textColor;
            }

            //set text color
            options[menuFunctions.menuIndex].GetComponent<TextMeshProUGUI>().color = menuFunctions.selectedTextColor;
        }
        else
        {
            //Set all colorpreviews to transparent
            Color imageColor;
            foreach(GameObject gm in options)
            {
                imageColor = gm.GetComponent<Image>().color;
                imageColor.a = 0.25f;
                gm.GetComponent<Image>().color = imageColor;
            }

            imageColor = options[menuFunctions.menuIndex].GetComponent<Image>().color;
            imageColor.a = 1f;
            options[menuFunctions.menuIndex].GetComponent<Image>().color = imageColor;

        }
        
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
            if (accessibilityType != AccessibilytyType.colorProfile)
                // Revert current index text back to normal color
                options[menuFunctions.menuIndex].GetComponent<TextMeshProUGUI>().color = menuFunctions.textColor;
            else
            {   
                //set selected color to not transparent
                Color imageColor = options[menuFunctions.menuIndex].GetComponent<Image>().color;
                imageColor.a = 0.25f;
                options[menuFunctions.menuIndex].GetComponent<Image>().color = imageColor;
            }

            // Add doen the index down by one and loop back if too big
            menuFunctions.menuIndex--;
            if (menuFunctions.menuIndex < 0)
            {
                menuFunctions.menuIndex = options.Count - 1;
            }
            if (accessibilityType != AccessibilytyType.colorProfile)
                // Make changed index to selected text color
                options[menuFunctions.menuIndex].GetComponent<TextMeshProUGUI>().color = menuFunctions.selectedTextColor;
            else
            {
                //set Unselected color to transparent
                Color imageColor = options[menuFunctions.menuIndex].GetComponent<Image>().color;
                imageColor.a = 1f;
                options[menuFunctions.menuIndex].GetComponent<Image>().color = imageColor;
            }
        }
    }

    public void buttonDown()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            if (accessibilityType != AccessibilytyType.colorProfile)
                // Revert current index text back to normal color
                options[menuFunctions.menuIndex].GetComponent<TextMeshProUGUI>().color = menuFunctions.textColor;
            else
            {
                //set selected color to not transparent
                Color imageColor = options[menuFunctions.menuIndex].GetComponent<Image>().color;
                imageColor.a = 0.25f;
                options[menuFunctions.menuIndex].GetComponent<Image>().color = imageColor;
            }

            // Add move the index down by one and loop back if too big
            menuFunctions.menuIndex++;
            if (menuFunctions.menuIndex >= options.Count)
            {
                menuFunctions.menuIndex = 0;
            }

            if (accessibilityType != AccessibilytyType.colorProfile)
                // Make changed index to selected text color
                options[menuFunctions.menuIndex].GetComponent<TextMeshProUGUI>().color = menuFunctions.selectedTextColor;
            else
            {
                //set Unselected color to transparent
                Color imageColor = options[menuFunctions.menuIndex].GetComponent<Image>().color;
                imageColor.a = 1f;
                options[menuFunctions.menuIndex].GetComponent<Image>().color = imageColor;
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

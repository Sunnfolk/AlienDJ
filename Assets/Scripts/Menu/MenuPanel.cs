﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class MenuPanel : MonoBehaviour
{
    [Header("Menu looks can be edited in the MenuFunctions scriptable object")]
    public MenuFunctions menuFunctions;

    [Header("Check if this is the first main menu")]
    public bool isFirstMenuPanel;
    
    [Header("Gameobjects to choose from in panel:")]
    public List<GameObject> options;
    
    public enum ActionType { activateNewPanel, Quit, timeSelect, returnToMainMenu, extras, hyperspace, whichColor, startGame};
    [Header("Type of action for each option")]
    public List<ActionType> actionType;

    [Header("What gameobject each activates (Leave element empty if not Activate New Panel")]
    public List<GameObject> activates;

    [Header("Insert what Start Game does")]
    //Add here if start game is chosen
    public GameStarter gameChanger;

    [Header("Add setMenu object if Start game or Return to main menu is selected")]
    public SetMenu setMenu;



    private void OnEnable()
    {
        //Waits until end of frame and sets the active window to gameobject name
        //Without waiting it would skip through the entire menu in one frame
        StartCoroutine(waitAndSetActiveWindow(this.gameObject));

        //Clear list of last active window and index if the main menu i activated
        //It need to be cleared once every time the main menu pops up.
        if (isFirstMenuPanel)
        {
            menuFunctions.lastActivePanel.Clear();
            menuFunctions.lastMenuIndex.Clear();
        }

        //Set menu panel color
        this.gameObject.GetComponent<Image>().color = menuFunctions.activeMenuPanelColor;

        //Set all texts to text color
        foreach (GameObject gm in options)
        {
            gm.GetComponent<TextMeshPro>().color = menuFunctions.textColor;
        }

        menuFunctions.menuIndex = 0;
        options[0].GetComponent<TextMeshPro>().color = menuFunctions.selectedTextColor;
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
            // Revert current index text back to normal color
            options[menuFunctions.menuIndex].GetComponent<TextMeshPro>().color = menuFunctions.textColor;

            // Add doen the index down by one and loop back if too big
            menuFunctions.menuIndex--;
            if (menuFunctions.menuIndex < 0)
            {
                menuFunctions.menuIndex = options.Count - 1;
            }

            // Make changed index to selected text color
            options[menuFunctions.menuIndex].GetComponent<TextMeshPro>().color = menuFunctions.selectedTextColor;
        }
    }

    public void buttonDown()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            // Revert current index text back to normal color
            options[menuFunctions.menuIndex].GetComponent<TextMeshPro>().color = menuFunctions.textColor;

            // Add move the index down by one and loop back if too big
            menuFunctions.menuIndex++;
            if (menuFunctions.menuIndex >= options.Count)
            {
                menuFunctions.menuIndex = 0;
            }

            // Make changed index to selected text color
            options[menuFunctions.menuIndex].GetComponent<TextMeshPro>().color = menuFunctions.selectedTextColor;
        }
    }

    public void buttonSelect()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            //What happens based on selected action
            switch (actionType[menuFunctions.menuIndex])
            {
                case ActionType.activateNewPanel:
                    saveLastActive();
                    gameObject.GetComponent<Image>().color = menuFunctions.menuPanelColor;
                    activates[menuFunctions.menuIndex].SetActive(true);
                    break;
                case ActionType.Quit:

                    print("please add the quit code in the MenuPanel script");
                    break;
                case ActionType.timeSelect:
                    gameObject.GetComponent<Image>().color = menuFunctions.menuPanelColor;
                    saveLastActive();
                    setGameDuration();
                    activates[menuFunctions.menuIndex].SetActive(true);
                    break;
                case ActionType.returnToMainMenu:
                    if (gameChanger != null)
                        gameChanger.ChangeGame();
                    else
                        print("No GameChanger in " + this);
                    setMenu.SetupMainMenu.Invoke();
                    //Add code for returning to main menu from the game here     <----------------------------------------
                    break;
                case ActionType.extras:
                    //extras code does not do anything because it is extras code :))
                    break;
                case ActionType.startGame:
                    setLightshow();
                    //Starts the change sequence
                    if (gameChanger != null)
                        gameChanger.ChangeGame();
                    else
                        print("No GameChanger in " + this);
                    setMenu.SetupGameMenu.Invoke();
                    //print("please add the start game code in the MenuPanel script");
                    break;
                case ActionType.hyperspace:
                    saveLastActive();
                    setHyperspace();
                    activates[menuFunctions.menuIndex].SetActive(true);
                    break;
                case ActionType.whichColor:
                    saveLastActive();
                    whichColor();
                    activates[menuFunctions.menuIndex].SetActive(true);
                    break;
                default:
                    Debug.LogError(actionType[menuFunctions.menuIndex] + " ActionType not defined within switch");
                    break;
            }
        }
    }
    void saveLastActive()
    {
        //Save information for when pushing the back button later
        menuFunctions.lastActivePanel.Add(this.gameObject);
        menuFunctions.lastMenuIndex.Add(menuFunctions.menuIndex);
    }

    private void setGameDuration()
    {
        switch (menuFunctions.menuIndex)
        {
            case 0:
                GameSettings.gameDuration = 2f;
                break;
            case 1:
                GameSettings.gameDuration = 5f;
                break;
            case 2:
                GameSettings.gameDuration = 10f;
                break;
            default:
                Debug.LogError("Timeselect index: " + menuFunctions.menuIndex.ToString() + " does not exist in switch");
                break;
        }
    }
    private void setHyperspace()
    {
        switch (menuFunctions.menuIndex)
        {
            case 0:
                AccessibilityContainer.hyperspaceEnabled = true;
                break;
            case 1:
                AccessibilityContainer.hyperspaceEnabled = false;
                break;
            default:
                Debug.LogError("SetHyperspace index: " + menuFunctions.menuIndex.ToString() + " does not exist in switch");
                break;
        }
    }

    private void whichColor()
    {
        menuFunctions.whichColor = menuFunctions.menuIndex;
    }

    private void setLightshow()
    {
        switch (menuFunctions.menuIndex)
        {
            case 0:
                AccessibilityContainer.lightshowsEnabled = true;
                break;
            case 1:
                AccessibilityContainer.lightshowsEnabled = false;
                break;
            default:
                Debug.LogError("setLightshow index: " + menuFunctions.menuIndex.ToString() + " does not exist in switch");
                break;
        }
    }


    public void buttonBack()
    {
        //if this is first menu
        //return
        if (menuFunctions.activePanel == this.gameObject && !isFirstMenuPanel)
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

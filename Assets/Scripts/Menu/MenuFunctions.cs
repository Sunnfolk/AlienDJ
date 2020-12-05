using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MenuFunctions : ScriptableObject
{
    [HideInInspector]
    //Index of highlighted menu element
    public int menuIndex;

    //Variable to differenciate which panel is active
    [HideInInspector]
    public GameObject activePanel;

    //Saves the last active panel to set when pushing the back button
    [HideInInspector]
    public List<GameObject> lastActivePanel;

    //save the last active menu index to set when pushing the back button
    [HideInInspector]
    public List<int> lastMenuIndex = new List<int>();

    //What color is changed in the change color part of menu
    [HideInInspector]
    public int whichColor;

    public Color menuPanelColor;
    public Color textColor;
    public Color selectedTextColor;
    public Color activeMenuPanelColor;


    public void Up()
    {
        try
        {
            activePanel.GetComponent<MenuPanel>().buttonUp();
        }
        catch
        { 
            try
            {
                activePanel.GetComponent<PlanetSelectPanel>().buttonUp();
            }
            catch
            {
                activePanel.GetComponent<AccessibilityPanel>().buttonUp();
            }
        }
    }

    public void Down()
    {
        try
        {
            activePanel.GetComponent<MenuPanel>().buttonDown();
        }
        catch
        {
            try
            {
                activePanel.GetComponent<PlanetSelectPanel>().buttonDown();
            }
            catch
            {
                activePanel.GetComponent<AccessibilityPanel>().buttonDown();
            }
        }
    }

    public void Select()
    {
        try
        {
            activePanel.GetComponent<MenuPanel>().buttonSelect();
        }
        catch
        {
            try
            {
                activePanel.GetComponent<PlanetSelectPanel>().buttonSelect();
            }
            catch
            {
                activePanel.GetComponent<AccessibilityPanel>().buttonSelect();
            }
        }
    }

    public void Back()
    {
        try
        {
            activePanel.GetComponent<MenuPanel>().buttonBack();
        }
        catch
        {
            try
            {
                activePanel.GetComponent<PlanetSelectPanel>().buttonBack();
            }
            catch
            {
                activePanel.GetComponent<AccessibilityPanel>().buttonBack();
            }
        }
    }
}

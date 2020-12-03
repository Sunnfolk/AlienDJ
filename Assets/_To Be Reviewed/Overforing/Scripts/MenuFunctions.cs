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

    public Color menuPanelColor;
    public Color textColor;
    public Color selectedTextColor;


    public void Up()
    {
        try
        {
            activePanel.GetComponent<MenuPanel>().buttonUp();
        }
        catch
        {
            activePanel.GetComponent<PlanetSelectPanel>().buttonUp();
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
            activePanel.GetComponent<PlanetSelectPanel>().buttonDown();
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
            activePanel.GetComponent<PlanetSelectPanel>().buttonSelect();
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
            activePanel.GetComponent<PlanetSelectPanel>().buttonBack();
        }
    }
}

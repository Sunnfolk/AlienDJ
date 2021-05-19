using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Tooltip("This is a fancy tooltip")]
    public MenuFunctions menuFunction;

    [Header("This is a Heading")]
    public GameObject settingsGameObject;
    public GameObject planetSelectGameObject;

    
    public List<GameObject> options;

    private void OnEnable()
    {
        //menuFunction = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuFunctions>();
        menuFunction.activeWindow = "MainMenu";
        menuFunction.menuIndex = 0;
        options[menuFunction.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.cyan;


       
    }


    public void buttonUp()
    {
        if (menuFunction.activeWindow == "MainMenu")
            menuFunction.indexUp(options);
    }

    public void buttonDown()
    {
        if (menuFunction.activeWindow == "MainMenu")
            menuFunction.indexDown(options);
    }

    public void buttonSelect()
    {
        if (menuFunction.activeWindow == "MainMenu")
        {
            switch (options[menuFunction.menuIndex].name)
            {
                case "Play":
                    planetSelectGameObject.SetActive(true);
                    break;
                case "Settings":
                    settingsGameObject.SetActive(true);
                    break;
                case "Extras":
                    //Code
                    break;
                case "Quit":
                    //Code
                    break;
                default:
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public MenuFunctions mf;
    public List<GameObject> options;

    private void OnEnable()
    {
        StartCoroutine(mf.WaitAndChangeActiveWindow("Settings"));
        mf.menuIndex = 0;
        options[mf.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.cyan;
    }


    public void buttonUp()
    {
        if (mf.activeWindow == "Settings")
            mf.indexUp(options);
    }

    public void buttonDown()
    {
        if (mf.activeWindow == "Settings")
            mf.indexDown(options);
    }

    public void buttonSelect()
    {
        if (mf.activeWindow == "Settings")
        {
            switch (options[mf.menuIndex].name)
            {
                case "ColorProfile":
                    //Code
                    break;
                case "Font":
                    //Code
                    break;
                case "FontSize":
                    //Code
                    break;
                case "Volume":
                    //Code
                    break;
                default:
                    break;
            }
        }
    }

    public void buttonBack()
    {
        if (mf.activeWindow == "Settings")
        {
            mf.activeWindow = "MainMenu";
            options[mf.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.white;
            mf.menuIndex = 1;
            this.gameObject.SetActive(false);
        }
    }
}

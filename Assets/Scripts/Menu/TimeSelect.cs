using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSelect : MonoBehaviour
{
    public MenuFunctions mf;
    public GameSettings gs;

    public GameObject photosensitivityGameObject;

    public List<GameObject> options;

    [HideInInspector]
    public int lastIndex;

    private void OnEnable()
    {
        StartCoroutine(mf.WaitAndChangeActiveWindow("TimeSelect"));
        mf.menuIndex = 0;
        options[mf.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.cyan;
    }


    public void buttonUp()
    {
        if (mf.activeWindow == "TimeSelect")
            mf.indexUp(options);
    }

    public void buttonDown()
    {
        if (mf.activeWindow == "TimeSelect")
            mf.indexDown(options);
    }

    public void buttonSelect()
    {
        if (mf.activeWindow == "TimeSelect")
        {
            lastIndex = mf.menuIndex;
            gs.time = Convert.ToInt32(options[mf.menuIndex].name);
            photosensitivityGameObject.SetActive(true);
        }
    }

    public void buttonBack()
    {
        if (mf.activeWindow == "TimeSelect")
        {
            mf.activeWindow = "PlanetSelect";
            options[mf.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.white;
            mf.menuIndex = 0;
            this.gameObject.SetActive(false);
        }
    }
}

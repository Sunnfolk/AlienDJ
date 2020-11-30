using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetSelect : MonoBehaviour
{
    public MenuFunctions mf;
    public GameSettings gs;

    public GameObject planetName;
    public GameObject planetInformation;
    public GameObject timeSelectGameObject;

    public List<GameObject> options;
    public List<string> planetInfo;

    private void OnEnable()
    {
        StartCoroutine(mf.WaitAndChangeActiveWindow("PlanetSelect"));
        mf.menuIndex = 0;
        options[mf.menuIndex].SetActive(true);
        updatePlanetInfo();
    }

    public void buttonUp()
    {
        if (mf.activeWindow == "PlanetSelect")
        {
            mf.indexPrevious(options);
            updatePlanetInfo();
        }
    }

    public void buttonDown()
    {
        if (mf.activeWindow == "PlanetSelect")
        {
            mf.indexNext(options);
            updatePlanetInfo();
        }
    }

    public void buttonSelect()
    {
        if (mf.activeWindow == "PlanetSelect")
        {
            gs.planet = options[mf.menuIndex].name;
            timeSelectGameObject.SetActive(true);
        }
    }

    public void buttonBack()
    {
        if (mf.activeWindow == "PlanetSelect")
        {
            mf.activeWindow = "MainMenu";
            options[mf.menuIndex].SetActive(false);
            mf.menuIndex = 0;
            this.gameObject.SetActive(false);
        }
    }

    private void updatePlanetInfo()
    {
        planetName.GetComponent<TextMeshProUGUI>().text = options[mf.menuIndex].name;
        planetInformation.GetComponent<TextMeshProUGUI>().text = planetInfo[mf.menuIndex];
    }
}

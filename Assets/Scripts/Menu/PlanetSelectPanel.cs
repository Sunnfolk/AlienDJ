using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetSelectPanel : MonoBehaviour
{    [Header("Menu looks can be edited in the MenuFunctions scriptable object")]
    public MenuFunctions menuFunctions;


    [Header("List of planet options")]
    public List<Planet> planets;

    [Header("Link to planetselect componenets")]
    public GameObject planetInfoPanel;
    public GameObject planetImage;
    public GameObject planetName;
    public GameObject planetInfo;

    [Header("What gameobject the select activates")]
    public GameObject activates;

    private TextMeshPro planetNameText;
    private TextMeshPro planetInfoText;
    private Image planetImageImage;
    private Image planetInfoPanelImage;
    private Image planetSelectPanelImage;

    private void Awake()
    {
        planetNameText = planetName.GetComponent<TextMeshPro>();
        planetInfoText = planetInfo.GetComponent<TextMeshPro>();
        planetImageImage = planetImage.GetComponent<Image>();
        planetInfoPanelImage = planetInfoPanel.GetComponent<Image>();
        planetSelectPanelImage = this.gameObject.GetComponent<Image>();
    }

    private void OnEnable()
    {
        //Waits until end of frame and sets the active window to gameobject name
        //Without waiting it would skip through the entire menu in one frame
        StartCoroutine(waitAndSetActiveWindow(this.gameObject));

        //Set menu panel color
        planetSelectPanelImage.color = menuFunctions.activeMenuPanelColor;

        //Set all texts to text color
        planetNameText.color = menuFunctions.textColor;
        planetInfoText.color = menuFunctions.textColor;

        // Set text to first index of planets
        planetNameText.text = planets[0].planetName;
        planetInfoText.text = planets[0].planetInfo;

        menuFunctions.menuIndex = 0;
    }

    //Used in ^OnEnable^
    private IEnumerator waitAndSetActiveWindow(GameObject panelName)
    {
        yield return new WaitForEndOfFrame();
        menuFunctions.activePanel = panelName;
    }

    private void Update()
    {
        //Check if the planet info color is correct
        if (menuFunctions.activePanel == this.gameObject)
            planetInfoPanelImage.color = menuFunctions.activeMenuPanelColor;
        else
            planetInfoPanelImage.color = menuFunctions.menuPanelColor;
    }

    public void buttonUp()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            //Change index 1 up
            menuFunctions.menuIndex--;
            if (menuFunctions.menuIndex < 0)
            {
                menuFunctions.menuIndex = planets.Count - 1;
            }

            // Show new planet
            showNewPlanet();
        }
    }

    public void buttonDown()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
            // change planet index down 1
            menuFunctions.menuIndex++;
            if (menuFunctions.menuIndex >= planets.Count)
            {
                menuFunctions.menuIndex = 0;
            }

            // Show new planet
            showNewPlanet();
        }
    }

    private void showNewPlanet()
    {
        planetInfoText.text = planets[menuFunctions.menuIndex].planetInfo;
        planetNameText.text = planets[menuFunctions.menuIndex].planetName;
        planetImageImage.sprite = planets[menuFunctions.menuIndex].planetImage;

    }

    public void buttonSelect()
    {
        if (menuFunctions.activePanel == this.gameObject && menuFunctions.menuIndex != 2) // (menuFunctions.menuIndex != 2): Earth has an index of 2, and shall not be selected.
        {
            //Save information for when pushing the back button later
            menuFunctions.lastActivePanel.Add(this.gameObject);
            menuFunctions.lastMenuIndex.Add(menuFunctions.menuIndex);

            //Change Gamesettings planet to current planet
            GameSettings.planet = menuFunctions.menuIndex; //the planet index is already equal to the menuindex variable

            //Set panel colors back to unselected
            planetSelectPanelImage.color = menuFunctions.menuPanelColor;

            //activates next panel
            activates.SetActive(true);
        }
    }

    public void buttonBack()
    {
        if (menuFunctions.activePanel == this.gameObject)
        {
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTheColor : MonoBehaviour
{
    private string category;
    public static int categoryID;

    private Color desiredColor;

    public static bool colorUpdate;
    private void Update()
    {
        print(categoryID);
    }

    public void CategoryPressed(Button _button)
    {
        category = _button.name;

        switch(category) //check witch category should have their color updated
        {
            case "Aggressive":
                categoryID = 3;
                break;
            case "Energetic":
                categoryID = 2;
                break;
            case "Calm":
                categoryID = 1;
                break;
            case "Chill":
                categoryID = 0;
                break;
        }
        
    }

    /*public void ColorPressed()
    {
        desiredColor = GetComponent<Image>().color;
        switch(categoryID)
        {
            case 3:
                colorContainer.aggressive = desiredColor;
                break;
            case 2:
                colorContainer.energetic = desiredColor;
                break;
            case 1:
                colorContainer.calm = desiredColor;
                break;
            case 0:
                colorContainer.chill = desiredColor;
                break;
        }
        colorUpdate = true;
        Invoke("boolFlip", 1f);
    }*/
    private void boolFlip()
    {
        colorUpdate = !colorUpdate;
    }

    public void GetGolor(Image _image)
    {
        desiredColor = _image.color; //we want to change the color stored in the container to the color of the "image", aka the button
        switch (categoryID) 
        {
            case 3:
                AccessibilityContainer.aggressive = desiredColor;
                break;
            case 2:
                AccessibilityContainer.energetic = desiredColor;
                break;
            case 1:
                AccessibilityContainer.calm = desiredColor;
                break;
            case 0:
                AccessibilityContainer.chill = desiredColor;
                break;
        }
        colorUpdate = true; //causes displaythecolor to update the colors
        Invoke("boolFlip", 1f);
    }

    public void RevertColor() //sets the colors to their default values
    {
        AccessibilityContainer.aggressive = Color.red;
        AccessibilityContainer.energetic = Color.yellow;
        AccessibilityContainer.calm = Color.green;
        AccessibilityContainer.chill = Color.blue;

        colorUpdate = true;
        Invoke("boolFlip", 1f);
    }
}
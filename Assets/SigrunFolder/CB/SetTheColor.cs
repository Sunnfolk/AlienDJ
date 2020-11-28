using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTheColor : MonoBehaviour
{
    private string category;
    public static int categoryID;

    private Color desiredColor;

    public ColorScriptableObjectScript colorContainer;

    public static bool colorUpdate;
    private void Update()
    {
        print(categoryID);
    }

    public void CategoryPressed(Button _button)
    {
        //categoryID = ();
        print("pressed");
        category = _button.name;

        switch(category)
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
        desiredColor = _image.color;
        switch (categoryID)
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
    }

    public void RevertColor()
    {
        colorContainer.aggressive = Color.red;
        colorContainer.energetic = Color.yellow;
        colorContainer.calm = Color.green;
        colorContainer.chill = Color.blue;

        colorUpdate = true;
        Invoke("boolFlip", 1f);
    }
}
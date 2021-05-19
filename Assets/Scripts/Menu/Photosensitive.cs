using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Photosensitive : MonoBehaviour
{
    public MenuFunctions mf;
    public TimeSelect ts;
    public GameSettings gs;

    public List<GameObject> options;

    private void OnEnable()
    {
        StartCoroutine(mf.WaitAndChangeActiveWindow("Photosensitive"));
        mf.menuIndex = 0;
        options[mf.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.cyan;
    }


    public void buttonUp()
    {
        if (mf.activeWindow == "Photosensitive")
            mf.indexUp(options);
    }

    public void buttonDown()
    {
        if (mf.activeWindow == "Photosensitive")
            mf.indexDown(options);
    }

    public void buttonSelect()
    {
        if (mf.activeWindow == "Photosensitive")
        {
            gs.photosensitive = options[mf.menuIndex].name == "Yes";
        }
    }

    public void buttonBack()
    {
        if (mf.activeWindow == "Photosensitive")
        {
            mf.activeWindow = "TimeSelect";
            options[mf.menuIndex].GetComponent<TextMeshProUGUI>().color = Color.white;
            mf.menuIndex = ts.lastIndex;
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuFunctions : MonoBehaviour
{
    [HideInInspector]
    //Index position for the current menu options
    public int menuIndex;
    [HideInInspector]
    public string activeWindow;


    private TextMeshProUGUI text = null;

    public void indexDown(List<GameObject> options)
    {
        //Revert previous text back to white
        text = options[menuIndex].GetComponent<TextMeshProUGUI>();
        text.color = Color.white;

        //Go to under-index (Plus 1, and go back to zero if too big)
        menuIndex = (++menuIndex >= options.Count) ? 0 : menuIndex;

        //Change current text to cyan (seleted)
        text = options[menuIndex].GetComponent<TextMeshProUGUI>();
        text.color = Color.cyan;
    }

    public void indexUp(List<GameObject> options)
    {
        //Revert previous text back to white
        text = options[menuIndex].GetComponent<TextMeshProUGUI>();
        text.color = Color.white;

        //Go to over-index (minus 1, and go back to bottom if too small)
        menuIndex = (--menuIndex <= -1) ? options.Count - 1 : menuIndex;

        //Change current text to cyan (seleted)
        text = options[menuIndex].GetComponent<TextMeshProUGUI>();
        text.color = Color.cyan;
    }


    public void indexNext(List<GameObject> options)
    {
        options[menuIndex].SetActive(false);
        menuIndex = (--menuIndex <= -1) ? options.Count - 1 : menuIndex;
        options[menuIndex].SetActive(true);
    }

    public void indexPrevious(List<GameObject> options)
    {
        options[menuIndex].SetActive(false);
        menuIndex = (++menuIndex >= options.Count) ? 0 : menuIndex;
        options[menuIndex].SetActive(true);
    }

    public IEnumerator WaitAndChangeActiveWindow(string NewWindow)
    {
        yield return new WaitForEndOfFrame();
        activeWindow = NewWindow;
    }
}

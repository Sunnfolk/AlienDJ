using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetMenu : MonoBehaviour
{
    public UnityEvent SetupMainMenu;
    public UnityEvent SetupGameMenu;

    public void SetMainMenu()
    {
        Invoke(nameof(SetupMainMenu), 0f);
        print("IsThis CALLED????????");
    }

    public void SetGameMenu()
    {
     
    }


}

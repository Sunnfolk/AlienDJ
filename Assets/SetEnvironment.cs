using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnvironment : MonoBehaviour
{
    public void ActivateEnvironment(bool value)
    {
        GameSettings.canSetEnvironment = value;
    }
}

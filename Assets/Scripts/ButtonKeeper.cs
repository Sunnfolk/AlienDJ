using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKeeper : MonoBehaviour
{
    public List<Collider> _collider;

    public void DisableButton()
    {

        foreach (Collider butt in _collider)
        {
            butt.enabled = false;
            print("Disabling Buttons");
        }
    }
    
    public void EnableButton()
    {
        foreach (Collider butt in _collider)
        {
            butt.enabled = true;
            print("Disabling Buttons");
        }
    }
}

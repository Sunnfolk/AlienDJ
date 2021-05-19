using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableOnStart : MonoBehaviour
{
    public UnityEvent _evnets;

    public void CallEvents()
    {
        _evnets.Invoke();
    }
}

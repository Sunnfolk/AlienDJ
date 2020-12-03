using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDespawn : MonoBehaviour
{
    public bool currentBool;
    [SerializeField] public static bool StaticTimerisFinishedBool;

    private void Update()
    {
        StaticTimerisFinishedBool = currentBool;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlienSpawn : MonoBehaviour
{
    public void SpawnAlien(bool value)
    {
        GameSettings.alienSpawn = value;
        Debug.Log("Alien Spawned");
    }

    public void DespawnAlien(bool value)
    {
        GameSettings.alienDespawn = value;
    }
}

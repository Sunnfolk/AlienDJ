using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAlienSpawn : MonoBehaviour
{
    public void SpawnAlien()
    {
        GameSettings.alienSpawn = true;
    }

    public void DespawnAlien()
    {
        GameSettings.alienDespawn = true;
    }
}

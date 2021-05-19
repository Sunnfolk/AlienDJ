using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnPoint : MonoBehaviour
{
    public List<Transform> _spawnPoints;

    public List<GameObject> _characters;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectCharacter();
        }
    }
    void SelectCharacter()
    {
        foreach(Transform trans in _spawnPoints)
        {
            Instantiate(_characters[Random.Range(0, _characters.Count)], trans);
        }
    }
}

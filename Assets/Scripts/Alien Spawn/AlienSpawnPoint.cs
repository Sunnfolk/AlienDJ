using System.Collections.Generic;
using UnityEngine;

namespace Alien_Spawn
{
    public class AlienSpawnPoint : MonoBehaviour
    {
        public List<Transform> _spawnPoints;

        public List<GameObject> _characters;

        
        
        public void Update()
        {
            if (GameSettings.alienSpawn)
            {
                SelectCharacter();
                GameSettings.alienSpawn = false;

            }
        }
        
        
        public void SelectCharacter()
        {
            foreach(Transform trans in _spawnPoints)
            {
                Instantiate(_characters[Random.Range(0, _characters.Count)], trans.position, Quaternion.identity, null);
            }
        }
    }
}
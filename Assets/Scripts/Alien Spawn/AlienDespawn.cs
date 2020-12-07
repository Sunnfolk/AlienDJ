using UnityEngine;

namespace Alien_Spawn
{
    public class AlienDespawn : MonoBehaviour
    {
        public bool currentBool;
        [SerializeField] public static bool StaticTimerisFinishedBool;

        private void Update()
        {
            StaticTimerisFinishedBool = currentBool;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperSpace
{
    public class HyperSpaceController : MonoBehaviour
    {
        public GameObject tunnel;

        [SerializeField] private float hyperspaceTimer = 5f;

        private void Update()
        { 
            if (Input.GetKeyDown(KeyCode.P))
            {
                RunHyperSpace();
                Invoke("EndHyperSpace", hyperspaceTimer);
            }
        }

        public void RunHyperSpace()
        {
            StartCoroutine(nameof(InitialiseHyperSpace));
        }

        private IEnumerator InitialiseHyperSpace()
        {
            // Light Flash (HyperSpace Enter)
            // Hyperspace start audio
            // Rotate Menu
            
            yield return new WaitForSeconds(1f);
            
            // Hyperspace tunnel loop audio
            tunnel.SetActive(true);
            // Set new skybox, crowd, planet ambience and so on
            
            yield return new WaitForSeconds(3f);
            
            // Hyperspace end audio
            // light flash (HyperSpace Exit)
            
            yield return new WaitForSeconds(1f);

            // Start Crowd Spawn

        }
        public void EndHyperSpace()
        {
            tunnel.SetActive(false);
        }
        
    }
}
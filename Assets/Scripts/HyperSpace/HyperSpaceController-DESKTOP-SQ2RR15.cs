using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperSpace
{
    public class HyperSpaceController : MonoBehaviour
    {
        public GameObject tunnel;
        [FMODUnity.EventRef]
        public string hyperStart = "";
        [FMODUnity.EventRef]
        public string hyperEnd = "";

        //public FMODUnity.StudioEventEmitter emit;

        public void RunHyperSpace()
        {
            if (AccessibilityContainer.hyperspaceEnabled)
                StartCoroutine(nameof(InitialiseHyperSpace));
        }

        private IEnumerator InitialiseHyperSpace()
        {
            // Light Flash (HyperSpace Enter)
            // Hyperspace start audio
            // Rotate Menu
            //FMODUnity.RuntimeManager.PlayOneShot(hyperStart);

            yield return new WaitForSeconds(1f);
            //emit.Play();
            // Hyperspace tunnel loop audio
            tunnel.SetActive(true);
            // Set new skybox, crowd, planet ambience and so on
            
            yield return new WaitForSeconds(3f);
            //emit.Stop();
            //FMODUnity.RuntimeManager.PlayOneShot(hyperEnd);
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
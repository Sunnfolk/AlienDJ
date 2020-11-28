using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SnapDetector : MonoBehaviour
{
    public bool isRotating;
    public int rotateSpeed;

    private bool holdsObject = false;

    //Hide Snap detector / make invisible
    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        /* snap to point if:
         *   there is no object there already,
         *   it has the SnapObject tag,
         *   it is not held by the controller.
         */
        Interactable currentObject = other.gameObject.GetComponent<Interactable>();
        if (other.gameObject.tag == "SnapObject")
        {
            if (!holdsObject && currentObject.ActiveHand == null)
            {
                SnapToDetector(currentObject);
            }
            else
            {
                SnapFromDetector(currentObject);
            }

            //Spin if spin is enabled
            if (isRotating)
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        
    }

    //Disconnect when not touching snap-detector
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SnapObject")
        {
            SnapFromDetector(other.gameObject.GetComponent<Interactable>());
        }
    }

    //snap to detector
    private void SnapToDetector(Interactable currentObject)
    {
        holdsObject = true;

        currentObject.transform.position = transform.position;
        currentObject.transform.rotation = transform.rotation;
        currentObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    //snap from detector
    private void SnapFromDetector(Interactable currentObject)
    {
        currentObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        holdsObject = false;
    }
}

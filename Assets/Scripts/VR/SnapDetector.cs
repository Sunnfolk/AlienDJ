using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SnapDetector : MonoBehaviour
{
    public bool isRotating;
    public int rotateSpeed;

    private bool holdsObject = false;

    public GameObject FMODPlayer;
    public bool discPlayer;

    private bool lerp;
    private float lerpTime;
    [SerializeField]
    private float lerpSpeed;
    private float lerpValue;

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
            else if(holdsObject && currentObject.ActiveHand != null)
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
        //goOnPlayer = currentObject.gameObject;
        currentObject.transform.position = transform.position;
        currentObject.transform.rotation = transform.rotation;
        currentObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        
        if(currentObject.gameObject.TryGetComponent(out DiscSong _discSong) && discPlayer)
        {
           
            _discSong.SongSelect();
            lerp = true;
            
            _discSong.rotSpeed = rotateSpeed;
       

        }
    }

    //snap from detector
    private void SnapFromDetector(Interactable currentObject)
    {
        currentObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        holdsObject = false;
        //goOnPlayer = null;
        if (currentObject.gameObject.TryGetComponent(out DiscSong _discSong) && discPlayer)
        {
          
            _discSong.rotSpeed = 0;
        }

    }


    private void Update()
    {
        if(lerp) //Change the value so song plays
        {
            if (lerpValue <= 0)
                lerp = false;
            lerpTime += Time.deltaTime * lerpSpeed;
            lerpValue = Mathf.Lerp(1, 0, lerpTime);
            CurrentSong.discoValue = lerpValue;



        }
    }

    public void ResetValues()
    {

        lerpValue = 0;


    }

}

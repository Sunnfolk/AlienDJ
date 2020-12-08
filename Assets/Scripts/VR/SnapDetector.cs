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

    public bool lerp;
    private float lerpTime;
    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private float lerpValue;

    public List<Button_Song> buttonModifiers = new List<Button_Song>();

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
            CurrentSong.discoValue = 1;
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
            ResetModifiers();          
            _discSong.rotSpeed = 0;
        }

    }


    private void Update()
    {
        
    }

    public void ResetValues()
    {

        lerpValue = 0;


    }

    public void ResetModifiers()
    {
        CurrentSong.currentModifier_0 = 0;
        CurrentSong.currentModifier_1 = 0;
        CurrentSong.currentModifier_2 = 0;
        CurrentSong.currentModifier_3 = 0;
        //CurrentSong.discoValue = 0;
        for (int i = 0; i < buttonModifiers.Count; i++)
        {
            buttonModifiers[i].on = false;
        }
    }

}

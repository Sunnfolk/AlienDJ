using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabAction = null;
    private SteamVR_Behaviour_Pose Pose = null;
    private FixedJoint Joint = null;
    private Interactable CurrentInteractable = null;
    private List<Interactable> ContactInteractables = new List<Interactable>();

    private PlayVFX handVFX = null;

    public GameObject _handOpen;
    public GameObject _handClosed;

    public Transform snaptooPoint;

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        Joint = GetComponent<FixedJoint>();
        handVFX = _handOpen.GetComponent<PlayVFX>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Trigger Down
        if(GrabAction.GetStateDown(Pose.inputSource))
        {


            Pickup();
            gameObject.tag = "Hand_Trigger";
        }

        //Trigger Up
        if (GrabAction.GetStateUp(Pose.inputSource))
        {
            

            Drop();
            gameObject.tag = "Hand_Open";
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        /* Switch statement checking the tags of the objects
         * SnapObject:              Pick-up-able, and snappable later in the code
         * Interactable:            The object is added to the list of pick-up-able objects
         * Button:                  The button prints pressed down to the console
         * [No Tag / Not Listed]:   Nothing will be done with the object
         */
        switch (other.gameObject.tag)
        {
            case "SnapObject":
                //No break or code because it shares features with the next case
            case "Interactable":
                ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
                break;
            case "Button":
                print(other.gameObject + " Button pressed Down");
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /* Switch statement checking the tags of the objects:
         * SnapObject:              Pick-up-able, and snappable later in the code
         * Interactable:            The object is removed from the list of pick-up-able objects
         * Button:                  The button prints pressed up to the console
         * [No Tag / Not Listed]:   Nothimg can be done with the object
         */
        switch (other.gameObject.tag)
        {
            case "SnapObject":
                //No break or code because it shares features with the next case
            case "Interactable":
                ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
                break;
            case "Button":
                print(other.gameObject + " Button pressed Up");
                break;
            default:
                break;
        }
    }

    public void Pickup()
    {
        // Get nearest interactable
        CurrentInteractable = GetNearestInteractable();

        _handClosed.SetActive(true);
        _handOpen.SetActive(false);

        // Null Check
        if (!CurrentInteractable)
            return;

        _handClosed.SetActive(false);
        _handOpen.SetActive(true);

        //Play effect for held object
        handVFX.OnGrip();

        // Already held (by other controller), check
        if (CurrentInteractable.ActiveHand)
            CurrentInteractable.ActiveHand.Drop();

        // position to controller
        CurrentInteractable.transform.position = snaptooPoint.position;
        CurrentInteractable.transform.rotation = snaptooPoint.rotation;

        // attach
        Rigidbody targetBody = CurrentInteractable.GetComponent<Rigidbody>();
        Joint.connectedBody = targetBody;

        // set to active hand
        CurrentInteractable.ActiveHand = this;
    }

    public void Drop()
    {
        _handClosed.SetActive(false);
        _handOpen.SetActive(true);

        // Null Check
        if (!CurrentInteractable)
            return;

        //Turn off effect for held object
        handVFX.OnRelease();

        // Apply velocity
        Rigidbody targetBody = CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = Pose.GetVelocity();
        targetBody.angularVelocity = Pose.GetAngularVelocity();

        // Detach
        Joint.connectedBody = null;

        // Clear
        CurrentInteractable.ActiveHand = null;
        CurrentInteractable = null;
    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.00f;

        foreach(Interactable interactable in ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}

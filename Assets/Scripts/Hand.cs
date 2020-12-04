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

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Trigger Down
        if(GrabAction.GetStateDown(Pose.inputSource))
        {
            Pickup();
        }

        //Trigger Up
        if (GrabAction.GetStateUp(Pose.inputSource))
        {
            Drop();
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

        // Null Check
        if (!CurrentInteractable)
            return;

        // Already held (by other controller), check
        if (CurrentInteractable.ActiveHand)
            CurrentInteractable.ActiveHand.Drop();

        // position to controller
        CurrentInteractable.transform.position = transform.position;
        // attach
        Rigidbody targetBody = CurrentInteractable.GetComponent<Rigidbody>();
        Joint.connectedBody = targetBody;

        // set to active hand
        CurrentInteractable.ActiveHand = this;
    }

    public void Drop()
    {
        // Null Check
        if (!CurrentInteractable)
            return;

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

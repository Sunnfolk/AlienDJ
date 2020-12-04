using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public Hand ActiveHand = null;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private void Start()
    {
        spawnPosition = this.gameObject.transform.position;
        spawnRotation = this.gameObject.transform.rotation;
    }

    private void Update()
    {
        //Start respawn sequence if z is lower than:
        if ((this.gameObject.transform.position.y <= -10f) && this.gameObject.GetComponent<Interactable>().ActiveHand == null)
        {
            //wait before respawn sequence starts
            this.gameObject.transform.position = spawnPosition;
            this.gameObject.transform.rotation = spawnRotation;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}

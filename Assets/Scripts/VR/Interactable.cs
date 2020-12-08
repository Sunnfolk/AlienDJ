using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public Hand ActiveHand = null;

    public GameObject VrCamera;

    [Header("The time before an object automatically respawns")]
    public float timeBeforeRespawn = 15f;
    [Header("object will respawn outside of this distance(Relative to player camera)")]
    public float respawnDistance = 5f;
    [Header("The object will not respawn before it is this far away from its original startposition")]
    public float notRespawnDistance = 1f;

    private bool respawnIsOngoing = false;
    //Tracks the time before an object needs to respawn
    private float timer;

    //true if the object is snapped to the disc player as an object
    [HideInInspector]
    public bool isSnapped = false;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private void Awake()
    {
        VrCamera = GameObject.FindGameObjectsWithTag("playerCamera")[0];
    }

    private void Start()
    {
        spawnPosition = this.gameObject.transform.position;
        spawnRotation = this.gameObject.transform.rotation;
        timer = Time.time;
    }

    private void Update()
    {
        
        if (!respawnIsOngoing)
        {
            //restart the timer if it is held by the player, or it is close to its original startpoint
            if (ActiveHand != null || Vector3.Distance(spawnPosition, this.gameObject.transform.position) <= notRespawnDistance)
            {
                timer = Time.time;
            }
            //respawn if the object is out of bounds or timer is down, or y position is bellow the floor, and not if it is a disc currently playing music
            else if (Vector3.Distance(VrCamera.transform.position, this.gameObject.transform.position) >= respawnDistance || Time.time - timer >= timeBeforeRespawn || this.gameObject.transform.position.y < -1.5)
            {
                //do not respawn if object is snapped to the disc player as a disc.
                if (!isSnapped)
                {
                    //print(Vector3.Distance(VrCamera.transform.position, this.gameObject.transform.position));
                    StartCoroutine(doTheRespawn());
                }
                
            }
        }
    }

    private IEnumerator doTheRespawn()    //       <-----------------------------------------------------------------------    ADD:    TELEPORT EFFECT-ANIMATION IN THIS COROUTINE-THING
    {
        //To not respawn several times every frame
        respawnIsOngoing = true;

        yield return new WaitForSeconds(0); //This line can be removed or changed (just needed to return something for the IEnumerator)

        //set to startposition again
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.transform.rotation = spawnRotation;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        
        //Reset respawn timer
        timer = Time.time;
        //To detect respawns again
        respawnIsOngoing = false;
    }
}

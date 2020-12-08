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

    public bool isSnapped;


    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private DissolveController _dissolve;

    private void Awake()
    {
        _dissolve = GetComponent<DissolveController>();
        VrCamera = GameObject.FindGameObjectsWithTag("playerCamera")[0];
    }

    private void Start()
    {
        spawnPosition = _dissolve.spawnPoint.position;
        spawnRotation = _dissolve.spawnPoint.rotation;
        _dissolve.value = 1;
        StartCoroutine(Spawn());
        timer = Time.time;
    }

    private void Update()
    {
        if (_dissolve._canTeleportIn && _dissolve.value >= _dissolve._teleportValueMax)
        {
            _dissolve.effect.Stop();
            StartCoroutine(ReSpawn());
            _dissolve._canTeleportIn = false;
        }
        else if (_dissolve._canTeleportOut && _dissolve.value <= 0f)
        {
            _dissolve.effect.Stop();
            _dissolve._canTeleportOut = false;
            //Reset respawn timer
            timer = Time.time;
            //To detect respawns again
            respawnIsOngoing = false;
        }
        
        if (respawnIsOngoing) return;
        
        //restart the timer if it is held by the player, or it is close to its original startpoint
        if (ActiveHand != null || Vector3.Distance(spawnPosition, this.gameObject.transform.position) <= notRespawnDistance)
        {
            timer = Time.time;
        }
        //respawn if the object is out of bounds or timer is down, or y position is bellow the floor
        else if (Vector3.Distance(VrCamera.transform.position, this.gameObject.transform.position) >= respawnDistance || Time.time - timer >= timeBeforeRespawn || this.gameObject.transform.position.y < -1.5)
        {
            print(Vector3.Distance(VrCamera.transform.position, this.gameObject.transform.position));
            StartCoroutine(DeSpawn());
        }
    }

    private IEnumerator DoTheRespawn()
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

    private IEnumerator ReSpawn()
    {
        respawnIsOngoing = true;
        //set to startposition again
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.transform.rotation = spawnRotation;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        _dissolve.effect.Play();
        yield return new WaitForSeconds(2);
        _dissolve._canTeleportIn = true;
        // value from 1 to 0
        // When value is 0 stop effect & Reset variables
    }

    private IEnumerator DeSpawn()
    {
        _dissolve.effect.Play();
        yield return new WaitForSeconds(2);
        _dissolve._canTeleportOut = true;
        // Value from 0 to 1
        // When value is 1 - run Respawn & Stop effect
    }

    private IEnumerator Spawn()
    {
        this.gameObject.transform.position = spawnPosition;
        this.gameObject.transform.rotation = spawnRotation;
        
        _dissolve.effect.Play();
        yield return new WaitForSeconds(2);
        _dissolve._canTeleportIn = true;
        // value from 1 to 0
        // When value is 0 stop effect & Reset variables
    }
}
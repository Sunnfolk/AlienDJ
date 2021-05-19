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

    private Rigidbody rb;


    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private DissolveController _dissolve;

    private void Awake()
    {
        _dissolve = GetComponent<DissolveController>();
        VrCamera = GameObject.FindGameObjectsWithTag("playerCamera")[0];
        rb = GetComponent<Rigidbody>();
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
       
        if (respawnIsOngoing) return;
        
        //restart the timer if it is held by the player, or it is close to its original startpoint
        if (ActiveHand != null || Vector3.Distance(spawnPosition, this.gameObject.transform.position) <= notRespawnDistance)
        {
            timer = Time.time;
        }
        //respawn if the object is out of bounds or timer is down, or y position is bellow the floor
        else if (Vector3.Distance(VrCamera.transform.position, this.gameObject.transform.position) >= respawnDistance || Time.time - timer >= timeBeforeRespawn || this.gameObject.transform.position.y < -1.5)
        {
            if(!isSnapped)
            {
                StartCoroutine(Respawn());  //was DeSpawn before

            }
            
            
        }
    }

    private IEnumerator Respawn()
    {
        respawnIsOngoing = true;
        _dissolve._canTeleportOut = true;
        _dissolve.effect.Play();
        yield return new WaitForSeconds(1);
        transform.position = _dissolve.spawnPoint.position;
        transform.rotation = _dissolve.spawnPoint.rotation;
        rb.velocity = Vector3.zero;
        _dissolve._canTeleportIn = true;
        _dissolve.effect.Play();
        respawnIsOngoing = false;
        timer = Time.time;
    }

    private IEnumerator Spawn()
    {
        
        yield return new WaitForSeconds(0);
        transform.position = _dissolve.spawnPoint.position;
        transform.rotation = _dissolve.spawnPoint.rotation;
        rb.velocity = Vector3.zero;
        _dissolve._canTeleportIn = true;
        _dissolve.effect.Play();
        respawnIsOngoing = false;
        timer = Time.time;
    }
}
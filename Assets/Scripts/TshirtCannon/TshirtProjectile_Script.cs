using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TshirtProjectile_Script : MonoBehaviour
{
    public float speed = 40f; //Speed of the projectile

    private Rigidbody _rb; //projectile rigidbody

    private void Start() 
    {
        Rigidbody _rb = GetComponent<Rigidbody>(); //getting the rigidbody of the projectile
        _rb.velocity = transform.forward * speed;

        gameObject.GetComponent<MeshRenderer>().material.color = new Color(
            Random.Range(0.0f,1.0f), 
            Random.Range(0.0f,1.0f), 
            Random.Range(0.0f,1.0f), 
            1f
        );
    }
    private void Update() 
    {
        transform.Rotate (10*Time.deltaTime, 10*Time.deltaTime, 10*Time.deltaTime);    
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Crowd"))
        {
            Destroy(this.gameObject);
        }
    }


}

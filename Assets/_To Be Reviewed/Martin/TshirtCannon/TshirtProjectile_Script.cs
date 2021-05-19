using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TshirtProjectile_Script : MonoBehaviour
{
    public float speed = 40f; //Speed of the projectile

    private Rigidbody _rb; //projectile rigidbody

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>(); //getting the rigidbody of the projectile
        _rb.velocity = transform.forward * speed;
    }
    private void Update() 
    {
        transform.Rotate (10*Time.deltaTime, 70*Time.deltaTime, 10*Time.deltaTime);    
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Crowd"))
        {
            Destroy(this.gameObject);
        }
    }


}

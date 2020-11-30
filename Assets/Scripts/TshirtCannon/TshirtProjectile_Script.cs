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
    }
    private void Update() 
    {
        transform.Rotate (Random.Range(-90f, 90f)*Time.deltaTime*speed, Random.Range(-90f, 90f)*Time.deltaTime*speed,Random.Range(-80f, 80f)*Time.deltaTime*speed);    
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("crowd"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }


}

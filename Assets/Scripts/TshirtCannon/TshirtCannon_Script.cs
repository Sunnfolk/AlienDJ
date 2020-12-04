using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TshirtCannon_Script : MonoBehaviour
{
    public int Ammunition = 5; //Ammunition you can fire before reload
    private bool reloaded = true;
    [SerializeField] private float reload_delay = 2f; //delay before ammo refill and reallowed to fire
    [Tooltip("Where the projectile will come from.")]
    public Transform firePoint; 
    [Tooltip("The object being fired")]
    public GameObject Tshirt; //Projectile being fired

    private void Update()
    {
        if (Ammunition == 0 && reloaded == true)
        {
            reloaded = false;
           StartCoroutine("Reload");
        }

        ////Testing
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    shoot();
        //}
    }
    public void shoot()
    {
        if ( reloaded == true) //used for testing
        {
            Instantiate(Tshirt, firePoint.position, firePoint.rotation);
            Ammunition -= 1; 
        }
    }
    private IEnumerator Reload()
    {
        reloaded = false;
        yield return new WaitForSeconds(reload_delay);
        Ammunition = 5;
        reloaded = true;
    }

}

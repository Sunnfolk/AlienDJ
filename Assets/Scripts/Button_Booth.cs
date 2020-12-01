using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Booth : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Pushed()
    {
        Debug.Log("I Was PUSEHD");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand_Trigger")
        {

            Pushed();


        }

    }


}

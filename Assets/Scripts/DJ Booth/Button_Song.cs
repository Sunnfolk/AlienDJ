using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Song : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ButtonPushed()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand_Trigger")
        {
            ButtonPushed();
        }
    }

}

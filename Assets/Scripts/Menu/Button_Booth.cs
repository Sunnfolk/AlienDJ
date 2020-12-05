using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Button_Booth : MonoBehaviour
{

    public UnityEvent ButtonFunction;


    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand_Trigger")
        {

            
            ButtonFunction.Invoke();
            Debug.Log("Invoked " + ButtonFunction);

        }

    }


}

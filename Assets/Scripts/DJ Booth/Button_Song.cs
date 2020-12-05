﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Button_Song : MonoBehaviour
{
    [Tooltip("What song Modifier the button activates")][SerializeField]
    private Modifier modifier;

    private bool on;

    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        //Testing
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    on = !on;
        //    ButtonSwitch();
        //}

        


    }

    private void ButtonSwitch()
    {
        switch (modifier)
        {
            case Modifier.mod0:

                //Conditional Operator


                CurrentSong.currentModifier_0 = !on ? 0 : 1;
                //modifier is same as on bool
                //yes: modifier is 1
                //no: modifier is 0
                Debug.Log(CurrentSong.currentModifier_0);
                break;
            case Modifier.mod1:
                CurrentSong.currentModifier_1 = !on ? 0 : 1;

                break;
            case Modifier.mod2:
                CurrentSong.currentModifier_2 = !on ? 0 : 1;

                break;
            case Modifier.mod3:
                CurrentSong.currentModifier_3 = !on ? 0 : 1;

                break;


        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hand_Trigger")
        {
            on = !on;
            ButtonSwitch();
        }
    }

}
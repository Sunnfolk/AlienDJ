using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Test_FMOD : MonoBehaviour
{

    



    

    public int value;

    public bool low;
    public bool high;
    public bool ryth;
    public bool melod;
    public int lowint;
    public int highint;
    public int rythint;
    public int melodint;

    private void Start()
    {
        
    }

    //Don't have to write FMODUnity 0when using the namespace.
    //Use EventRef to find FMOD parameters in the FMOD file.
    //[FMODUnity.EventRef]
    //[SerializeField] private string[] _audioClip;
    //Can be used to get different songs with same parameters


    //[FMODUnity.EventRef]
    //[SerializeField]
    //public FMOD.Studio.EventInstance _event;
    //Finds the FMOD file (whole song) and is used to change parameters in it.
    //Just like you would call an animator with animations, except there is only
    //one animator with set parameters. 

    //[ParamRef]
    //public FMOD.Studio.PARAMETER_TYPE _type;



    private void Update()
    {
        //Code to access the parameters in FMOD file. Just like Animator code
        //_event.setParameterByName("Name of Variable", ParameterValue);
        //Name of variable is a set name and the parameter value is song playing
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            value = 0;
            ResetValues();

        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            value = 1;
            ResetValues();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            value = 2;
            ResetValues();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            value = 3;
            ResetValues();
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            low = !low;
            lowint = !low ? 0 : 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            high = !high;
            highint = !high ? 0 : 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ryth = !ryth;
            rythint = !ryth ? 0 : 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            melod = !melod;
            melodint = !melod ? 0 : 1;
        }



        RuntimeManager.StudioSystem.setParameterByName("song type", value);
        RuntimeManager.StudioSystem.setParameterByName("modifier 0", lowint);
        RuntimeManager.StudioSystem.setParameterByName("modifier 1", highint);
        RuntimeManager.StudioSystem.setParameterByName("modifier 2", rythint);
        RuntimeManager.StudioSystem.setParameterByName("modifier 3", melodint);


    }


    private void ResetValues()
    {
        low = false;
        high = false;
        ryth = false;
        melod = false;
        lowint = 0;
        highint = 0;
        rythint = 0;
        melodint = 0;
    }
    



}

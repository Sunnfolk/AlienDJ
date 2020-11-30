using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Test_FMOD : MonoBehaviour
{

    public float valuez;
    public FMOD.Studio.EventInstance _event;
    public string _playList;
    FMOD.Studio.EventDescription event_Description;
    FMOD.Studio.PARAMETER_DESCRIPTION parameter_Description;
    FMOD.Studio.PARAMETER_ID parameter_ID;

    private void Start()
    {
        event_Description = FMODUnity.RuntimeManager.GetEventDescription(_playList);
        event_Description.getParameterDescriptionByName("Mood", out parameter_Description);
        parameter_ID = parameter_Description.id;
        Debug.Log(parameter_Description);
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
            //Mood(0);
            _event.getParameterByName("Mood", out valuez);
            Debug.Log(valuez);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Mood(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Mood(2);
        }


        
    }

    public void IpodControls()
    {
        var emitter = GetComponent<StudioEventEmitter>();
        
    }

    public void Mood(int _value)
    {
        var emitter = GetComponent<StudioEventEmitter>();
        //emitter.SetParameter("Mood", _value);
        emitter.SetParameter("Mood", _value);
        Debug.Log(_value);
    }




}

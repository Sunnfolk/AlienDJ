using UnityEngine.Events;
using System;

[Serializable]
public class TravelEvent
{
    //Script is used for traveling in and out of game scene
    public string name; //Only for editor
    //This lasts for as long as this value
    public float lastsForSeconds;
    //This is the event that is called
    public UnityEvent mainEvent;

   

}

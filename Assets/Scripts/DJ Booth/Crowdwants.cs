using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowdwants : MonoBehaviour
{
    [Tooltip("How much the want for a song decreases per PointRefreshTimer")][SerializeField] 
    private int decreaseValue = 1;
    [Tooltip("How many seconds between each want increase/decrease")][SerializeField] 
    private int pointRefreshTimer = 1;   

    
    public Crowd crowd;
    [Tooltip("Give the want for a song a boost at start")][SerializeField]
    private int startwant_multiplier = 20;
    
    public int ChillWant; //Chill Want
    public int CalmWant; //Calm want
    public int EnergeticWant; //Energic want
    public int AggresiveWant; //Agressive Want
    
    public int Desireforcurrentsong = 0;
    
    public List<int> _Want = new List<int>();
    private void Start()
    {

        //FIX WHEN YOU SET THESE VALUES TO A SINGLE FUNCTION CALLED IN STARTING GAME
        
    }

    public void SetAndStart()
    {
        Debug.Log("Started");
        if(_Want.Count != 0)
            _Want.Clear();
        Debug.Log(CurrentSong.selectedCrowd);
        crowd = CurrentSong.selectedCrowd;
        //Used to give start value of want
        ChillWant = crowd.chill.want * startwant_multiplier;
        EnergeticWant = crowd.Calm.want * startwant_multiplier;
        CalmWant = crowd.Energic.want * startwant_multiplier;
        AggresiveWant = crowd.Aggressive.want * startwant_multiplier;

        Debug.Log("I AM RUNNING");
        _Want.Add(ChillWant);
        _Want.Add(CalmWant);
        _Want.Add(EnergeticWant);
        _Want.Add(AggresiveWant);
        Debug.Log("I HAVE ADDED");
        StartCoroutine(Want_counter());
    }

    public void StopCounter()
    {
        StopCoroutine(Want_counter());
    }
    
    public IEnumerator Want_counter()
    {
        //increases want on the category based on if they are being played or not
        for (int i = 0; i < _Want.Count; i++)
        {
            if (i == CurrentSong.songPlaying)
            {
                _Want[i] -= decreaseValue;
                Desireforcurrentsong = _Want[i];
                CurrentSong.crowdDesire = Desireforcurrentsong;
            } else{
                switch(i)
                {
                   case 0: 
                   _Want[i] += crowd.chill.want;
                   break;

                   case 1: 
                   _Want[i] += crowd.Calm.want;
                   break;

                   case 2: 
                   _Want[i] += crowd.Energic.want;
                   break;

                   case 3: 
                   _Want[i] += crowd.Aggressive.want;
                   break;
                }
            }
            //So they don't go above 100 or under 0
            _Want[i] = Mathf.Clamp(_Want[i], 0, 100);
        }
        //Begins the process again after a few seconds
        yield return new WaitForSeconds(pointRefreshTimer);
        StartCoroutine(Want_counter());
    }
}
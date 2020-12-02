using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowdwants : MonoBehaviour
{
    [Tooltip("How much the want for a song decreases per PointRefreshTimer")][SerializeField] 
    private int decreaseValue = 1;
    [Tooltip("How many seconds between each want increase/decrease")][SerializeField] 
    private int pointRefreshTimer = 1;   

    
    private Crowd crowd;
    [Tooltip("Give the want for a song a boost at start")][SerializeField]
    private int startwant_multiplier = 20;
    
    private int ChillWant; //Chill Want
    private int CalmWant; //Calm want
    private int EnergeticWant; //Energic want
    private int AggresiveWant; //Agressive Want
    [HideInInspector]
    public int Desireforcurrentsong;
    [HideInInspector]
    public List<int> _Want = new List<int>();
    private void Start()
    {
        crowd = CurrentSong.selectedCrowd;
        //Used to give start value of want
        ChillWant = crowd.chill.want * startwant_multiplier;
        EnergeticWant = crowd.Calm.want * startwant_multiplier;
        CalmWant = crowd.Energic.want * startwant_multiplier;
        AggresiveWant = crowd.Aggressive.want * startwant_multiplier;

        _Want.Add(ChillWant);
        _Want.Add(CalmWant);
        _Want.Add(EnergeticWant);
        _Want.Add(AggresiveWant);
        
        StartCoroutine(Want_counter());
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
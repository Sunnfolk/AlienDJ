using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowdwants : MonoBehaviour
{
   [SerializeField] private int decreaseValue = 1;
   [SerializeField] private int pointrefreshtimer = 1;   

    [SerializeField] private Crowd TestCrowd;
    [SerializeField] private int startwant_multiplier = 30;
    public int AggresiveWant; //Agressive Want
    public int ChillWant; //Chill Want
    public int EnergeticWant; //Energic want
    public int CalmWant; //Calm want
    public int Desireforcurrentsong;

    public List<int> _Want = new List<int>();
    private void Start()
    {
        ChillWant = TestCrowd.chill.want * startwant_multiplier;
        EnergeticWant = TestCrowd.Calm.want * startwant_multiplier;
        CalmWant = TestCrowd.Energic.want * startwant_multiplier;
        AggresiveWant = TestCrowd.Aggressive.want * startwant_multiplier;

        _Want.Add(ChillWant);
        _Want.Add(CalmWant);
        _Want.Add(EnergeticWant);
        _Want.Add(AggresiveWant);
        
        StartCoroutine(Want_counter());
    }
    
    public IEnumerator Want_counter()
    {
        for (int i = 0; i < _Want.Count; i++)
        {
            if (i == Teststatic.song_playing)
            {
                _Want[i] -= decreaseValue;
                Desireforcurrentsong = _Want[i];
            } else{
                switch(i)
                {
                   case 0: 
                   _Want[i] += TestCrowd.chill.want;
                   break;

                   case 1: 
                   _Want[i] += TestCrowd.Calm.want;
                   break;

                   case 2: 
                   _Want[i] += TestCrowd.Energic.want;
                   break;

                   case 3: 
                   _Want[i] += TestCrowd.Aggressive.want;
                   break;
                }
            }
            _Want[i] = Mathf.Clamp(_Want[i], 0, 100);
        }
        yield return new WaitForSeconds(pointrefreshtimer);
        StartCoroutine(Want_counter());
    }
        
    private void Update()
    {
        /* Debug.Log("SongDesire: " + Desireforcurrentsong);
        Debug.Log("Chill: "+ _Want[0]);
        Debug.Log("Calm: "+ _Want[1]);
        Debug.Log("Energetic: "+ _Want[2]);
        Debug.Log("Aggresive" +_Want[3]); */
    }
}
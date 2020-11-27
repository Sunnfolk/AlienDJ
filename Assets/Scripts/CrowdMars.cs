using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMars : MonoBehaviour
{
    [SerializeField] private CrowdXample crowdwantcontiner;
    [SerializeField] private int MarsWantChill = 3;
    [SerializeField] private int MarsWantCalm = 1;
    [SerializeField] private int MarsWantEnergetic = 1;
    [SerializeField] private int MarsWantAggresive = 2;

    [SerializeField] private int MarsStartChill = 75;
    [SerializeField] private int MarsStartCalm = 0;
    [SerializeField] private int MarsStartEnergetic = 25;
    [SerializeField] private int MarsStartAggresive = 50;
    private void Awake()
    {
        //Hvorfor er denne lista ikke i riktig rekkefølge? 
        //FORDI det var sånn den ble lagd originalt og jeg gidder ikke fikse
        crowdwantcontiner.AggresiveWantMod = MarsWantAggresive; 
        crowdwantcontiner.ChillWantMod = MarsWantChill;
        crowdwantcontiner.EnergeticWantMod = MarsWantEnergetic;
        crowdwantcontiner.CalmWantMod = MarsWantCalm;

        crowdwantcontiner.ChillStartWant = MarsStartChill;
        crowdwantcontiner.CalmStartWant = MarsStartCalm;
        crowdwantcontiner.EnergeticStartWant = MarsStartEnergetic;
        crowdwantcontiner.AggresiveStartWant = MarsStartAggresive;
    }
}

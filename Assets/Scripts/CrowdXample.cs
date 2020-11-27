using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CrowdXample : ScriptableObject
{
    public int AggresiveWantMod;
    public int ChillWantMod;
    public int EnergeticWantMod;
    public int CalmWantMod;

    public int AggresiveStartWant;
    public int ChillStartWant;
    public int EnergeticStartWant;
    public int CalmStartWant;

    public int CalmLowFreModif;
    public int CalmHighFreModif;
    public int CalmMelodicModif;
    public int CalmRythmModif;
}

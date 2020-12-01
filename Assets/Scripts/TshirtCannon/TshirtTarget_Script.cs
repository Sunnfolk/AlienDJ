using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TshirtTarget_Script : MonoBehaviour
{
    public Score_Script _ScoreScript;
    [SerializeField] private int TshirtScoreIncrease = 200;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Tshirt"))
        {
            _ScoreScript._Score += TshirtScoreIncrease;
        }
    }
}

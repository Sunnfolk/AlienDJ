using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBuzzer_Script : MonoBehaviour
{
    public float BuzzerCooldownTime = 20;
    private float BuzzerCooldown = 0;
    [SerializeField] private int Buzzerwantadd = 20;
    public Crowdwants _crowdwant;

    private void Update() 
    {
        BuzzerCooldown = BuzzerCooldown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            BuzzerActivate();
        }
        if (BuzzerCooldown < 0)
        {
            BuzzerCooldown = 0;
        }
    }
    private void BuzzerActivate()
    {
        if (BuzzerCooldown == 0)
        {
            BuzzerCooldown += BuzzerCooldownTime;
            for (int i = 0; i < _crowdwant._Want.Count; i++)
            {
                if (i == Teststatic.song_playing)
                {
                    _crowdwant._Want[i] += Buzzerwantadd;
                }
            }   
        }

        
    }
}

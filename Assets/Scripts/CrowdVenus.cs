using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdVenus : MonoBehaviour
{
    [SerializeField] public Crowd TestCrowd;

    private void Awake()
    {
        TestCrowd.chill.want = 2;
        TestCrowd.chill.LowFrequency = true;
        TestCrowd.chill.HighFrequency = false;
        TestCrowd.chill.Melodic = false;
        TestCrowd.chill.Rhythmic = true;

        TestCrowd.Calm.want = 3;
        TestCrowd.Calm.LowFrequency = true;
        TestCrowd.Calm.HighFrequency = false;
        TestCrowd.Calm.Melodic = true;
        TestCrowd.Calm.Rhythmic = false;

        TestCrowd.Energic.want = 1;
        TestCrowd.Energic.LowFrequency = false;
        TestCrowd.Energic.HighFrequency = true;
        TestCrowd.Energic.Melodic = true;
        TestCrowd.Energic.Rhythmic = false;

        TestCrowd.Aggressive.want = 4;
        TestCrowd.Aggressive.LowFrequency = false;
        TestCrowd.Aggressive.HighFrequency = true;
        TestCrowd.Aggressive.Melodic = false;
        TestCrowd.Aggressive.Rhythmic = true;
    }
}

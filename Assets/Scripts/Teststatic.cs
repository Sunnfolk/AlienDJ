using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teststatic : MonoBehaviour
{
    public static int song_playing;
    public int song = 0;

    [SerializeField] public bool LowFrequency_playing = false;
    public static bool LF_Playing;
    [SerializeField] public bool HighFrequency_playing = false;
    public static bool HF_Playing;
    [SerializeField] public bool Melodic_playing = false;
    public static bool MEL_Playing;
    [SerializeField] public bool Rythmic_playing = false;
    public static bool RHY_Playing;
    public static int _colorshowing;
    [SerializeField] public int Colorcurrentlyshowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _colorshowing = Colorcurrentlyshowing;
        song_playing = song;
        LF_Playing = LowFrequency_playing;
        HF_Playing = HighFrequency_playing;
        MEL_Playing = Melodic_playing;
        RHY_Playing = Rythmic_playing;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GameToFmod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RuntimeManager.StudioSystem.setParameterByName("song type", CurrentSong.songPlaying);
        RuntimeManager.StudioSystem.setParameterByName("modifier 0", CurrentSong.currentModifier_0);
        RuntimeManager.StudioSystem.setParameterByName("modifier 1", CurrentSong.currentModifier_1);
        RuntimeManager.StudioSystem.setParameterByName("modifier 2", CurrentSong.currentModifier_2);
        RuntimeManager.StudioSystem.setParameterByName("modifier 3", CurrentSong.currentModifier_3);




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameEnviorment : MonoBehaviour
{

    public Crowd menuCrowd;
    

    public void SetEnviorment(bool _menu)
    {
        if (_menu)
            CurrentSong.selectedCrowd = menuCrowd;


        //Set Skybox(CurrentSong.selectedCrowd.Skybox)
        //Set Music CurrentSong.selectedCrowd.music

    }

}

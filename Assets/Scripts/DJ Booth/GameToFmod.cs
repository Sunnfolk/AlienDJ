using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GameToFmod : MonoBehaviour
{

    [Header("Values used for testing")]
    [Range(0, 3)]
    public int songCategory;
    [Range(0, 1)]
    public int modifier_0;
    [Range(0, 1)]
    public int modifier_1;
    [Range(0, 1)]
    public int modifier_2;
    [Range(0, 1)]
    public int modifier_3;
    [Range(0, 1)]
    public float disco;
    [Range(0, 1)]
    public int menu;
    [Range(0, 10)]
    public int ambience;

    // Start is called before the first frame update
    void Start()
    {
        GameSettings.planetIndex = 10;
        menu = 1;
    }

    // Update is called once per frame
    void Update()
    {

        ambience = GameSettings.planetIndex;
        songCategory = CurrentSong.songPlaying;
        modifier_0 = CurrentSong.currentModifier_0;
        modifier_1 = CurrentSong.currentModifier_1;
        modifier_2 = CurrentSong.currentModifier_2;
        modifier_3 = CurrentSong.currentModifier_3;
        disco = CurrentSong.discoValue;

        RuntimeManager.StudioSystem.setParameterByName("Song_Type", CurrentSong.songPlaying); //setup
        RuntimeManager.StudioSystem.setParameterByName("Modifier_0", CurrentSong.currentModifier_0); //setup
        RuntimeManager.StudioSystem.setParameterByName("Modifier_1", CurrentSong.currentModifier_1); //setup
        RuntimeManager.StudioSystem.setParameterByName("Modifier_2", CurrentSong.currentModifier_2); //setup
        RuntimeManager.StudioSystem.setParameterByName("Modifier_3", CurrentSong.currentModifier_3); //setup
        RuntimeManager.StudioSystem.setParameterByName("Disco", CurrentSong.discoValue);
        RuntimeManager.StudioSystem.setParameterByName("Menu", menu); //ok
        RuntimeManager.StudioSystem.setParameterByName("Planet_Ambient", GameSettings.planetIndex); //ok


    }

    public void SetMenu(bool _bool)
    {
        menu = _bool ? 1 : 0;
    }

    public void SetMainMenuMusic()
    {
        GameSettings.planetIndex = 10;

    }


}

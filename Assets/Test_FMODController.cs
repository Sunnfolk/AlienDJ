using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Test_FMODController : MonoBehaviour
{
    [Range(0, 3)]
    public int songCategory;
    [Range (0,1)]
    public int modifier_0;
    [Range(0, 1)]
    public int modifier_1;
    [Range(0, 1)]
    public int modifier_2;
    [Range(0, 1)]
    public int modifier_3;
    [Range(0,1)]
    public float disco;
    [Range(0,1)]
    public int menu;
    [Range(0,10)]
    public int ambience;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RuntimeManager.StudioSystem.setParameterByName("Song_Type", songCategory);
        RuntimeManager.StudioSystem.setParameterByName("Modifier_0", modifier_0);
        RuntimeManager.StudioSystem.setParameterByName("Modifier_1", modifier_1);
        RuntimeManager.StudioSystem.setParameterByName("Modifier_2", modifier_2);
        RuntimeManager.StudioSystem.setParameterByName("Modifier_3", modifier_3);
        RuntimeManager.StudioSystem.setParameterByName("Disco", disco);
        RuntimeManager.StudioSystem.setParameterByName("Menu", menu);
        RuntimeManager.StudioSystem.setParameterByName("Planet_Ambient", ambience);
    }
}

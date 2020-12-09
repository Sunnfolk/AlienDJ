using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Crowd")]
public class Crowd : ScriptableObject
{

    public string planetName;
    [TextArea]
    public string text;

    public Sprite planetImage;
    [FMODUnity.EventRef]
    public string voiceLine;

    public Category chill;

    public Category Aggressive;

    public Category Energic;

    public Category Calm;

    public Texture Skybox;

    public int Top;

    public int Mid;

    public int Bot;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Crowd")]
public class Crowd : ScriptableObject
{
    [TextArea]
    public string text;

    public Category chill;

    public Category Aggressive;

    public Category Energic;

    public Category Calm;

    public Texture Skybox;

    public int Top;

    public int Mid;

    public int Bot;


}

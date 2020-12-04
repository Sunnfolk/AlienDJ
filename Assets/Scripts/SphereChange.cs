using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChange : MonoBehaviour
{
    public GameObject EmotionSphere;
    public Vector3 scaleChange, positionChange;
    public float Maxsize;

    public Material Chill;
    public Material Calm;
    public Material Energic;
    public Material Aggresive;

    public int SongPlaying;// Replace with static

    public MeshRenderer Renderer;

    private void Awake()
    {
        Camera.main.clearFlags = CameraClearFlags.SolidColor;

        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        positionChange = new Vector3(0.0f, -0.005f, 0.0f);
    }
    private void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (SongPlaying == 0)
        {
            Renderer.material = Chill;
            Maxsize = 1.5f;
            EmotionSphere.transform.localScale = new Vector3(1f, 1f, 1f);
            //scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else if (SongPlaying == 1)
        {
            Renderer.material = Calm;
            Maxsize = 2f;
            EmotionSphere.transform.localScale = new Vector3(1f, 1f, 1f);
            scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
           //scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        }
        else  if (SongPlaying == 2)
        {
            Renderer.material = Energic;
            Maxsize = 2.5f;
          //  scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        }
        else if (SongPlaying == 3)
        {
            Renderer.material = Aggresive;
            Maxsize = 3f;
           // scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        }

        EmotionSphere.transform.localScale += scaleChange;
        //EmotionSphere.transform.position += positionChange;

        // Move upwards when the sphere hits the floor or downwards
        // when the sphere scale extends 1.0f.
        if (EmotionSphere.transform.localScale.y < 1f || EmotionSphere.transform.localScale.y > Maxsize)
        {
            Debug.Log("OMG I AM CHANGING");
            scaleChange = -scaleChange;
            //positionChange = -positionChange;
        }
    }

}

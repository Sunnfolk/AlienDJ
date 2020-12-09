 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Light : MonoBehaviour
{
    [SerializeField]
    private LightColor lightColor;
    private int colorIndex;

    private bool on;

    [FMODUnity.EventRef]
    public string ButtonPushSound = "";

    // Start is called before the first frame update
    void Start()
    {
        switch (lightColor)
        {
            case LightColor.blue:
                colorIndex = 0;
                break;
            case LightColor.green:
                colorIndex = 1;
                break;
            case LightColor.yellow:
                colorIndex = 2;
                break;
            case LightColor.red:
                colorIndex = 3;
                break;
        }
    }


    private void Update()
    {
       
        on = colorIndex == CurrentSong.currentColor;
       /* if(on)
            Debug.Log(lightColor + " is " + on);
       */
    }


    void SetColor()
    {
        switch (lightColor)
        {
            case LightColor.blue:
                
                CurrentSong.currentColor = 0;

                break;
            case LightColor.green:

                CurrentSong.currentColor = 1;

                break;
            case LightColor.yellow:

                CurrentSong.currentColor = 2;

                break;
            case LightColor.red:

                CurrentSong.currentColor = 3;

                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand_Trigger")
        {
            FMODUnity.RuntimeManager.PlayOneShot(ButtonPushSound);
            SetColor();
        }
    }



    
}
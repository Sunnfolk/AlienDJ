 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Light : MonoBehaviour
{
    [SerializeField]
    private LightColor lightColor;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            SetColor();
        }
    }



}

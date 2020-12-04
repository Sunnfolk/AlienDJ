using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private float hyperspeedTimer = 1f;

    public Animator animator;

    public Canvas menu;

    public Canvas photoSensitivityMenu;

    public GameObject hyperspeed;

    [SerializeField] private Material skybox;

    //crowd; find the crowd scriptable object

    public void PlanetSelect()
    {
        //set the crowd from the planet
        
        menu.enabled = false;

        photoSensitivityMenu.enabled = true;
    }

    public void EnableHyperspeed()
    {
        AccessibilityContainer.hyperspeedEnable = true;
    }

    public void DisabeleHyperspeed()
    {
        AccessibilityContainer.hyperspeedEnable = false;
    }

    public void EnableLightShow()
    {
        AccessibilityContainer.lightShowEnable = true;
    }

    public void DisableLightShow()
    {
        AccessibilityContainer.lightShowEnable = false;
    }

    public void Play()
    {
        //skybox = get the skybox from the crowd;
        if (AccessibilityContainer.hyperspeedEnable == true)
        {
            //animator.SetTrigger(1);
            hyperspeed.SetActive(true);
            StartCoroutine(HyperspeedEnd());
        }
        else if (AccessibilityContainer.hyperspeedEnable == false)
        {
            //animator.SetTrigger(3);
            //Alienspawn();
        }
        RenderSettings.skybox = skybox;
    }

    public IEnumerator HyperspeedEnd()
    {
        yield return new WaitForSeconds(hyperspeedTimer);
        //hyperspeedflash animator.SetTrigger(2);
        hyperspeed.SetActive(false);
        //Alienspawn();
    }
}
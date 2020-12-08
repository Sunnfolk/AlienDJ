using System;
using UnityEngine;

public class LightAnimationController : MonoBehaviour
{
    [SerializeField] private Animator lightShowInner;

    [SerializeField] private Animator innerLightRotate;

    [SerializeField] private Animator outerLightRotate;

    private void Update()
    {
        
    }

    public void PlayChill()
    {
        CallOnAnimation(lightShowInner, "LightShow Chill" );
        CallOnAnimation(innerLightRotate, "InnerLight_Chill" );
        CallOnAnimation(outerLightRotate, "OuterLight Chill" );
    }

    public void PlayCalm()
    {
        CallOnAnimation(lightShowInner, "LightShow Calm" );
        CallOnAnimation(innerLightRotate, "InnerLight_Calm" );
        CallOnAnimation(outerLightRotate, "OuterLight Calm" );
    }

    public void PlayEnergetic()
    {
        CallOnAnimation(lightShowInner, "LightShow Energetic" );
        CallOnAnimation(innerLightRotate, "InnerLight_Energetic" );
        CallOnAnimation(outerLightRotate, "OuterLight Energetic" );
    }

    public void PlayAggressive()
    {
        CallOnAnimation(lightShowInner, "LightShow Aggressive" );
        CallOnAnimation(innerLightRotate, "InnerLight_Aggressive" );
        CallOnAnimation(outerLightRotate, "OuterLight Aggressive" );
    }

    public void PlayDefault()
    {
        CallOnAnimation(lightShowInner, "New State" );
        CallOnAnimation(innerLightRotate, "New State" );
        CallOnAnimation(outerLightRotate, "Default State" );
    }

    private void CallOnAnimation(Animator anim, string state)
    {
        anim.Play(state);
    }
}

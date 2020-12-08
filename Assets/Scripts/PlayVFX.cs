using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayVFX : MonoBehaviour
{
    public VisualEffect effect;

    public void OnGrip()
    {
        effect.Play();
    }

    public void OnRelease()
    {
        effect.Stop();
    }
    
    private void OnDisable()
    {
        effect.Stop();
    }
}

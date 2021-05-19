using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.VFX;
using Random = System.Random;

public class LerpTeleport : MonoBehaviour
{

    private Material mat;

    public float lerpvalue;
    public float lerpTime;
    
    public float max;
    
    public bool lerpIn;
    public bool lerpOut;

    public VisualEffect effect;
    
    public GameObject _SpineRend;
    public SpriteRenderer _spriteRenderer;

    public float waitTime;

    private bool candespawn;

    private void OnEnable()
    {
        candespawn = true;
        mat = _spriteRenderer.material;
        
        effect.Stop();
        _spriteRenderer.enabled = true;
        _SpineRend.SetActive(false);
        lerpvalue = 0f;
        StartCoroutine(nameof(_teleIn), waitTime);
    }
    

    // Update is called once per frame
    private void Update()
    {
        lerpvalue = Mathf.Clamp(lerpvalue, 0, max);
        
        mat.SetFloat("Vector1_FA25B07E", lerpvalue);

        if (AlienDespawn.StaticTimerisFinishedBool && candespawn)
        {
            _SpineRend.GetComponent<SkeletonAnimation>().AnimationState.SetEmptyAnimation(0, 0.25f);
            StartCoroutine(nameof(_teleOut), 1f);
            candespawn = false;
        }
        

        if (lerpIn)
        {
            lerpvalue += lerpTime;
        }
        else if (lerpOut)
        {
            lerpvalue -= lerpTime;
        }
        
        if (lerpIn && lerpvalue >= max)
        {
            _spriteRenderer.enabled = false;
            effect.Stop();
            _SpineRend.SetActive(true);
            lerpIn = false;
        }
        else if (lerpOut && lerpvalue <= 0f)
        {
            effect.Stop();
            lerpOut = false;
        }

    }
    
    private IEnumerator _teleIn(float time)
    {
        var timer = UnityEngine.Random.Range(2f, 10f);
        yield return new WaitForSeconds(timer);
        
        effect.Play();
        yield return new WaitForSeconds(time);
        lerpIn = true;

    }
    private IEnumerator _teleOut(float time)
    {
        effect.Play();
        _spriteRenderer.enabled = true;
        _SpineRend.SetActive(false);
        yield return new WaitForSeconds(time);
        lerpOut = true;
    }
}
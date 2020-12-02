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

    public bool StaticTimerisFinishedBool;
    
    
    private void OnEnable()
    {
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


        if (StaticTimerisFinishedBool)
        {
            _SpineRend.GetComponent<SkeletonAnimation>().AnimationState.SetEmptyAnimation(0, 0.25f);
            StartCoroutine(nameof(_teleOut), 1f);
            StaticTimerisFinishedBool = false;
        }
        

        if (lerpIn)
        {
            print(transform.name + " " + lerpvalue);
            lerpvalue += lerpTime;
            print("TeleportingIn");
            
        }
        else if (lerpOut)
        {
            lerpvalue -= lerpTime;
            print("TeleportingOut");
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
        print((gameObject.name + "" + timer));
        
        yield return new WaitForSeconds(timer);
        
        effect.Play();
        yield return new WaitForSeconds(time);
        print("TeleportingIn Numerator");
        lerpIn = true;

    }
    private IEnumerator _teleOut(float time)
    {
        _spriteRenderer.enabled = true;
        _SpineRend.SetActive(false);
        
        effect.Play();
        yield return new WaitForSeconds(time);
        lerpOut = true;
        print("TeleportingOut Numerator");
    }
}
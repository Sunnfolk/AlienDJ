using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.VFX;
using Random = System.Random;

public class AlienTeleport : MonoBehaviour
{
    [Header("VFX")]
    public VisualEffect effect;
    [Space(5f)]
    [Header("Teleport Variables")]
    [SerializeField] private float _teleportTime;
    [SerializeField] private float _vfxWaitTime;
    [SerializeField] private float _spawnRandomMin;
    [SerializeField] private float _spawnRandomMax;
    
    [Space(5f)]
    [Header("Components")]
    [SerializeField] private GameObject _SpineRenderer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    
    private Material _material;

    private float _teleportValue;
    public float _teleportValueMax;

    private bool _canTeleportIn;
    private bool _canTeleportOut;
    
    private bool _alienCanDespawn;

    private void OnEnable()
    {
        _alienCanDespawn = true;
        _material = _spriteRenderer.material;
        
        effect.Stop();
        _spriteRenderer.enabled = true;
        _SpineRenderer.SetActive(false);
        _teleportValue = 0f;
        
        StartCoroutine(nameof(TeleportIn), _vfxWaitTime);
    }
    

    // Update is called once per frame
    private void Update()
    {
        _teleportValue = Mathf.Clamp(_teleportValue, 0, _teleportValueMax);
        _material.SetFloat("Vector1_FA25B07E", _teleportValue);

        if (AlienDespawn.StaticTimerisFinishedBool && _alienCanDespawn)
        {
            _SpineRenderer.GetComponent<SkeletonAnimation>().AnimationState.SetEmptyAnimation(0, 0.25f);
            StartCoroutine(nameof(TeleportOut), 1f);
            _alienCanDespawn = false;
        }
        
        // These if statements cause the teleport value to increase or decrease, thereby visualising the teleport.
        if (_canTeleportIn)
        {
            _teleportValue += _teleportTime;
        }
        else if (_canTeleportOut)
        {
            _teleportValue -= _teleportTime;
        }
        
        // Check Whether the player should be able to teleport in or out 
        if (_canTeleportIn && _teleportValue >= _teleportValueMax)
        {
            _spriteRenderer.enabled = false;
            effect.Stop();
            _SpineRenderer.SetActive(true);
            _canTeleportIn = false;
        }
        else if (_canTeleportOut && _teleportValue <= 0f)
        {
            effect.Stop();
            _canTeleportOut = false;
        }

    }
    
    private IEnumerator TeleportIn(float time)
    {
        var timer = UnityEngine.Random.Range(_spawnRandomMin, _spawnRandomMax);
        yield return new WaitForSeconds(timer);
        
        effect.Play();
        yield return new WaitForSeconds(time);
        _canTeleportIn = true;

    }

    public IEnumerator TeleportOut(float time)
    {
        effect.Play();
        _spriteRenderer.enabled = true;
        _SpineRenderer.SetActive(false);
        yield return new WaitForSeconds(time);
        _canTeleportOut = true;
    }
}
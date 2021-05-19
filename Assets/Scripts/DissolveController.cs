using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolveController : MonoBehaviour
{
    private Material _material;

    public float value;

    public MeshRenderer _rend;

    public VisualEffect effect;

    public Transform spawnPoint;
    
    [HideInInspector] public bool _canTeleportIn;
    [HideInInspector] public bool _canTeleportOut;
    
    [SerializeField] private float _teleportTime;
    public float _teleportValueMax;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _material = _rend.material;
    }

    // Update is called once per frame
    private void Update()
    {
        value = Mathf.Clamp(value, 0, _teleportValueMax);
        _material.SetFloat("Vector1_FA25B07E", value);
        
        if (_canTeleportIn)
        {
            value -= _teleportTime;
            if(value <= 0)
            {
                effect.Stop();
                _canTeleportIn = false;
            }
        }
        else if (_canTeleportOut)
        {
            value += _teleportTime;
            if(value >= _teleportValueMax)
            {
                effect.Stop();
                _canTeleportOut = false;
            }
        }
    }
}
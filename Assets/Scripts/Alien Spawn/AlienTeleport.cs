using System.Collections;
using Spine.Unity;
using UnityEngine;
using UnityEngine.VFX;

namespace Alien_Spawn
{
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
        [SerializeField] private float _teleportValueMax;
    
        [Space(5f)]
        [Header("Components")]
        [SerializeField] private GameObject _SpineRenderer;
       // private MeshRenderer _rend;
        [SerializeField] private SpriteRenderer _spriteRenderer;
    
        private Material _material;

        private float _teleportValue;

        private bool _canTeleportIn;
        private bool _canTeleportOut;
    
        private bool _alienCanDespawn;

        private void OnEnable()
        {
           // _rend = _SpineRenderer.GetComponent<MeshRenderer>();
            _alienCanDespawn = true;
            _material = _spriteRenderer.material;
        
            effect.Stop();
            _spriteRenderer.enabled = true;
            _SpineRenderer.SetActive(false);
            //_rend.enabled = true;
            _teleportValue = 0f;
        
            StartCoroutine(nameof(TeleportIn), _vfxWaitTime);
        }
    

        // Update is called once per frame
        private void Update()
        {
            _teleportValue = Mathf.Clamp(_teleportValue, 0, _teleportValueMax);
            _material.SetFloat("Vector1_FA25B07E", _teleportValue);

            if (GameSettings.alienDespawn && _alienCanDespawn)
            {
                _SpineRenderer.GetComponent<AnimatedAlienCharacter>().PlayIdle();
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
                //_rend.enabled = true;
                _SpineRenderer.SetActive(true);
                _canTeleportIn = false;
            }
            else if (_canTeleportOut && _teleportValue <= 0f)
            {
                effect.Stop();
                Destroy(transform.parent.gameObject);
                _canTeleportOut = false;
            }
        }
    
        // IENumerator Function for Starting the teleportIN
        private IEnumerator TeleportIn(float time)
        {
            GameSettings.alienSpawn = false;
            var timer = UnityEngine.Random.Range(_spawnRandomMin, _spawnRandomMax);
            yield return new WaitForSeconds(timer);
        
            effect.Play();
            yield return new WaitForSeconds(time);
            _canTeleportIn = true;

        }
    
        // IENumerator Function for Starting the teleportOut
        public IEnumerator TeleportOut(float time)
        {
            effect.Play();
            _spriteRenderer.enabled = true;
            _SpineRenderer.SetActive(false);
            //_rend.enabled = false;
            yield return new WaitForSeconds(time);
            _canTeleportOut = true;
        }
    }
}
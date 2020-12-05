using System;
using UnityEngine;

namespace HyperSpace
{
    public class LightFadeAnimator : MonoBehaviour
    {
        private Animator _animator;
    
        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Fade();
            }
        }

        public void Fade()
        {
            _animator.Play("Flash");
        }
    }
}
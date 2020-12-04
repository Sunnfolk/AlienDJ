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
                FadeIn();
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                FadeOut();
            }
        }

        public void FadeIn()
        {
            _animator.Play("LightFlashIn");
        }

        public void FadeOut()
        {
            _animator.Play("LightFlashOut");
        }
    }
}
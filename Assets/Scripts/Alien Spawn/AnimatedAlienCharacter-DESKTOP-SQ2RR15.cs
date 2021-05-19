using System;
using Spine.Unity;
using UnityEngine;

namespace Alien_Spawn
{
    public class AnimatedAlienCharacter : MonoBehaviour
    {
        private SkeletonAnimation _skeletonAnimation;

        [SerializeField] private AnimationReferenceAsset _boredDance;
        [SerializeField] private AnimationReferenceAsset _normalDance;
        [SerializeField] private AnimationReferenceAsset _hypedDance;
        [SerializeField] private AnimationReferenceAsset _idle;

        private bool _canplayBored;
        private bool _canplayNormal;
        private bool _canplayHyped;
        
        // Start is called before the first frame update
        private void OnEnable()
        {
            _canplayHyped = true;
            _canplayBored = true;
            _canplayNormal = true;
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            PlayIdle();
        }

        private void Update()
        {
            // Add code to call upon the animations based on current want

            if ((CurrentSong.crowdDesire > CurrentSong.selectedCrowd.Top && CurrentSong.crowdDesire < 100) && _canplayHyped)
            {
                PlayHyped();
                _canplayHyped = false;
                _canplayNormal = true;
                _canplayBored = true;
            }
            else if ((CurrentSong.crowdDesire > CurrentSong.selectedCrowd.Mid && CurrentSong.crowdDesire < CurrentSong.selectedCrowd.Top) && _canplayNormal)
            {
                PlayNormal();
                _canplayHyped = true;
                _canplayNormal = false;
                _canplayBored = true;
            }
            else if ((CurrentSong.crowdDesire > -10f && CurrentSong.crowdDesire < CurrentSong.selectedCrowd.Mid) && _canplayBored)
            {
                PlayBored();
                _canplayHyped = true;
                _canplayNormal = true;
                _canplayBored = false;
            }
        }

        public void PlayBored()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _boredDance.Animation, true);
        }

        public void PlayNormal()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _normalDance.Animation, true);
        }

        public void PlayHyped()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _hypedDance.Animation, true);
        }

        public void PlayIdle()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _idle.Animation, true);
        }
    }
}
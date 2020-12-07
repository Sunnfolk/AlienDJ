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
    
        
        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            PlayIdle();
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
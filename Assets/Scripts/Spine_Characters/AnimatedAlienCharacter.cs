using Spine.Unity;
using UnityEngine;

namespace Spine_Characters
{
    public class AnimatedAlienCharacter : MonoBehaviour
    {
        private SkeletonAnimation _skeletonAnimation;

        [SerializeField] private AnimationReferenceAsset _boredDance;
        [SerializeField] private AnimationReferenceAsset _normalDance;
        [SerializeField] private AnimationReferenceAsset _hypedDance;
    
        
        // Start is called before the first frame update
        private void Start()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _skeletonAnimation.AnimationState.SetAnimation(0, _boredDance.Animation, true);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                _skeletonAnimation.AnimationState.SetAnimation(0, _boredDance.Animation, true);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                _skeletonAnimation.AnimationState.SetAnimation(0, _normalDance.Animation, true);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                _skeletonAnimation.AnimationState.SetAnimation(0, _hypedDance.Animation, true);
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                _skeletonAnimation.AnimationState.SetEmptyAnimation(0, 0.25f);
            }
        }
    }
}

using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class HumanoidAssembler : EntityComponent
    {
        [SerializeField]
        private BodyPart[] _bodyParts;

        private Animator _animator;
        private AnimatorOverrideController _animatorOverrideController;

        public void Begin(Animator animator)
        {
            _animator = animator;
            
            base.Begin();
        }
        
        protected override void OnBegin()
        {
            base.OnBegin();
            
            SetRuntimeAnimatorController();
            
            UpdateBodyParts();
        }

        private void UpdateBodyParts()
        {
            for (int i = 0; i < _bodyParts.Length; i++)
            {
                BodyPart bodyPart = _bodyParts[i];

                OverrideBodyPartClipsCollection(bodyPart);
            }
        }

        private void OverrideBodyPartClipsCollection(BodyPart bodyPart)
        {
            BodyPartClipsCollection[] clipsCollections = bodyPart.ClipsCollections;

            for (int i = 0; i < clipsCollections.Length; i++)
            {
                BodyPartClipsCollection clipsCollection = clipsCollections[i];

                OverrideAnimationClips(clipsCollection);
            }
        }

        private void OverrideAnimationClips(BodyPartClipsCollection clipsCollection)
        {
            AnimationClip[] animationClips = clipsCollection.AnimationClips;
            
            for (int i = 0; i < animationClips.Length; i++)
            {
                AnimationClip animationClip = animationClips[i];

                string clipName = animationClip.name;
                string clipNameSub = clipName.Substring(0, clipName.LastIndexOf("_"));

                Debug.Log($"ClipName: {clipName} | ClipNameSub: {clipNameSub}");
                
                _animatorOverrideController[clipNameSub] = animationClip;
            }
        }
        
        private void SetRuntimeAnimatorController()
        {
            _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);

            _animator.runtimeAnimatorController = _animatorOverrideController;
        }
    }
}
using System.Linq;
using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class HumanoidAssembler : EntityComponent
    {
        [SerializeField]
        private BodyPart[] _bodyParts;
        [SerializeField]
        private BodyPartsCollectionData _partsCollectionData;
        
        private Animator _animator;
        private AnimatorOverrideController _animatorOverrideController;

        public void Begin(Animator animator)
        {
            _animator = animator;
            
            base.Begin();
        }

        public void EquipBodyPart(BodyPartData bodyPartData)
        {
            for (int i = 0; i < _bodyParts.Length; i++)
            {
                BodyPart bodyPart = _bodyParts[i];

                if (bodyPart.CategoryId.Contains(bodyPart.CategoryId))
                {
                    bodyPart.SetBodyPartData(bodyPartData);
                }
            }

            OverrideAnimatorAnimationClips(bodyPartData);
        }

        protected override void OnBegin()
        {
            base.OnBegin();
            
            SetRuntimeAnimatorController();
            
            BeginBodyParts();
        }

        private void BeginBodyParts()
        {
            for (int i = 0; i < _bodyParts.Length; i++)
            {
                BodyPart bodyPart = _bodyParts[i];

                bodyPart.Begin();

                if (_partsCollectionData.TryGetDefaultBodyPartByCategoryId(bodyPart.CategoryId, out BodyPartData data))
                {
                    OverrideAnimatorAnimationClips(data);
                }
            }
        }

        private void OverrideAnimatorAnimationClips(BodyPartData bodyPartData)
        {
            AnimationClip[] animationClips = bodyPartData.AnimationClips;
        
            for (int i = 0; i < animationClips.Length; i++)
            {
                AnimationClip animationClip = animationClips[i];
                
                string subClipName = GetSubClipName(animationClip.name);

                _animatorOverrideController[subClipName] = animationClip;
            }
        }

        private string GetSubClipName(string clipName)
        {
            char targetChar = '_';

            int targetCharCount = clipName.Count(c => c == targetChar);

            bool isTheBaseClip = targetCharCount == 2;
            
            if (isTheBaseClip)
            {
                return clipName;
            }
            
            return clipName.Substring(0, clipName.LastIndexOf(targetChar));
        }

        private void SetRuntimeAnimatorController()
        {
            _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);

            _animator.runtimeAnimatorController = _animatorOverrideController;
        }
    }
}
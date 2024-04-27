using System.Linq;
using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class HumanoidAssembler : EntityComponent
    {
        [SerializeField]
        private BodyPartsCollection _bodyPartsCollection;
        
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

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

#if DEBUG
            if (UnityEngine.Input.GetKeyDown(KeyCode.O))
            {
                BodyPart[] allHeads = _bodyPartsCollection.AllHeads;
                
                int randomNumber = Random.Range(0, allHeads.Length);
                
                BodyPart randomHead = allHeads[randomNumber];
                
                OverrideAnimatorAnimationClips(randomHead);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.P))
            {
                BodyPart[] allOutfits = _bodyPartsCollection.AllOutfits;
                
                int randomNumber = Random.Range(0, allOutfits.Length);
                
                BodyPart randomOutfit = allOutfits[randomNumber];
                
                OverrideAnimatorAnimationClips(randomOutfit);
            }
#endif
        }

        private void UpdateBodyParts()
        {
            OverrideAnimatorAnimationClips(_bodyPartsCollection.DefaultBody);
            
            OverrideAnimatorAnimationClips(_bodyPartsCollection.DefaultHead);
            
            OverrideAnimatorAnimationClips(_bodyPartsCollection.DefaultOutfit);
        }

        private void OverrideAnimatorAnimationClips(BodyPart bodyPart)
        {
            AnimationClip[] animationClips = bodyPart.AnimationClips;
        
            for (int i = 0; i < animationClips.Length; i++)
            {
                AnimationClip animationClip = animationClips[i];
                
                string subClipName = GetSubClipName(animationClip.name);

                _animatorOverrideController[subClipName] = animationClip;
            }
        }
        
        private void SetRuntimeAnimatorController()
        {
            _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);

            _animator.runtimeAnimatorController = _animatorOverrideController;
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
    }
}
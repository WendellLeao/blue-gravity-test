using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class HumanoidAssembler : EntityComponent
    {
        [SerializeField]
        private BodyPart[] _bodyParts;
        [SerializeField]
        private AnimatorOverrideController _animatorOverrideController;

        protected override void OnBegin()
        {
            base.OnBegin();

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
            AnimationClip[] animatorAnimationClips = _animatorOverrideController.animationClips;
            
            for (int i = 0; i < animatorAnimationClips.Length; i++)
            {
                AnimationClip animatorClip = animatorAnimationClips[i];

                AnimationClip clip = CompareNamesAndGetClipToOverride(clipsCollection, animatorClip.name);

                animatorAnimationClips[i] = clip;
            }
        }

        private AnimationClip CompareNamesAndGetClipToOverride(BodyPartClipsCollection clipsCollection, string animatorClipName)
        {
            AnimationClip[] animationClips = clipsCollection.AnimationClips;

            for (int i = 0; i < animationClips.Length; i++)
            {
                AnimationClip animationClip = animationClips[i];

                string subName = animatorClipName.Substring(0, animatorClipName.Length - 1);

                if (!animationClip.name.Contains(subName))
                {
                    continue;
                }
                
                return animationClip;
            }

            return null;
        }
    }
}
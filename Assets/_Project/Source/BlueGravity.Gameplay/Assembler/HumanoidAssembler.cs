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
            AnimationClip[] animationClips = clipsCollection.AnimationClips;
            
            for (int i = 0; i < animationClips.Length; i++)
            {
                AnimationClip animationClip = animationClips[i];

                string clipName = animationClip.name;
                string clipNameSub = clipName.Substring(clipName.IndexOf("_"));

                _animatorOverrideController[clipName] = animationClip;

                Debug.Log(clipNameSub);
            }
        }
    }
}
using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartClipsCollection", fileName = "NewClipsCollection")]
    public sealed class BodyPartClipsCollection : ScriptableObject
    {
        [SerializeField]
        private AnimationClip[] _animationClips;

        public AnimationClip[] AnimationClips => _animationClips;
    }
}
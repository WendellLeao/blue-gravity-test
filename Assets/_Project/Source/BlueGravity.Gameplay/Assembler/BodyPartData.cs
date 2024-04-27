using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartData", fileName = "NewBodyPartData")]
    public sealed class BodyPartData : ScriptableObject
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private BodyPartCategoryData _categoryData;
        [SerializeField]
        private Sprite _displaySprite;
        [SerializeField]
        private AnimationClip[] _animationClips;
        [SerializeField]
        private bool _isVisible = true;

        public string Id => _id;
        public string CategoryId => _categoryData.Id;
        public Sprite DisplaySprite => _displaySprite;
        public AnimationClip[] AnimationClips => _animationClips;
        public bool IsVisible => _isVisible;
    }
}

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
        private float _price;
        [SerializeField]
        private AnimationClip[] _animationClips;
        [SerializeField]
        private bool _isVisible = true;

        private bool _wasBought;
        private bool _isEquipped;
        
        public string CategoryId => _categoryData.Id;
        public BodyPartCategoryData CategoryData => _categoryData;
        public Sprite DisplaySprite => _displaySprite;
        public float Price => _price;
        public AnimationClip[] AnimationClips => _animationClips;
        public bool IsVisible => _isVisible;
        public bool WasBought => _wasBought;
        public bool IsEquipped => _isEquipped;

        public void SetWasBought(bool wasBought)
        {
            _wasBought = wasBought;
        }
        
        public void SetIsEquipped(bool isEquipped)
        {
            _isEquipped = isEquipped;
        }
    }
}

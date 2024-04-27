using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartsGroup", fileName = "NewBodyPartsGroup")]
    public sealed class BodyPartsGroupData : ScriptableObject
    {
        [SerializeField]
        private BodyPartCategoryData _bodyPartCategoryData;
        [SerializeField]
        private BodyPartData[] _bodyPartsData;

        public BodyPartCategoryData CategoryData => _bodyPartCategoryData;
        public BodyPartData[] BodyPartsData => _bodyPartsData;
    }
}
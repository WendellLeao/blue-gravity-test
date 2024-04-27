using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartsGroup", fileName = "NewBodyPartsGroup")]
    public sealed class BodyPartsGroup : ScriptableObject
    {
        [SerializeField]
        private BodyPartCategory _bodyPartCategory;
        [SerializeField]
        private BodyPartData[] _bodyPartsData;

        public BodyPartCategory Category => _bodyPartCategory;
        public BodyPartData[] BodyPartsData => _bodyPartsData;
    }
}
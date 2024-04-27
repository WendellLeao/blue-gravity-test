using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartCategory", fileName = "NewBodyPartCategory")]
    public sealed class BodyPartCategory : ScriptableObject
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private BodyPartData _defaultBodyPart;

        public string Id => _id;
        public BodyPartData DefaultBodyPart => _defaultBodyPart;
    }
}
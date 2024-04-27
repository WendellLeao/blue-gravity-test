using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPart", fileName = "NewBodyPart")]
    public sealed class BodyPart : ScriptableObject
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private Sprite _displaySprite;
        [SerializeField]
        private BodyPartClipsCollection[] _clipsCollections;

        public string Id => _id;
        public Sprite DisplaySprite => _displaySprite;
        public BodyPartClipsCollection[] ClipsCollections => _clipsCollections;
    }
}

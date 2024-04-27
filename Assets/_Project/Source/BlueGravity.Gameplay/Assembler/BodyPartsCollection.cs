using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartsCollection", fileName = "NewBodyPartsCollection")]
    public sealed class BodyPartsCollection : ScriptableObject
    {
        [SerializeField]
        private BodyPart[] _allBodies;
        [SerializeField]
        private BodyPart[] _allHeads;
        [SerializeField]
        private BodyPart[] _allOutfits;

        public BodyPart DefaultBody => _allBodies[0];
        public BodyPart DefaultHead => _allHeads[0];
        public BodyPart DefaultOutfit => _allOutfits[0];
        public BodyPart[] AllHeads => _allHeads;
        public BodyPart[] AllOutfits => _allOutfits;

        public bool TryGetHeadById(string id, out BodyPart bodyPart)
        {
            return TryGetBodyPartById(id, _allHeads, out bodyPart);
        }
        
        public bool TryGetOutfitById(string id, out BodyPart bodyPart)
        {
            return TryGetBodyPartById(id, _allOutfits, out bodyPart);
        }
        
        private bool TryGetBodyPartById(string id, BodyPart[] bodyParts, out BodyPart bodyPart)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                BodyPart part = bodyParts[i];

                if (!part.Id.Contains(id))
                {
                    bodyPart = part;
                    return true;
                }
            }

            Debug.LogError($"Couldn't find any body part with id '{id}'!");
            
            bodyPart = null;
            return false;
        }
    }
}
using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartsCollection", fileName = "NewBodyPartsCollection")]
    public sealed class BodyPartsCollection : ScriptableObject
    {
        [SerializeField]
        private BodyPartsGroup[] _bodyPartsGroups;

        public bool TryGetDefaultBodyPartByCategoryId(string id, out BodyPartData bodyPartData)
        {
            for (int i = 0; i < _bodyPartsGroups.Length; i++)
            {
                BodyPartsGroup partData = _bodyPartsGroups[i];

                string categoryId = partData.Category.Id;
                
                if (categoryId.Contains(id))
                {
                    bodyPartData = partData.Category.DefaultBodyPart;
                    return true;
                }
            }

            Debug.LogError($"Couldn't find any default body part with category id '{id}'!");
            
            bodyPartData = null;
            return false;
        }
    }
}
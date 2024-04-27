using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    [CreateAssetMenu(menuName = "BlueGravity/HumanoidAssembler/BodyPartsCollection", fileName = "NewBodyPartsCollection")]
    public sealed class BodyPartsCollectionData : ScriptableObject
    {
        [SerializeField]
        private BodyPartsGroupData[] _bodyPartsGroups;

        public BodyPartsGroupData[] BodyPartsGroups => _bodyPartsGroups;
        
        public bool TryGetDefaultBodyPartByCategoryId(string id, out BodyPartData bodyPartData)
        {
            for (int i = 0; i < _bodyPartsGroups.Length; i++)
            {
                BodyPartsGroupData partData = _bodyPartsGroups[i];

                string categoryId = partData.CategoryData.Id;
                
                if (categoryId.Contains(id))
                {
                    bodyPartData = partData.CategoryData.DefaultBodyPart;
                    return true;
                }
            }

            Debug.LogError($"Couldn't find any default body part with category id '{id}'!");
            
            bodyPartData = null;
            return false;
        }
    }
}
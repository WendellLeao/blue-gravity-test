using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class BodyPart : EntityComponent
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private BodyPartCategoryData _categoryData;

        private BodyPartData _data;

        public string CategoryId => _categoryData.Id;

        public void Begin(BodyPartData data)
        {
            SetBodyPartData(data);
            
            base.Begin();
        }
        
        public void SetBodyPartData(BodyPartData data)
        {
            _data = data;

            _spriteRenderer.enabled = _data.IsVisible;
        }
    }
}
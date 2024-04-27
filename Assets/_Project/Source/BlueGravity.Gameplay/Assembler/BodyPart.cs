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
            _data = data;
            
            base.Begin();
        }

        protected override void OnBegin()
        {
            base.OnBegin();

            _spriteRenderer.enabled = _data.IsVisible;
        }
    }
}
using UnityEngine;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class BodyPart : EntityComponent
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private BodyPartCategory _category;

        private BodyPartData _data;

        public string CategoryId => _category.Id;

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
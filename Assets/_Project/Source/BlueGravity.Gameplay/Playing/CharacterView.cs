using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class CharacterView : EntityView, ICharacterView
    {
        [SerializeField]
        private bool _isFacingRight = true;
        
        public void SetIsFacingRight(bool isFacingRight)
        {
            if (_isFacingRight != isFacingRight)
            {
                Transform characterTransform = transform;
                
                Vector3 localScale = characterTransform.localScale;
                Vector3 newLocalScale = new Vector3(localScale.x * -1f, localScale.y, localScale.z);
                
                characterTransform.localScale = newLocalScale;
            }
            
            _isFacingRight = isFacingRight;
        }
    }
}
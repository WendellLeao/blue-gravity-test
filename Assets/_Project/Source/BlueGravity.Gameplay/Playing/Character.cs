using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class Character : Entity
    {
        protected override void OnBegin()
        {
            base.OnBegin();

            Debug.Log("Character has begun!");
        }
    }
}
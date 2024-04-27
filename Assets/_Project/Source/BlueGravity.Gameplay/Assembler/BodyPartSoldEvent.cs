using BlueGravity.Events;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class BodyPartSoldEvent : GameEvent
    {
        public BodyPartData BodyPartData { get; private set; }
        
        public BodyPartSoldEvent(BodyPartData bodyPartData)
        {
            BodyPartData = bodyPartData;
        }
    }
}
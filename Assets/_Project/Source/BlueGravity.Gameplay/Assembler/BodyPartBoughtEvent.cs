using BlueGravity.Events;

namespace BlueGravity.Gameplay.Assembler
{
    public sealed class BodyPartBoughtEvent : GameEvent
    {
        public BodyPartData BodyPartData { get; private set; }
        
        public BodyPartBoughtEvent(BodyPartData bodyPartData)
        {
            BodyPartData = bodyPartData;
        }
    }
}
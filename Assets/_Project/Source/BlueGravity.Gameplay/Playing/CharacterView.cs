using BlueGravity.Events;
using BlueGravity.Gameplay.Assembler;
using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class CharacterView : EntityView, ICharacterView
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private HumanoidAssembler _humanoidAssembler;

        private static readonly int IsIdle = Animator.StringToHash("IsIdle");
        private static readonly int HorizontalMovement = Animator.StringToHash("HorizontalMovement");
        private static readonly int VerticalMovement = Animator.StringToHash("VerticalMovement");

        private IEventService _eventService;
        private Vector2 _normalizedMovement;

        public void Setup(IEventService eventService)
        {
            _eventService = eventService;
            
            base.Setup();
        }

        public void Reset()
        {
            _animator.SetFloat(HorizontalMovement, 0f);
            _animator.SetFloat(VerticalMovement, 0f);
        }
        
        protected override void OnSetup()
        {
            base.OnSetup();

            _eventService.AddEventListener<BodyPartBoughtEvent>(HandleBodyPartBoughtEvent);
            _eventService.AddEventListener<BodyPartSoldEvent>(HandleBodyPartSoldEvent);
            
            _humanoidAssembler.Begin(_animator);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _eventService.RemoveEventListener<BodyPartBoughtEvent>(HandleBodyPartBoughtEvent);
            _eventService.RemoveEventListener<BodyPartSoldEvent>(HandleBodyPartSoldEvent);
            
            _humanoidAssembler.Stop();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);
            
            _humanoidAssembler.Tick(deltaTime);
        }

        private void HandleBodyPartBoughtEvent(GameEvent gameEvent)
        {
            if (gameEvent is BodyPartBoughtEvent bodyPartBoughtEvent)
            {
                BodyPartData bodyPartData = bodyPartBoughtEvent.BodyPartData;
                
                _humanoidAssembler.EquipBodyPart(bodyPartData);
            }
        }
        
        private void HandleBodyPartSoldEvent(GameEvent gameEvent)
        {
            if (gameEvent is BodyPartSoldEvent bodyPartBoughtEvent)
            {
                BodyPartData bodyPartData = bodyPartBoughtEvent.BodyPartData;

                _humanoidAssembler.EquipBodyPart(bodyPartData.CategoryData.DefaultBodyPart);
            }
        }
        
        public void SetNormalizedMovement(Vector2 movement)
        {
            _normalizedMovement = movement;

            bool isCharacterIdle = IsCharacterIdle(_normalizedMovement);
            
            _animator.SetBool(IsIdle, isCharacterIdle);
            
            if (isCharacterIdle)
            {
                return;
            }

            _animator.SetFloat(HorizontalMovement, _normalizedMovement.x);
            _animator.SetFloat(VerticalMovement, _normalizedMovement.y);
        }

        private bool IsCharacterIdle(Vector2 movement)
        {
            if (movement.x == 0.0f && movement.y == 0.0f)
            {
                return true;
            }

            return false;
        }
    }
}
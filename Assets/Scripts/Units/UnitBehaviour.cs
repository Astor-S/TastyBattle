using UnityEngine;

namespace Units
{
    public class UnitBehaviour : GameEntityBehaviour
    {
        [SerializeField] private UnitMovementInput _movementInput;

        protected override void Disable()
        {
            base.Disable(); 

            if (_movementInput != null)
                _movementInput.enabled = false;
        }
    }
}
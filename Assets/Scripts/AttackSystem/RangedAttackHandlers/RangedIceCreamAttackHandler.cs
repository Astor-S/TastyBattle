using UnityEngine;
using AttackSystem.AttackHandlers;
using FactionalAbilities.Handlers.Effects;

namespace AttackSystem.RangedAttackHandlers
{
    public class RangedIceCreamAttackHandler : RangedAttackHandler
    {
        [SerializeField] private IceCreamAbilityHandler _iceCreamAbilityHandler;

        protected override void Hit()
        {
            base.Hit();
            ApplyFreeze();
        }

        private void ApplyFreeze()
        {
            if (_iceCreamAbilityHandler != null)
            {
                if (AttackedTarget != null)
                {
                    FreezeHandler freezeHandler = AttackedTarget.GetComponent<FreezeHandler>();

                    if (freezeHandler == null)
                    {
                        freezeHandler = AttackedTarget.gameObject.AddComponent<FreezeHandler>();
                        freezeHandler.Initialize(
                            _iceCreamAbilityHandler.IceCreamAbility.FreezePercentage,
                            _iceCreamAbilityHandler.IceCreamAbility.FreezeDuration,
                            _iceCreamAbilityHandler.IceCreamAbility.MaxFreezePercentage,
                            _iceCreamAbilityHandler.IceCreamAbility.SlowDecreaseRate);
                    }
                }
            }
        }
    }
}
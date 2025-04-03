using UnityEngine;
using AttackSystem.AttackHandlers;
using FactionalAbilities.Handlers.Effects;
using Units;

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
                    UnitPresenter unitPresenter = AttackedTarget.GetComponent<UnitPresenter>();

                    if (unitPresenter != null)
                    {
                        FreezeHandler freezeHandler = AttackedTarget.GetComponent<FreezeHandler>();

                        if (freezeHandler == null)
                        {
                            freezeHandler = AttackedTarget.gameObject.AddComponent<FreezeHandler>();
                            freezeHandler.Initialize(
                                unitPresenter,
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
}
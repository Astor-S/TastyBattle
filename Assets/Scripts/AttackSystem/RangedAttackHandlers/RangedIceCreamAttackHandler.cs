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
                        float freezePercentage = _iceCreamAbilityHandler.IceCreamAbility.FreezePercentage;
                        Debug.Log($"[RangedIceCreamAttackHandler] Applying Freeze. Freeze Percentage: {freezePercentage}");

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
                        else
                        {
                            freezeHandler.ApplySlow(_iceCreamAbilityHandler.IceCreamAbility.FreezePercentage);
                            Debug.Log("[RangedIceCreamAttackHandler] FreezeHandler already exists. Applying additional slow.");
                        }
                    }
                }
            }
        }
    }
}
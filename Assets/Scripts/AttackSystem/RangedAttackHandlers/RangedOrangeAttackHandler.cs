using UnityEngine;
using AttackSystem.Interfaces;
using FactionalAbilities.Handlers.Effects;
using FactionalAbilities.Handlers;

namespace AttackSystem.RangedAttackHandlers
{
    public class RangedOrangeAttackHandler : RangedAttackHandler, IOrangeAttacker
    {
        [SerializeField] private OrangeAbilityHandler _orangAbilityHandler;

        protected override void Hit()
        {
            base.Hit();
            ApplyOrangeAcid();
        }

        public void ApplyOrangeAcid()
        {
            if (_orangAbilityHandler != null)
            {
                if (AttackedTarget != null)
                {
                    AcidHandler acidHandler = AttackedTarget.GetComponent<AcidHandler>();

                    if (acidHandler == null)
                    {
                        acidHandler = AttackedTarget.gameObject.AddComponent<AcidHandler>();
                        acidHandler.Initialize(AttackedTarget, _orangAbilityHandler.OrangeAbility.DamagePerSecond, _orangAbilityHandler.OrangeAbility.Duration);
                    }
                }
            }
        }
    }
}
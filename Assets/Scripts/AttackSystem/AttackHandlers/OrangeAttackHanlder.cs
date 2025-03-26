using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Effects;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class OrangeAttackHanlder : AttackHandler
    {
        [SerializeField] private OrangeAbilityHandler _orangAbilityHandler;

        protected override void Hit()
        {
            base.Hit(); 
            ApplyOrangeAcid();
        }

        private void ApplyOrangeAcid()
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
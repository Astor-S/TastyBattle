using UnityEngine;
using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Effects;

namespace AttackSystem.AttackHandlers
{
    public class OrangeAttackHanlder : AttackHandler
    {
        [SerializeField] private OrangeAbilityHandler _orangAbilityHandler;
        [SerializeField] private ParticleSystem _acidParticleEffectPrefab;

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
                        PlayAcidParticleEffect(AttackedTarget.transform);
                    }
                }
            }
        }

        private void PlayAcidParticleEffect(Transform target)
        {
            if (_acidParticleEffectPrefab != null)
            {
                ParticleSystem acidParticleEffect = Instantiate(_acidParticleEffectPrefab, target.position, Quaternion.identity, target);
                ParticleSystem.MainModule mainModule = acidParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                acidParticleEffect.Play();
            }
        }
    }
}
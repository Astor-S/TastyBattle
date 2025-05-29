using UnityEngine;
using AttackSystem.Interfaces;
using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Debuffs;
using Units;

namespace AttackSystem.AttackHandlers
{
    public class IceCreamAttackHanlder : AttackHandler, IDebuffAttacker, IDebuffEffector
    {
        [SerializeField] private IceCreamAbilityHandler _iceCreamAbilityHandler;
        [SerializeField] private ParticleSystem _freezeParticleEffectPrefab;

        public override void Hit()
        {
            ApplyDebuff();
            base.Hit();
        }

        public void ApplyDebuff()
        {
            if (_iceCreamAbilityHandler != null)
            {
                if (AttackedTarget != null && AttackedTarget.gameObject.activeInHierarchy)
                {
                    UnitPresenter unitPresenter = AttackedTarget.GetComponent<UnitPresenter>();

                    if (unitPresenter != null)
                    {
                        FreezeHandler freezeHandler = AttackedTarget.GetComponent<FreezeHandler>();

                        if (freezeHandler == null)
                        {
                            ParticleSystem freezeParticleEffectInstance =
                                PlayDebuffParticleEffect(AttackedTarget.transform);

                            freezeHandler = AttackedTarget.gameObject.AddComponent<FreezeHandler>();
                            freezeHandler.Initialize(
                                unitPresenter,
                                _iceCreamAbilityHandler.IceCreamAbility.FreezePercentage,
                                _iceCreamAbilityHandler.IceCreamAbility.MaxFreezePercentage,
                                _iceCreamAbilityHandler.IceCreamAbility.SlowDecreaseRate,
                                freezeParticleEffectInstance);
                        }
                        else
                        {
                            freezeHandler.ApplySlow(_iceCreamAbilityHandler.IceCreamAbility.FreezePercentage);
                        }
                    }
                }
            }
        }

        public ParticleSystem PlayDebuffParticleEffect(Transform target)
        {
            float quaternionX = -90f;
            float quaternionY = 0f;
            float quaternionZ = 0f;

            if (_freezeParticleEffectPrefab != null)
            {
                ParticleSystem freezeParticleEffect =
                    Instantiate(
                        _freezeParticleEffectPrefab,
                        target.position,
                        Quaternion.Euler(quaternionX, quaternionY, quaternionZ), target);

                ParticleSystem.MainModule mainModule = freezeParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                freezeParticleEffect.Play();

                return freezeParticleEffect;
            }

            return null;
        }
    }
}
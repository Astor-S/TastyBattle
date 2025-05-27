using UnityEngine;
using AttackSystem.Interfaces;
using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Effects;
using Units;

namespace AttackSystem.AttackHandlers
{
    public class IceCreamAttackHanlder : AttackHandler, IIceCreamAttacker,IFreezeEffector
    {
        [SerializeField] private IceCreamAbilityHandler _iceCreamAbilityHandler;
        [SerializeField] private ParticleSystem _freezeParticleEffectPrefab;

        public override void Hit()
        {
            base.Hit();
            ApplyFreeze();
        }

        public void ApplyFreeze()
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
                            ParticleSystem freezeParticleEffectInstance = PlayFreezeParticleEffect(AttackedTarget.transform);

                            freezeHandler = AttackedTarget.gameObject.AddComponent<FreezeHandler>();
                            freezeHandler.Initialize(
                                unitPresenter,
                                _iceCreamAbilityHandler.IceCreamAbility.FreezePercentage,
                                _iceCreamAbilityHandler.IceCreamAbility.FreezeDuration,
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

        public ParticleSystem PlayFreezeParticleEffect(Transform target)
        {
            if (_freezeParticleEffectPrefab != null)
            {
                ParticleSystem freezeParticleEffect = Instantiate(_freezeParticleEffectPrefab, target.position, Quaternion.Euler(-90f, 0f, 0f), target);
                ParticleSystem.MainModule mainModule = freezeParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                freezeParticleEffect.Play();

                return freezeParticleEffect;
            }

            return null;
        }
    }
}
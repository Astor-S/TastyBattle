using UnityEngine;
using FactionalAbilities;
using FactionalAbilities.Handlers.Debuffs;
using Units;

namespace AttackSystem.AttackHandlers
{
    public class IceCreamAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AttackHandler _attackHandler;
        [SerializeField] private ParticleSystem _freezeParticleEffectPrefab;
        [SerializeField] private IceCreamAbility _iceCreamAbility;

        private void OnEnable()
        {
            _attackHandler.HitExcecuting += ApplyDebuff;
        }

        private void OnDisable()
        {
            _attackHandler.HitExcecuting -= ApplyDebuff;
        }

        public void ApplyDebuff()
        {
            if (_attackHandler.AttackedTarget == null || _attackHandler.AttackedTarget.gameObject.activeInHierarchy == false)
                return;

            if (_attackHandler.AttackedTarget.TryGetComponent<UnitPresenter>(out var unitPresenter) == false)
                return;
                        
            if (_attackHandler.AttackedTarget.TryGetComponent<FreezeHandler>(out var freezeHandler) == false)
            {
                ParticleSystem freezeParticleEffectInstance =
                    PlayDebuffParticleEffect(_attackHandler.AttackedTarget.transform);

                freezeHandler = _attackHandler.AttackedTarget.gameObject.AddComponent<FreezeHandler>();
                freezeHandler.Initialize(
                    unitPresenter,
                    _iceCreamAbility.FreezePercentage,
                    _iceCreamAbility.MaxFreezePercentage,
                    _iceCreamAbility.SlowDecreaseRate,
                    freezeParticleEffectInstance);
            }
            else
            {
                freezeHandler.ApplySlow(_iceCreamAbility.FreezePercentage);
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
                        Quaternion.Euler(quaternionX, quaternionY, quaternionZ),
                        target);

                ParticleSystem.MainModule mainModule = freezeParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                freezeParticleEffect.Play();

                return freezeParticleEffect;
            }

            return null;
        }
    }
}
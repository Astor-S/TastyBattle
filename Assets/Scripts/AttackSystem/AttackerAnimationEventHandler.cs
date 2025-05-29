using System;
using UnityEngine;
using AttackSystem.AttackHandlers;

namespace AttackSystem
{
    public class AttackerAnimationEventHandler : DamagableAnimationEventHandler
    {
        private readonly int _attackSpeed = Animator.StringToHash(nameof(AttackSpeed));

        [SerializeField] private AttackHandler _attackHandler;
        [SerializeField] private Animator _animator;

        public event Action AttackingStarted;

        public int AttackSpeed => _attackSpeed;

        private void OnEnable() =>
            UpdateAttackSpeed();

        public void HitEvent()
        {
            _attackHandler.Hit();
            AttackingStarted?.Invoke();
            UpdateAttackSpeed();
        }

        private void UpdateAttackSpeed() =>
            _animator.SetFloat(AttackSpeed, _attackHandler.BaseAttackSpeed * _attackHandler.AttackSpeedMultiplier);
    }
}
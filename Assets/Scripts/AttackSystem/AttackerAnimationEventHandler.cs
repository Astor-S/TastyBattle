using System;
using UnityEngine;
using AttackSystem.AttackHandlers;

public class AttackerAnimationEventHandler : DamagableAnimationEventHandler
{
    public readonly int AttackSpeed = Animator.StringToHash(nameof(AttackSpeed));

    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private Animator _animator;

    public event Action AttackingStarted;

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

using AttackSystem.HealthBarSystem;
using StructureElements;
using System;
using UnityEngine;

public class UnitView : View
{
    [SerializeField] private Animator _animator;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private AttackerAnimationEventHandler _animationEventHandler;

    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));
    public readonly int Die = Animator.StringToHash(nameof(Die));

    public event Action Decayed;

    protected Animator Animator => _animator;

    protected override void OnValidate()
    {
        base.OnValidate();

        _animationEventHandler = GetComponentInChildren<AttackerAnimationEventHandler>();
    }

    private void Awake()
    {
        _healthBar.SetColor(gameObject.layer);
    }

    private void OnEnable()
    {
        _healthBar.gameObject.SetActive(true);
        _animationEventHandler.Decayed += OnDecayed;
        _animationEventHandler.AttackingStarted += SoundPlayer.SetAttackingSound;
    }

    private void OnDisable()
    {
        _animationEventHandler.Decayed -= OnDecayed;
        _animationEventHandler.AttackingStarted -= SoundPlayer.SetAttackingSound;
    }

    public void SetWalkingAnimation()
    {
        _animator.SetBool(IsAttacking, false);
        _animator.SetBool(IsWalking, true);

        SoundPlayer.SetWalkingSound();
    }

    public void SetAttackingAnimation()
    {
        _animator.SetBool(IsWalking, false);
        _animator.SetBool(IsAttacking, true);
    }

    public void SetDeathAnimation()
    {
        _animator.SetTrigger(Die);
        _healthBar.gameObject.SetActive(false);

        SoundPlayer.SetDeathSound();
    }

    private void OnDecayed() => 
        Decayed?.Invoke();
}

using System;
using UnityEngine;
using AttackSystem.HealthBarSystem;
using StructureElements;
using AttackSystem;

namespace Units
{
    public class UnitView : View
    {
        private readonly int _isWalking = Animator.StringToHash(nameof(IsWalking));
        private readonly int _isAttacking = Animator.StringToHash(nameof(IsAttacking));
        private readonly int _die = Animator.StringToHash(nameof(Die));

        [SerializeField] private Animator _animator;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private AttackerAnimationEventHandler _animationEventHandler;

        public event Action Decayed;

        public int IsWalking => _isWalking;
        public int IsAttacking => _isAttacking;
        public int Die => _die;
        public new AttackerSoundPlayer SoundPlayer => base.SoundPlayer as AttackerSoundPlayer;
        protected Animator Animator => _animator;

        protected override void OnValidate()
        {
            base.OnValidate();

            _animationEventHandler = GetComponentInChildren<AttackerAnimationEventHandler>();
        }

        private void Awake() =>
            _healthBar.SetColor(gameObject.layer);

        private void OnEnable()
        {
            _healthBar.gameObject.SetActive(true);
            _animationEventHandler.Decayed += OnDecayed;
            _animationEventHandler.AttackingStarted += this.SoundPlayer.SetAttackingSound;
        }

        private void OnDisable()
        {
            _animationEventHandler.Decayed -= OnDecayed;
            _animationEventHandler.AttackingStarted -= this.SoundPlayer.SetAttackingSound;
        }

        public void SetWalkingAnimation()
        {
            _animator.SetBool(IsAttacking, false);
            _animator.SetBool(IsWalking, true);
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

            this.SoundPlayer.SetDeathSound();
        }

        private void OnDecayed() =>
            Decayed?.Invoke();
    }
}
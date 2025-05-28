using AttackSystem.HealthBarSystem;
using StructureElements;
using Units;
using UnityEngine;

namespace Buildings
{
    public class BuildingView : View
    {
        private readonly int _died = Animator.StringToHash(nameof(Died));
        private readonly int _halfHP = Animator.StringToHash(nameof(HalfHP));
        private readonly int _quaterHP = Animator.StringToHash(nameof(QuaterHP));

        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Animator _animator;

        public int Died => _died;
        public int HalfHP => _halfHP;
        public int QuaterHP => _quaterHP;
        public Animator Animator => _animator;

        private void Start()
        {
            _healthBar.enabled = true;

            if (gameObject.layer == LayersData.PlayerLayerNumber)
                SetColor(Color.blue);
            else if (gameObject.layer == LayersData.EnemyLayerNumber)
                SetColor(Color.red);
        }

        public void SetColor(Color color)
        {
            if (color != default)
                _healthBar.SetColor(gameObject.layer);
        }

        public void SetDeathAnimation()
        {
            Animator.SetTrigger(Died);
            _particleSystem.Play();

            _healthBar.gameObject.SetActive(false);

            SoundPlayer.SetDeathSound();
        }

        public void SetHalfHPAnimation()
        {
            Animator.SetTrigger(HalfHP);
            _particleSystem.Play();

            SoundPlayer.SetDeathSound();
        }

        public void SetQuaterHPAnimation()
        {
            Animator.SetTrigger(QuaterHP);
            _particleSystem.Play();

            SoundPlayer.SetDeathSound();
        }
    }
}
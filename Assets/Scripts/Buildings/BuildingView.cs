using AttackSystem.HealthBarSystem;
using StructureElements;
using UnityEngine;

public class BuildingView : View
{
    public readonly int Died = Animator.StringToHash(nameof(Died));
    public readonly int HalfHP = Animator.StringToHash(nameof(HalfHP));
    public readonly int QuaterHP = Animator.StringToHash(nameof(QuaterHP));

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] protected Animator Animator;

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

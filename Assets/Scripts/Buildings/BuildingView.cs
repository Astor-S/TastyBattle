using StructureElements;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : View
{
    public readonly int Died = Animator.StringToHash(nameof(Died));
    public readonly int HalfHP = Animator.StringToHash(nameof(HalfHP));
    public readonly int QuaterHP = Animator.StringToHash(nameof(QuaterHP));

    [SerializeField] private Image _healthBarView;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] protected Animator Animator;

    public void SetColor(Color color)
    {
        if (color != default)
            _healthBarView.color = color;
    }

    public void SetDeathAnimation()
    {
        Animator.SetTrigger(Died);
        _particleSystem.Play();
    }

    public void SetHalfHPAnimation()
    {
        Animator.SetTrigger(HalfHP);
        _particleSystem.Play();
    }

    public void SetQuaterHPAnimation()
    {
        Animator.SetTrigger(QuaterHP);
        _particleSystem.Play();
    }
}

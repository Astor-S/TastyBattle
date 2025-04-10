using StructureElements;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : View
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _healthBarView;
    [SerializeField] protected ParticleSystem _particleSystem;

    public readonly int Died = Animator.StringToHash(nameof(Died));
    public readonly int HalfHP = Animator.StringToHash(nameof(HalfHP));
    public readonly int QuaterHP = Animator.StringToHash(nameof(QuaterHP));
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

    public void SetColor(Color color)
    {
        if (color != default)
            _healthBarView.color = color;
    }

    public void SetDeathAnimation()
    {
        _animator.SetTrigger(Died);
        _particleSystem.Play();
    }

    public void SetHalfHPAnimation()
    {
        _animator.SetTrigger(HalfHP);
        _particleSystem.Play();
    }

    public void SetQuaterHPAnimation()
    {
        _animator.SetTrigger(QuaterHP);
        _particleSystem.Play();
    }

    public void SetAttackingAnimation() => 
        _animator.SetBool(IsAttacking, true);
    
    public void StopAttackingAnimation() =>
        _animator.SetBool(IsAttacking, false);
}

using StructureElements;
using UnityEngine;
using UnityEngine.UI;

public class UnitView : View
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _healthBarView;

    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));
    public readonly int Die = Animator.StringToHash(nameof(Die));

    public void SetColor(Color color)
    {
        if (color != default)
            _healthBarView.color = color;
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

    internal void SetDeathAnimation()
    {
        _animator.SetTrigger(Die);
    }
}

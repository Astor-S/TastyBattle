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

    protected Animator Animator => _animator;

    public void SetHealthBarColor()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            _healthBarView.color = Color.blue;
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            _healthBarView.color = Color.red;
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
    }
}

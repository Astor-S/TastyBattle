using StructureElements;
using UnityEngine;

public class UnitVew : View
{
    [SerializeField] private Animator _animator;

    public readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    public readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));

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
}

using AttackSystem.AttackHandlers;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public readonly int AttackSpeed = Animator.StringToHash(nameof(AttackSpeed));

    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private Animator _animator;

    private void Start() => 
        _animator.SetFloat(AttackSpeed, _attackHandler.BaseAttackSpeed);

    public void HitEvent() => 
        _attackHandler.Hit();

    public void DeathEvent() =>
        Destroy(gameObject);
}

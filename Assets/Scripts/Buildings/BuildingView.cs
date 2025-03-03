using StructureElements;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : View
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _healthBarView;

    public readonly int Died = Animator.StringToHash(nameof(Died));
    public readonly int HalfHP = Animator.StringToHash(nameof(HalfHP));
    public readonly int QuaterHP = Animator.StringToHash(nameof(QuaterHP));

    public void SetColor(Color color)
    {
        if (color != default)
            _healthBarView.color = color;
    }

    internal void SetDeathAnimation() => 
        _animator.SetTrigger(Died);

    internal void SetHalfHPAnimation() =>
        _animator.SetTrigger(HalfHP);
    
    internal void SetQuaterHPAnimation() =>
        _animator.SetTrigger(QuaterHP);
}

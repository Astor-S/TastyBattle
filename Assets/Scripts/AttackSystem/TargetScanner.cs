using System.Collections.Generic;
using UnityEngine;

public class TargetScanner : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;
    [SerializeField] private List<LayerMask> _targetMasks = new();

    public IEnumerable<TargetAttack> Scan()
    {
        List<TargetAttack> targets = new();

        int combinedMask = 0;

        foreach (LayerMask mask in _targetMasks)
            combinedMask |= mask.value;

        foreach (Collider collider in Physics.OverlapSphere(transform.position, _radius, combinedMask))
            if (collider.TryGetComponent(out TargetAttack target))
                targets.Add(target);

        return targets;
    }
}
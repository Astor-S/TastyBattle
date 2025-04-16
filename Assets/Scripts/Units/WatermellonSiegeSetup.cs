using UnityEngine;

[CreateAssetMenu(fileName = "WatermellonSiege", menuName = "Scriptable Objects/WatermellonSiege")]
public class WatermellonSiegeSetup : UnitSetup
{
    [SerializeField] private float _hitDistance;

    public float HitDistance => _hitDistance;
}
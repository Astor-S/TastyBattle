using UnityEngine;

public class UnitMovementHandler : IMovement
{
    private readonly UnitSetup _stats;
    private readonly Transform _unit;

    public UnitMovementHandler(UnitSetup stats, Transform unitTransform)
    {
        _stats = stats;
        _unit = unitTransform;
    }

    public void Move(Vector3 target)
    {
        if (Vector3.Distance(_unit.position, target) > _stats.ApproachDistance)
            _unit.position = Vector3.MoveTowards(_unit.position, target, _stats.MovementSpeed * Time.deltaTime);    
    }
}

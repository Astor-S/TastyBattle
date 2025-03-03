using UnityEngine;

public class UnitMovementHandler : IMovement
{
    private readonly UnitStats _stats;
    private readonly UnitMovementProperties _properties;
    private readonly Transform _unit;

    public UnitMovementHandler(UnitStats stats)
    {
        _stats = stats;
        _unit = _properties.UnitTransform;
    }

    public void Move(Vector3 target)
    {
        if (Vector3.Distance(_unit.position, target) > _stats.ApproachDistance)
            _unit.position = Vector3.MoveTowards(_unit.position, target, _stats.Speed * Time.deltaTime);    
        
        _unit.LookAt(target);
    }
}

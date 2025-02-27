using UnityEngine;

public class UnitMovementHandler : IMovement
{
    private readonly UnitMovementProperties _properties;
    private Transform _unit;

    public UnitMovementHandler(UnitMovementProperties properties)
    {
        _properties = properties;
        _unit = _properties.UnitTransform;
    }

    public void Move(Vector3 target)
    {
        if (Vector3.Distance(_unit.position, target) > _properties.ApproachDistance)
            _unit.position = Vector3.MoveTowards(_unit.position, target, _properties.Speed * Time.deltaTime);    
        
        _unit.LookAt(target);
    }
}

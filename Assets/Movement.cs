using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _unit;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private void FixedUpdate() => 
        MoveTo(_target.position);

    public void MoveTo(Vector3 target)
    {
        if (Vector3.Distance(_unit.position, target) > _distance)
            _unit.position = Vector3.MoveTowards(_unit.position, target, _speed * Time.deltaTime);

        _unit.LookAt(target);
    }
}

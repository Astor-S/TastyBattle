using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    [SerializeField] private Unit _unit; //для определения слоя

    public List<Unit> _detectedUnits = new();

    public IReadOnlyList<Unit> DetectedUnits => _detectedUnits;

    //private void Update() => 
    //    RefreshList();

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Unit unit) && _detectedUnits.Contains(unit) == false)
            if (LayerMask.LayerToName(unit.gameObject.layer) == GetEnemyMask())
                _detectedUnits.Add(unit);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Unit unit))
            if (_detectedUnits.Contains(unit))
                _detectedUnits.Remove(unit);
    }

    private void RefreshList()
    {
        foreach (Unit unit in _detectedUnits)
            if (unit == null)
                _detectedUnits.Remove(unit);
    }

    private string GetEnemyMask()
    {
        if (LayerMask.LayerToName(_unit.gameObject.layer) == "Enemy")
            return "Player";
        else
            return "Enemy";
    }
}

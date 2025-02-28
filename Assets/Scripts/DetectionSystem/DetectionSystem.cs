using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    [SerializeField] private DamagableTarget _currentUnit; //для определения слоя

    private List<DamagableTarget> _detectedUnits = new();

    public IReadOnlyList<DamagableTarget> DetectedUnits => _detectedUnits;

    private void Update() => 
        RefreshList();

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DamagableTarget unit) && _detectedUnits.Contains(unit) == false)
            if (LayerMask.LayerToName(unit.gameObject.layer) == GetEnemyMask())
                _detectedUnits.Add(unit);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DamagableTarget unit))
            if (_detectedUnits.Contains(unit))
                _detectedUnits.Remove(unit);
    }

    private void RefreshList()
    {
        if (_detectedUnits.Count > 0)
            if (_detectedUnits[0] == null || _detectedUnits[0].isActiveAndEnabled == false)
                _detectedUnits.RemoveAt(0);
    }

    private string GetEnemyMask()
    {
        if (LayerMask.LayerToName(_currentUnit.gameObject.layer) == "Enemy")
            return "Player";
        else
            return "Enemy";
    }
}

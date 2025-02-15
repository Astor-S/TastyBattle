using Units;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawnButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private UnitFactory _unitFactory;
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;

    private void OnEnable()
    {
        _button.onClick.AddListener(SpawnUnit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SpawnUnit);
    }

    private void SpawnUnit()
    {
        _unitFactory.CreateUnit(
            _faction,
            _battleRole,
            _unitFactory.gameObject.layer,
            _unitFactory.transform.position);
    }
}

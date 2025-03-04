using Buildings;
using ResourceDistribution;
using Units;
using UnityEngine;

public class LevelRoot : MonoBehaviour
{
    [Header("Player's fields")]
    [SerializeField] private Mine _playerMine;
    [SerializeField] private MainBuildingPresenter _playerBase;
    [SerializeField] private UnitOrderItem[] _playerUnitOrderItems;
    [SerializeField] private ShopPresenter _playerShop;
    [SerializeField] private UnitFactory _playerUnitFactory;
    [SerializeField] private BuildingPresenter[] _playerTowers;
    [Header("Enemy's fields")]
    [SerializeField] private Mine _enemyMine;
    [SerializeField] private MainBuildingPresenter _enemyBase;
    [SerializeField] private UnitOrderItem[] _enemyUnitOrderItems;
    [SerializeField] private ShopPresenter _enemyShop;
    [SerializeField] private UnitFactory _enemyUnitFactory;
    [SerializeField] private BuildingPresenter[] _enemyTowers;
    [Header("General fields")]
    [SerializeField] private float _defaultUnitSpawnCooldown;
    [SerializeField] private int _defaultUnitSpawnCount;
    [Header("UI")]
    [SerializeField] private ResourceCounter _playerResourceCounter;

    private void Awake()
    {
        Wallet playerWallet = new Wallet(300, _playerMine);
        _playerResourceCounter.Init(playerWallet);

        Wallet enemyWallet = new Wallet(300, _enemyMine);

        _playerShop.Init(new Shop(_playerUnitFactory, _playerUnitOrderItems, playerWallet));
        _enemyShop.Init(new Shop(_enemyUnitFactory, _enemyUnitOrderItems, enemyWallet));

        foreach (BuildingPresenter tower in _playerTowers)
            tower.Init(new Building(tower.transform.position, tower.transform.rotation, tower.transform.localScale));

        foreach (BuildingPresenter tower in _enemyTowers)
            tower.Init(new Building(tower.transform.position, tower.transform.rotation, tower.transform.localScale));

        _playerBase.Init(new MainBuilding(
            _playerBase.transform.position,
            _playerBase.transform.rotation,
            _playerBase.gameObject.layer,
            _defaultUnitSpawnCooldown,
            _defaultUnitSpawnCount,
            _playerUnitFactory));

        _enemyBase.Init(new MainBuilding(
            _enemyBase.transform.position,
            _enemyBase.transform.rotation,
            _enemyBase.gameObject.layer,
            _defaultUnitSpawnCooldown,
            _defaultUnitSpawnCount,
            _enemyUnitFactory));
    }
}

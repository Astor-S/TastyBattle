using Buildings;
using ResourceDistribution;
using Units;
using UnityEngine;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private Mine _playerMine;
    [SerializeField] private MainBuildingPresenter _playerBase;
    [SerializeField] private UnitUIItem[] _playerUnitUIItems;
    [SerializeField] private ShopPresenter _playerShop;
    [SerializeField] private UnitFactory _playerUnitFactory;
    [SerializeField] private Mine _enemyMine;
    [SerializeField] private MainBuildingPresenter _enemyBase;
    [SerializeField] private UnitUIItem[] _enemyUnitUIItems;
    [SerializeField] private ShopPresenter _enemyShop;
    [SerializeField] private UnitFactory _enemyUnitFactory;
    [SerializeField] private ResourceCounter _playerResourceCounter;
    [SerializeField] private float _defaultUnitSpawnCooldown;
    [SerializeField] private int _defaultUnitSpawnCount;

    private void Awake()
    {
        Wallet playerWallet = new Wallet(300, _playerMine);
        _playerResourceCounter.Init(playerWallet);

        Wallet enemyWallet = new Wallet(300, _enemyMine);

        _playerShop.Init(new Shop(_playerUnitFactory, _playerUnitUIItems, playerWallet));
        _enemyShop.Init(new Shop(_enemyUnitFactory, _enemyUnitUIItems, enemyWallet));

        _playerBase.Init(new MainBuilding(
            _playerBase.transform.position,
            _playerBase.gameObject.layer,
            _defaultUnitSpawnCooldown,
            _defaultUnitSpawnCount,
            _playerUnitFactory));

        _enemyBase.Init(new MainBuilding(
            _enemyBase.transform.position,
            _enemyBase.gameObject.layer,
            _defaultUnitSpawnCooldown,
            _defaultUnitSpawnCount,
            _enemyUnitFactory));
    }
}

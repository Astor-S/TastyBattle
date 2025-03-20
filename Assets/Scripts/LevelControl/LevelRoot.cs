using Buildings;
using ResourceDistribution;
using System.Linq;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class LevelRoot : MonoBehaviour
{
    [Header("Player's fields")]
    [SerializeField] private Mine _playerMine;
    [SerializeField] private MainBuildingPresenter _playerBase;
    [SerializeField] private LayoutGroup _playerOrderItems;
    [SerializeField] private ShopPresenter _playerShop;
    [SerializeField] private UnitFactory _playerUnitFactory;
    [SerializeField] private TowerPresenter[] _playerTowers;
    [SerializeField] private DamagableSetup _playerBaseSetup;
    [SerializeField] private AttackerSetup _playerTowerSetup;
    [Header("Enemy's fields")]
    [SerializeField] private Mine _enemyMine;
    [SerializeField] private MainBuildingPresenter _enemyBase;
    [SerializeField] private LayoutGroup _enemyOrderItems;
    [SerializeField] private ShopPresenter _enemyShop;
    [SerializeField] private UnitFactory _enemyUnitFactory;
    [SerializeField] private TowerPresenter[] _enemyTowers;
    [SerializeField] private DamagableSetup _enemyBaseSetup;
    [SerializeField] private AttackerSetup _enemyTowerSetup;
    [Header("General fields")]
    [SerializeField] private float _defaultUnitSpawnCooldown;
    [SerializeField] private int _defaultUnitSpawnCount;
    [Header("UI")]
    [SerializeField] private ResourceCounter _playerResourceCounter;
    [SerializeField] private ResourceCounter _enemyResourceCounter;// поле для тестов

    private void Awake()
    {
        Wallet playerWallet = new Wallet(300, _playerMine);
        _playerResourceCounter.Init(playerWallet);

        Wallet enemyWallet = new Wallet(300, _enemyMine);
        _enemyResourceCounter.Init(enemyWallet);

        UnitOrderHandler[] playerUnitOrderHandlers = _playerOrderItems.GetComponentsInChildren<UnitOrderHandler>(true);
        UnitSetup[] playerUnitSetups = playerUnitOrderHandlers.Select(handler => handler.Setup).ToArray();

        UnitOrderHandler[] enemyUnitOrderHandlers = _enemyOrderItems.GetComponentsInChildren<UnitOrderHandler>(true);
        UnitSetup[] enemyUnitSetups = enemyUnitOrderHandlers.Select(handler => handler.Setup).ToArray();

        _playerShop.Init(new Shop(
            _playerUnitFactory,
            _playerOrderItems.GetComponentsInChildren<UnitOrderHandler>(true),
            _playerOrderItems.GetComponentsInChildren<UpgradeOrderHandler>(true),
            new UpgradeHandler(playerUnitSetups),
            playerWallet));

        _enemyShop.Init(new Shop(
            _enemyUnitFactory,
            _enemyOrderItems.GetComponentsInChildren<UnitOrderHandler>(true),
            _enemyOrderItems.GetComponentsInChildren<UpgradeOrderHandler>(true),
            new UpgradeHandler(enemyUnitSetups),
            enemyWallet));

        foreach (BuildingPresenter tower in _playerTowers)
        {
            tower.Init(new Building(
                _playerTowerSetup,
                tower.transform.position,
                tower.transform.rotation,
                tower.transform.localScale));
        }

        foreach (BuildingPresenter tower in _enemyTowers)
        {
            tower.Init(new Building(
                _enemyTowerSetup,
                tower.transform.position,
                tower.transform.rotation,
                tower.transform.localScale));
        }

        _playerBase.Init(new MainBuilding(
            _playerBaseSetup,
            _playerBase.gameObject.layer,
            _defaultUnitSpawnCooldown,
            _defaultUnitSpawnCount,
            _playerUnitFactory,
            playerUnitSetups,
            _playerBase.transform.position,
            _playerBase.transform.rotation));

        _enemyBase.Init(new MainBuilding(
            _enemyBaseSetup,
            _enemyBase.gameObject.layer,
            _defaultUnitSpawnCooldown,
            _defaultUnitSpawnCount,
            _enemyUnitFactory,
            enemyUnitSetups,
            _enemyBase.transform.position,
            _enemyBase.transform.rotation));
    }
}

using ResourceDistribution;
using StructureElements;
using Units;
using UnityEngine;

namespace Buildings
{
    public class MainBuildingPresenter : Presenter
    {
        [SerializeField] private float _unitSpawnCooldown = 10f;
        [SerializeField] private int _unitSpawnCount = 3;
        [SerializeField] private UnitFactory _unitFactory;
        [SerializeField] private float _unitSpawnOffset;
        [SerializeField] private UnitUIItem[] _unitUIItems;
        [SerializeField] private Mine _mine;
        [SerializeField] private ResourceCounter _resourceCounter;

        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {
            Wallet wallet = new Wallet(300, _mine);

            Init(new MainBuilding(
                transform.position,
                transform.localScale,
                gameObject.layer,
                _unitSpawnCooldown,
                _unitSpawnCount,
                _unitFactory,
                _unitUIItems,
                wallet));

            if (_resourceCounter != null)
                _resourceCounter.Init(wallet);
        }

        private void Start() => 
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
    }
}

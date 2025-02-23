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

        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {
            Init(new MainBuilding(
                transform.position,
                transform.localScale,
                gameObject.layer,
                _unitSpawnCooldown,
                _unitSpawnCount,
                _unitFactory));
        }

        private void Start()
        {
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }
    }
}

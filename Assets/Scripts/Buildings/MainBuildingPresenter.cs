using StructureElements;
using Units;
using UnityEngine;

namespace Buildings
{
    public class MainBuildingPresenter : Presenter
    {
        [SerializeField] private float _unitSpawnCooldown = 5f;
        [SerializeField] private int _unitSpawnCount = 5;
        [SerializeField] private UnitFactory _unitFactory;

        private float _unitSpawnOffset = 3f;

        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {
            Init(new MainBuilding(
                transform.position,
                transform.localScale,
                _unitSpawnCooldown,
                _unitSpawnCount,
                _unitFactory,
                new Vector3(transform.position.x + _unitSpawnOffset, 0f, 0f),
                Quaternion.LookRotation(Vector3.right)));
        }

        private void Start()
        {
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }
    }
}

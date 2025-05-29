using System;
using StructureElements;
using UnityEngine;
using AttackSystem;
using StructureElements;
using StructureElements.Interfaces;
using Upgrades;
using Units;

namespace Buildings
{
    public class BuildingPresenter : Presenter, IActivatable
    {
        [SerializeField] private DamagableTarget _damagableTarget;

        private UpgradesData _upgradeData;

        private Action<DamagableTarget> _dyingDelegate;

        public new BuildingView View => base.View as BuildingView;
        public new Building Model => base.Model as Building;
        public DamagableSetup Stats => Model.Stats;
        public DamagableTarget DamagableTarget => _damagableTarget;
        public UpgradesData UpgradesData => _upgradeData;

        private void Awake()
        {
            _dyingDelegate = (_) => OnDying();

            if (gameObject.layer == LayersData.PlayerLayerNumber)
                _upgradeData = UpgradesController.Player;
            else if (gameObject.layer == LayersData.EnemyLayerNumber)
                _upgradeData = UpgradesController.Enemy;
        }

        public virtual void Enable()
        {
            _damagableTarget.Init(Stats, _upgradeData);

            _damagableTarget.Dying += _dyingDelegate;
        }

        public virtual void Disable() =>
            _damagableTarget.Dying -= _dyingDelegate;

        protected virtual void OnDying() =>
            View.SetDeathAnimation();
    }
}
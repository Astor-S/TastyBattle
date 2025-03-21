using System;
using UnityEngine;

namespace FactionalAbilities
{
    [CreateAssetMenu(fileName = "MushroomAbility", menuName = "Scriptable Objects/MushroomAbility", order = 60)]
    public class MushroomAbility : ScriptableObject
    {      
        [SerializeField] private float _damageBonusPerUnit = 0.02f;
        [NonSerialized] private int _mushroomUnitCount = 0;
        
        public int MushroomUnitCount
        {
            get { return _mushroomUnitCount; }
            private set { _mushroomUnitCount = value; } 
        }

        public float DamageBonusPerUnit => _damageBonusPerUnit;

        public void AddUnit() =>
            MushroomUnitCount++;

        public void RemoveUnit() =>
            MushroomUnitCount--;
    }
}
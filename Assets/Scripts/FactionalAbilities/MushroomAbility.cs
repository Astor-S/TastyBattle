using System;
using UnityEngine;

namespace FactionalAbilities
{
    [CreateAssetMenu(fileName = "MushroomAbility", menuName = "Scriptable Objects/MushroomAbility", order = 60)]
    public class MushroomAbility : ScriptableObject
    {      
        [NonSerialized] public int MushroomUnitCount = 0;
        [SerializeField] private float _damageBonusPerUnit = 0.02f;

        public float DamageBonusPerUnit => _damageBonusPerUnit;
    }
}
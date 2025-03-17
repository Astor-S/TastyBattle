using UnityEngine;
using FactionalAbilities;

namespace Units
{
    public class IceCreamUnit : MonoBehaviour
    {
        [SerializeField] private IceCreamAbility _iceCreamAbility;

        public IceCreamAbility IceCreamAbility => _iceCreamAbility;
    }
}
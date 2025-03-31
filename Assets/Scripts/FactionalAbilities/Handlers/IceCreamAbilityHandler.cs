using UnityEngine;
using FactionalAbilities;

namespace AttackSystem.AttackHandlers
{
    public class IceCreamAbilityHandler : MonoBehaviour
    {
        [SerializeField] private IceCreamAbility _iceCreamAbility;

        public IceCreamAbility IceCreamAbility => _iceCreamAbility;
    }
}
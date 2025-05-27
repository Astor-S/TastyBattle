using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class IceCreamAbilityHandler : MonoBehaviour
    {
        [SerializeField] private IceCreamAbility _iceCreamAbility;

        public IceCreamAbility IceCreamAbility => _iceCreamAbility;
    }
}
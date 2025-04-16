using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class OrangeAbilityHandler : MonoBehaviour
    {
        [SerializeField] private OrangeAbility _orangeAbility;

        public OrangeAbility OrangeAbility => _orangeAbility;
    }
}
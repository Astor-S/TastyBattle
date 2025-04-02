using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class AvocadoAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AvocadoAbility _avocadoAbility;

        public AvocadoAbility AvocadoAbility => _avocadoAbility;
    }
}
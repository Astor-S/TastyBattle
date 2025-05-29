using UnityEngine;

namespace StructureElements
{
    public class View : MonoBehaviour
    {
        [SerializeField] private DamagableSoundPlayer _soundPlayer;

        protected DamagableSoundPlayer SoundPlayer => _soundPlayer;

        protected virtual void OnValidate() =>
            _soundPlayer = GetComponent<DamagableSoundPlayer>();
    }
}
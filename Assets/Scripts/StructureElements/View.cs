using UnityEngine;

namespace StructureElements
{
    public class View : MonoBehaviour
    {
        [SerializeField] private SoundPlayer _soundPlayer;

        protected SoundPlayer SoundPlayer => _soundPlayer;

        protected virtual void OnValidate()
        {
            _soundPlayer = GetComponent<SoundPlayer>();
        }
    }
}

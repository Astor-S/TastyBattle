using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "NewSoundPack", menuName = "Scriptable Objects/AttackerSoundPack")]
    public class AttackerSoundPack : DamagableSoundPack
    {
        [SerializeField] private AudioClip _attackingSound;

        public AudioClip AttackingSound => _attackingSound;
    }
}
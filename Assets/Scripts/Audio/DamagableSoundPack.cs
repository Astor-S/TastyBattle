using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundPack", menuName = "Scriptable Objects/DamagableSoundPack")]
public class DamagableSoundPack : ScriptableObject
{
    [SerializeField] private AudioClip _deathSound;

    public AudioClip DeathSound => _deathSound;
}

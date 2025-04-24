using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundPack", menuName = "Scriptable Objects/SoundPack")]
public class SoundPack : ScriptableObject
{
    [SerializeField] private AudioClip _walkingSound;
    [SerializeField] private AudioClip _attackingSound;
    [SerializeField] private AudioClip _deathSound;

    public AudioClip WalkingSound => _walkingSound;
    public AudioClip AttackingSound => _attackingSound;
    public AudioClip DeathSound => _deathSound;
}

using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundPack", menuName = "Scriptable Objects/UnitSoundPack")]
public class UnitSoundPack : AttackerSoundPack
{
    [SerializeField] private AudioClip _walkingSound;

    public AudioClip WalkingSound => _walkingSound;
}

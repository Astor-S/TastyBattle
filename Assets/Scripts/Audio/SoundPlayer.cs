using StructureElements;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AttackerAnimationEventHandler _attackerAnimation;
    [SerializeField] private DamagableSoundPack _soundPack;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    public AttackerSoundPack AttackerSoundPack => _soundPack as AttackerSoundPack;
    public UnitSoundPack UnitSoundPack => _soundPack as UnitSoundPack;

    private void Awake()
    {
        _audioSource.playOnAwake = false;
        _audioSource.outputAudioMixerGroup = _mixerGroup;
    }

    public void SetWalkingSound() =>
        PlaySound(UnitSoundPack.WalkingSound, true);

    public void SetAttackingSound() =>
        PlaySound(AttackerSoundPack.AttackingSound, false);

    public void SetDeathSound() =>
        PlaySound(_soundPack.DeathSound, false);

    public void StopAttackingSound() => 
        _audioSource.Stop();

    private void PlaySound(AudioClip clip, bool isLooped)
    {
        if (_audioSource.clip != clip)
            _audioSource.Stop();

        _audioSource.clip = clip;

        _audioSource.loop = isLooped;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();
    }
}

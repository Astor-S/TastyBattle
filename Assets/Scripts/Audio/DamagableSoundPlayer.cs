using UnityEngine;
using UnityEngine.Audio;

public class DamagableSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] protected DamagableSoundPack _soundPack;

    private void Awake()
    {
        _audioSource.playOnAwake = false;
        _audioSource.outputAudioMixerGroup = _mixerGroup;
    }

    public void SetDeathSound() =>
        PlaySound(_soundPack.DeathSound, false);

    public void StopAttackingSound() =>
        _audioSource.Stop();

    protected void PlaySound(AudioClip clip, bool isLooped)
    {
        if (_audioSource.clip != clip)
            _audioSource.clip = clip;

        _audioSource.loop = isLooped;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();
    }
}

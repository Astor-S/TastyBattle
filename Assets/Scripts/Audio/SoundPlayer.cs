using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private UnitView _unitView;
    [SerializeField] private AttackerAnimationEventHandler _attackerAnimation;
    [SerializeField] private SoundPack _soundPack;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private void Awake()
    {
        _audioSource.playOnAwake = false;
        _audioSource.outputAudioMixerGroup = _mixerGroup;
        _audioSource.loop = false;
    }

    private void OnEnable()
    {
        _unitView.WalkingStarted += SetWalkingSound;
        _unitView.Dead += SetDeathSound;

        _attackerAnimation.AttackingStarted += SetAttackingSound;
    }

    private void OnDisable()
    {
        _unitView.WalkingStarted -= SetWalkingSound;
        _unitView.Dead -= SetDeathSound;

        _attackerAnimation.AttackingStarted -= SetAttackingSound;
    }

    private void SetWalkingSound() =>
        PlaySound(_soundPack.WalkingSound);

    private void SetAttackingSound() => 
        PlaySound(_soundPack.AttackingSound);

    private void SetDeathSound() => 
        PlaySound(_soundPack.DeathSound);

    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();
    }
}

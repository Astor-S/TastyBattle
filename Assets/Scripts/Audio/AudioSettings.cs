using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private const int MinVolumeValue = -80;
    private const int Multiplier = 20;

    [SerializeField] private AudioSetup _music;
    [SerializeField] private AudioSetup _sound;

    public AudioSetup Music => _music;
    public AudioSetup Sound => _sound;

    public void SwitchToggle(AudioSetup audio)
    {
        if (audio.Toggle.isOn == false)
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
        else
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, MinVolumeValue);
    }

    public void ChangeVolume(AudioSetup audio)
    {
        if (audio.Toggle.isOn == false)
            audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
    }
}

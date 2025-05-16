using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private const int MinVolumeValue = -80;
    private const int Multiplier = 20;

    [SerializeField] private AudioSetup _music;
    [SerializeField] private AudioSetup _sound;

    private bool _paused;

    public AudioSetup Music => _music;
    public AudioSetup Sound => _sound;

    public void TurnOff() => 
        Sound.AudioMixerGroup.audioMixer.SetFloat(Sound.AudioMixerGroup.name, MinVolumeValue);

    public void TurnOn() => 
        Sound.AudioMixerGroup.audioMixer.SetFloat(Sound.AudioMixerGroup.name, Mathf.Log10(Sound.Slider.value) * Multiplier);

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
            if (audio.AudioMixerGroup.name != Sound.AudioMixerGroup.name)
                audio.AudioMixerGroup.audioMixer.SetFloat(audio.AudioMixerGroup.name, Mathf.Log10(audio.Slider.value) * Multiplier);
    }
}

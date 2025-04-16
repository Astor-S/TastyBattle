using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetup : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Slider _slider;
    [SerializeField] private Toggle _toggle;

    public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;
    public Slider Slider => _slider;
    public Toggle Toggle => _toggle;

    public void Setup(float value, bool isOn)
    {
        _slider.value = value;
        _toggle.isOn = isOn;
    }
}

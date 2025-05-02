using UnityEngine;
using YG;

public class AudioSaveSystem : SaveSystem
{
    [SerializeField] private AudioSettings _audioSettings;

    public override void Load()
    {
        _audioSettings.Music.Setup(YG2.saves.MusicVolume, YG2.saves.IsMusicOn);
        _audioSettings.Sound.Setup(YG2.saves.SoundVolume, YG2.saves.IsSoundOn);

        _audioSettings.SwitchToggle(_audioSettings.Music);
        _audioSettings.SwitchToggle(_audioSettings.Sound);
    }

    public override void Save()
    {
        YG2.saves.MusicVolume = _audioSettings.Music.Slider.value;
        YG2.saves.SoundVolume = _audioSettings.Sound.Slider.value;

        YG2.saves.IsMusicOn = _audioSettings.Music.Toggle.isOn;
        YG2.saves.IsSoundOn = _audioSettings.Sound.Toggle.isOn;

        YG2.SaveProgress();
    }
}
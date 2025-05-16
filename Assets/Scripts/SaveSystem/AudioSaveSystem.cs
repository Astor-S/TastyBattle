using UnityEngine;
using YG;

public class AudioSaveSystem : SaveSystem
{
    [SerializeField] private AudioSettings _audioSettings;

    public override void Load()
    {
        _audioSettings.Music.Setup(YG2.saves.musicVolume, YG2.saves.isMusicOn);
        _audioSettings.Sound.Setup(YG2.saves.soundVolume, YG2.saves.isSoundOn);

        _audioSettings.SwitchToggle(_audioSettings.Music);
        _audioSettings.SwitchToggle(_audioSettings.Sound);
    }

    public override void Save()
    {
        YG2.saves.musicVolume = _audioSettings.Music.Slider.value;
        YG2.saves.soundVolume = _audioSettings.Sound.Slider.value;

        YG2.saves.isMusicOn = _audioSettings.Music.Toggle.isOn;
        YG2.saves.isSoundOn = _audioSettings.Sound.Toggle.isOn;

        YG2.SaveProgress();
    }
}
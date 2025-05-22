using UnityEngine;
using YG;

public class AudioSaveSystem : SaveSystem
{
    private const float DefaultVolumeValue = 0.4f;
    private const bool DefaultToggleValue = false;

    [SerializeField] private AudioSettings _audioSettings;

    public override void Load()
    {
        _audioSettings.Music.Setup(YG2.saves.musicVolume, YG2.saves.isMusicOn);
        _audioSettings.Sound.Setup(YG2.saves.soundVolume, YG2.saves.isSoundOn);

        _audioSettings.SwitchToggle(_audioSettings.Music);
        _audioSettings.SwitchToggle(_audioSettings.Sound);

        Save();
    }

    public override void LoadLocal()
    {
        _audioSettings.Music.Setup(DefaultVolumeValue, DefaultToggleValue);
        _audioSettings.Sound.Setup(DefaultVolumeValue, DefaultToggleValue);

        Save();
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
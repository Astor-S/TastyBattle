using PlayerPrefs = RedefineYG.PlayerPrefs;
using UnityEngine;
using YG;

public class AudioSaveSystem : SaveSystem
{
    private const string MusicVolumeKey = "musicVolume";
    private const string SoundVolumeKey = "soundVolume";

    [SerializeField] private AudioSettings _audioSettings;

    public override void Load()
    {
        _audioSettings.Music.Setup(YG2.saves.musicVolume, YG2.saves.isMusicOn);
        _audioSettings.Sound.Setup(YG2.saves.soundVolume, YG2.saves.isSoundOn);

        _audioSettings.SwitchToggle(_audioSettings.Music);
        _audioSettings.SwitchToggle(_audioSettings.Sound);
    }

    public override void LoadLocal()
    {
        _audioSettings.Music.Setup(PlayerPrefs.GetFloat(MusicVolumeKey), false);
        _audioSettings.Sound.Setup(PlayerPrefs.GetFloat(SoundVolumeKey), false);
    }

    public override void Save()
    {
        PlayerPrefs.SetFloat(MusicVolumeKey, _audioSettings.Music.Slider.value);
        PlayerPrefs.SetFloat(SoundVolumeKey, _audioSettings.Sound.Slider.value);

        PlayerPrefs.Save();

        YG2.saves.musicVolume = _audioSettings.Music.Slider.value;
        YG2.saves.soundVolume = _audioSettings.Sound.Slider.value;

        YG2.saves.isMusicOn = _audioSettings.Music.Toggle.isOn;
        YG2.saves.isSoundOn = _audioSettings.Sound.Toggle.isOn;

        YG2.SaveProgress();
    }
}
using System;
using UnityEngine;
using YG;

namespace SaveSystems
{
    public class AudioSaveSystem : SaveSystem
    {
        private const string MusicVolumeKey = "musicVolume";
        private const string SoundVolumeKey = "soundVolume";
        private const string MusicToggleKey = "musicToggle";
        private const string SoundToggleKey = "soundToggle";
        private const float DefaultVolumeValue = 0.4f;
        private const bool DefaultToggleValue = false;

        [SerializeField] private Audio.AudioSettings _audioSettings;

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
            if (PlayerPrefs.HasKey(MusicVolumeKey) == false && PlayerPrefs.HasKey(SoundVolumeKey) == false &&
               PlayerPrefs.HasKey(MusicToggleKey) == false && PlayerPrefs.HasKey(SoundToggleKey) == false)
            {
                _audioSettings.Music.Setup(DefaultVolumeValue, DefaultToggleValue);
                _audioSettings.Sound.Setup(DefaultVolumeValue, DefaultToggleValue);

                return;
            }
            else
            {
                _audioSettings.Music.Setup(PlayerPrefs.GetFloat(MusicVolumeKey),
                    Convert.ToBoolean(PlayerPrefs.GetInt(MusicToggleKey)));

                _audioSettings.Sound.Setup(PlayerPrefs.GetFloat(SoundVolumeKey),
                    Convert.ToBoolean(PlayerPrefs.GetInt(SoundToggleKey)));
            }

            Save();
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(MusicVolumeKey, _audioSettings.Music.Slider.value);
            PlayerPrefs.SetFloat(SoundVolumeKey, _audioSettings.Sound.Slider.value);

            PlayerPrefs.SetInt(MusicToggleKey,
                Convert.ToInt32(_audioSettings.Music.Toggle.isOn));

            PlayerPrefs.SetInt(SoundToggleKey,
                Convert.ToInt32(_audioSettings.Sound.Toggle.isOn));

            PlayerPrefs.Save();

            YG2.saves.musicVolume = _audioSettings.Music.Slider.value;
            YG2.saves.soundVolume = _audioSettings.Sound.Slider.value;

            YG2.saves.isMusicOn = _audioSettings.Music.Toggle.isOn;
            YG2.saves.isSoundOn = _audioSettings.Sound.Toggle.isOn;

            YG2.SaveProgress();
        }
    }
}
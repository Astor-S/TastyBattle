using System.Collections.Generic;

namespace YG
{
    public partial class SavesYG
    {        
        //Audio saves
        public float MusicVolume = 0.3f;
        public float SoundVolume = 0.3f;

        public bool IsMusicOn = true;
        public bool IsSoundOn = true;

        //Score
        public int Score = 0;

        //OnFirstPlay
        public bool IsFirstLaunch = true;

        //Language
        public string Language = default;

        //Skins
        public List<SkinPack> SkinPacks = new();
    }
}
using GameService;
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

        //Levels
        public List<Levels> openedLeveles = new();

        public SavesYG()
        {
            openedLeveles.Add(Levels.Level1);
            openedLeveles.Add(Levels.Level6);
            openedLeveles.Add(Levels.Level11);
            openedLeveles.Add(Levels.Level16);
            openedLeveles.Add(Levels.Level21);
        }

        public bool IsLevelOpened(Levels level) =>
            openedLeveles.Contains(level);
    }
}
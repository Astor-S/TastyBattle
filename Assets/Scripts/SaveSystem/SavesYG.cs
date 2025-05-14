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
        public List<Levels> openedLevels = new();

        public SavesYG()
        {
            openedLevels.Add(Levels.Level1);
            openedLevels.Add(Levels.Level6);
            openedLevels.Add(Levels.Level11);
            openedLevels.Add(Levels.Level16);
            openedLevels.Add(Levels.Level21);
        }

        public bool IsLevelOpened(Levels level) =>
            openedLevels.Contains(level);
    }
}
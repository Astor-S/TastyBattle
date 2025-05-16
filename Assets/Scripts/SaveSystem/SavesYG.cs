using System.Collections.Generic;
using GameService;

namespace YG
{
    public partial class SavesYG
    {
        //Audio saves
        public float musicVolume = 0.3f;
        public float soundVolume = 0.3f;

        public bool isMusicOn = false;
        public bool isSoundOn = false;

        //Score
        public int score = 0;
        public int balanceMoney;

        //OnFirstPlay
        public bool isFirstLaunch = true;

        //Language
        public string language = default;

        //Skins
        public List<SkinPack> skinPacks = new();

        //Levels
        public List<Levels> openedLevels = new();
        public bool isMushroomCampaignCompleted = false;

        public SavesYG()
        {
            openedLevels.Add(Levels.Level1);
            openedLevels.Add(Levels.Level6);
            openedLevels.Add(Levels.Level11);
            openedLevels.Add(Levels.Level16);
        }

        public bool IsLevelOpened(Levels level) =>
            openedLevels.Contains(level);
    }
}
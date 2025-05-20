using System.Collections.Generic;
using GameService;

namespace YG
{
    public partial class SavesYG
    {
        //Audio saves
        public float musicVolume = 0.4f;
        public float soundVolume = 0.4f;

        public bool isMusicOn = false;
        public bool isSoundOn = false;

        //Score
        public int score = 0;
        public int balanceMoney = 0;

        //OnFirstPlay
        public bool isFirstLaunch = true;

        //Language
        public string language = default;

        //Skins
        public Dictionary<SkinPack, bool> availableSkinPacks = new();
        public Dictionary<SkinPack, bool> equippedSkinPacks = new();

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

        public void Refresh()
        {
            musicVolume = 0.4f;
            soundVolume = 0.4f;

            isMusicOn = false;
            isSoundOn = false;

            score = 0;
            balanceMoney = 0;

            isFirstLaunch = true;

            language = default;

            openedLevels.Clear();

            openedLevels.Add(Levels.Level1);
            openedLevels.Add(Levels.Level6);
            openedLevels.Add(Levels.Level11);
            openedLevels.Add(Levels.Level16);

            isMushroomCampaignCompleted = false;
        }
    }
}
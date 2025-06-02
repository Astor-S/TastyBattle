using System.Collections.Generic;
using GameService;
using PackShopService;

namespace YG
{
    public partial class SavesYG
    {
        //Audio saves
        public float MusicVolume = 0.4f;
        public float SoundVolume = 0.4f;

        public bool IsMusicOn = false;
        public bool IsSoundOn = false;

        //Score
        public int Score = 0;
        public int BalanceMoney = 0;

        //OnFirstPlay
        public bool IsFirstLaunch = true;

        //Skins
        public List<SkinPack> EquippedPacks = new ();
        public List<SkinPack> AvailablePacks = new ();

        //Levels
        public List<Levels> OpenedLevels = new ();
        public bool IsMushroomCampaignCompleted = false;

        public SavesYG()
        {
            OpenedLevels.Add(Levels.Level1);
            OpenedLevels.Add(Levels.Level6);
            OpenedLevels.Add(Levels.Level11);
            OpenedLevels.Add(Levels.Level16);
        }

        public bool IsLevelOpened(Levels level) =>
            OpenedLevels.Contains(level);

        public void Refresh()
        {
            MusicVolume = 0.4f;
            SoundVolume = 0.4f;

            IsMusicOn = false;
            IsSoundOn = false;

            Score = 0;
            BalanceMoney = 0;

            IsFirstLaunch = true;

            OpenedLevels.Clear();

            EquippedPacks.Clear();
            AvailablePacks.Clear();

            OpenedLevels.Add(Levels.Level1);
            OpenedLevels.Add(Levels.Level6);
            OpenedLevels.Add(Levels.Level11);
            OpenedLevels.Add(Levels.Level16);

            IsMushroomCampaignCompleted = false;
        }
    }
}
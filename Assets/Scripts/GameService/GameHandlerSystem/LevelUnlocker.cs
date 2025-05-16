using UnityEngine;
using YG;

namespace GameService.GameHandlerSystem
{
    public class LevelUnlocker : MonoBehaviour
    {
        [SerializeField] private Levels _levelsToOpen;

        public void RequestToOpenLevel()
        {
            if (YG2.saves.openedLevels.Contains(_levelsToOpen) == false)
                OpenLevel();
        }

        private void OpenLevel()
        {
            YG2.saves.openedLevels.Add(_levelsToOpen);
            YG2.SaveProgress();
        }
    }
}
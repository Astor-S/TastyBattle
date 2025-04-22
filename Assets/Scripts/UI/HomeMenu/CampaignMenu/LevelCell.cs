using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using GameService;
using Units;

namespace UI.HomeMenu.CampaignMenu
{
    [CreateAssetMenu(fileName = "NewLevelCell", menuName = "Scriptable Objects/LevelCell")]
    public class LevelCell : ScriptableObject
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private int _cellIndex;
        [SerializeField] private Faction _enemyFaction;

        [field: SerializeField] public Levels LevelsType { get; private set; }

        public Faction EnemyFaction => _enemyFaction;

        public void LoadScene()
        {
            if (string.IsNullOrEmpty(_sceneToLoad) == false)
                SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
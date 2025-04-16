using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameService
{
    public class LevelLoader : MonoBehaviour
    {
        public IEnumerator LoadLevelAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
    }
}